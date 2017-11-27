using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreateAsRunFromTxt
{
    class ParseSched
    {
        // Variables computed when reading header
        public string headerUUID { get; set; }
        public string headerScheduleStart { get; set; }
        public string headerScheduleEnd { get; set; }
        public string headerChannelNumber { get; set; }
        public string headerStatus { get; set; }
        public string headerShortName { get; set; }
        // Variables while reading primary event data
        public string eventID { get; set; }
        public string eventBilling { get; set; }
        public string eventHouseNum { get; set; }
        public string eventAlternateId { get; set; }
        public string eventStartTime { get; set; }
        public string eventDate { get; set; }
        public string firstStartDate { get; set; }
        private bool blDoingFirstDate = true;
        public EventType tblEventType = EventType.None;
        public NonPrimaryEventName tbNonPri = NonPrimaryEventName.None;
        // Here we create a DataTable with four columns to store parsed sechedule
        private DataTable tblSched = new DataTable();
        // When starting up set columns in DataTable
        public ParseSched()
        {
            tblSched.Columns.Add("EventID", typeof(string));
            tblSched.Columns.Add("BillingReference", typeof(string));
            tblSched.Columns.Add("HouseNumber", typeof(string));
            tblSched.Columns.Add("AlternateId", typeof(string));
            tblSched.Columns.Add("EventType", typeof(EventType));
            tblSched.Columns.Add("NonPrimaryEventName", typeof(NonPrimaryEventName));
            tblSched.Columns.Add("StartTime", typeof(string));
        }
        public bool openSchedHeader(string strSchedName)
        {
            // Create an XML reader for this file.
            using (XmlReader reader = XmlReader.Create(strSchedName))
            {
                bool blNotHitChannel = true;
                while (reader.Read() && blNotHitChannel)
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "Schedule":
                                headerUUID = reader["scheduleId"];
                                headerScheduleStart = reader["scheduleStart"];
                                headerScheduleEnd = reader["scheduleEnd"];
                                break;
                            case "Channel":
                                headerChannelNumber = reader["channelNumber"];
                                headerStatus = reader["status"];
                                headerShortName = reader["shortName"];
                                blNotHitChannel = false;
                                break;
                        }
                    }
                }
            }
            return true;
        }
        public bool makeTableOfSched(string strSchedName, Form1 objF)
        {
            // Truncate Datatable
            tblSched.Clear();
            // Create an XML reader for this file.
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;
            readerSettings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(strSchedName))
            {
                // set these before the reading loop
                bool blInsideEventID = false;
                bool blBillingReferenceCode = false;
                bool blHouseNumber = false;
                bool blAlternateId = false;
                bool blInsideContent = false;
                bool blNonPrimaryEvent = false;
                bool blStartTime = false;
                bool blSmpteTimeCode = false;
                // for 2.0 need to add non-primary

                // start are reading loop
                while (reader.Read())
                {

                    // Get element name and switch on it.
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            // starting Element, set blInsideElement if EventData and Primary
                           // if (reader.LocalName.Equals("EventData") &&  reader["eventType"] == "Primary" )
                           switch(reader.LocalName)
                            {
                                case "EventData":
                                    if (reader["eventType"].Length > 3) Enum.TryParse(reader["eventType"].ToString(), out tblEventType);
                                    break;
                                case "EventId":
                                    // set the blInsideEventID for testing EventId and BillingReferenceCode
                                    if (!blInsideEventID) blInsideEventID = true;
                                    break;
                                case "BillingReferenceCode":
                                    if (!blInsideEventID && !blBillingReferenceCode) blBillingReferenceCode = true;
                                    break;
                                case "Content":
                                    if (!blInsideContent) blInsideContent = true;
                                    break;
                                case "HouseNumber":
                                    blHouseNumber = true;
                                    break;
                                case "NonPrimaryEventName":
                                    blNonPrimaryEvent = true;
                                    break;
                                case "AlternateId":
                                    // Version 1.0.1 Adding a check for the correct attribute value of "ISCI" after Corus traffic sent <AlternateId idType="SUB"/>
                                    if (reader.HasAttributes)
                                    {
                                        reader.MoveToAttribute(0);
                                        if (reader.Value.Equals("ISCI"))
                                            blAlternateId = true;
                                    }
                                    break;
                                case "StartDateTime":
                                    blStartTime = true;
                                    break;
                                case "SmpteTimeCode":
                                    blSmpteTimeCode = true;
                                    break;
                                case "SmpteDateTime":
                                    if(blStartTime && reader.HasAttributes)
                                    {
                                        reader.MoveToAttribute(0);
                                        if (reader.Name.Equals("broadcastDate"))
                                        {
                                            eventDate = reader.Value;
                                            // sometimes date has Z at end to indicate zulu time.
                                            eventDate = eventDate.Substring(0, 10);
                                            if (blDoingFirstDate)
                                            {
                                                firstStartDate = eventDate;
                                                // need to add time
                                                
                                            }
                                        }
                                    }

                                    break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            switch(reader.LocalName)
                            {
                                //case "EventData":
                                //    blInsideElement = false;
                                //    break;
                                case "EventId":
                                    blInsideEventID = false;
                                    break;
                                case "BillingReferenceCode":
                                    blBillingReferenceCode = false;
                                    break;
                                case "HouseNumber":
                                    blHouseNumber = false;
                                    break;
                                case "NonPrimaryEventName":
                                    blNonPrimaryEvent = false;
                                    break;
                                case "Content":
                                    blInsideContent = false;
                                    break;
                                case "AlternateId":
                                    blAlternateId = false;
                                    break;
                                case "StartDateTime":
                                    blStartTime = false;
                                    break;
                                case "SmpteTimeCode":
                                    blSmpteTimeCode = false;
                                    break;
                                // The House number can be outside of EventData so write out row on ScheduledEvent
                                case "ScheduledEvent":
                                    // we get some false rows, don't save them
                                    if (eventID != null && eventID.Length > 3)
                                    {
                                        tblSched.Rows.Add(eventID, eventBilling, eventHouseNum, eventAlternateId, tblEventType, tbNonPri, 
                                            $"{eventDate} {eventStartTime}");
                                        objF.log2screen("Sched \t" + eventID +
                                            "\t" + eventBilling + "\t" + eventHouseNum + " - " + tblEventType.ToString() + " " + tbNonPri.ToString());
                                        if (blDoingFirstDate)
                                        {
                                            firstStartDate = firstStartDate +" "+ eventStartTime.Substring(0, 2) + ":00:00.00";
                                            blDoingFirstDate = false;
                                        }
                                    }
                                    // resetting all the varibles
                                    eventID = eventBilling = eventHouseNum = eventAlternateId = "";
                                    // resetting Enums
                                    tblEventType = EventType.None;
                                    tbNonPri = NonPrimaryEventName.None;
                                    break;
                            }
                            break;
                        case XmlNodeType.Text:
                            // if inside the Event ID and not in BillingReference you have Event ID
                            if (blInsideEventID && !blBillingReferenceCode) eventID = reader.Value;
                            if (blBillingReferenceCode) eventBilling = reader.Value;
                            // changed this after mike and molly had house number Content/ContentId/HouseNumber
                            // if (blHouseNumber&&blInsideContent) eventHouseNum = reader.Value;
                            if (blHouseNumber) eventHouseNum = reader.Value;
                            if (blNonPrimaryEvent) Enum.TryParse(reader.Value, out tbNonPri);
                            if (blAlternateId) eventAlternateId = reader.Value;
                            if (blSmpteTimeCode && blStartTime)eventStartTime = reader.Value;
                            break;
                    }
                    
                }
            }
            return true;
        }

        public string getAlternateIdFromID(string strEventID)
        {
            string strReturn = "";
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) strReturn = dr[0].Field<string>("AlternateId");
            return strReturn;
        }

        public string getBillingFromID(string strEventID)
        {
            string strReturn = "";
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) strReturn = dr[0].Field<string>("BillingReference");
            return strReturn;
        }

        public EventType getEventType(string strEventID)
        {
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if(dr.Length == 1)return dr[0].Field<EventType>("EventType");
            return EventType.None;
        }

        public string getHouseNumberFromID(string strEventID)
        {
            string strReturn = "";
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) strReturn = dr[0].Field<string>("HouseNumber");
            return strReturn;
        }

        public NonPrimaryEventName getNonPrimaryEventName(string strEventID)
        {
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) return dr[0].Field<NonPrimaryEventName>("NonPrimaryEventName");
            return NonPrimaryEventName.None;
        }

        public string getStartTime(string strEventID)
        {
            DataRow[] dr = tblSched.Select($"EventID ='{strEventID}'");
            if(dr.Length == 1) return dr[0].Field<string>("StartTime");
            return "";
        }

    }
}
