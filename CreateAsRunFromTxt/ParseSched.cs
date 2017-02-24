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
        public string headerDate { get; set; }
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
        // Here we create a DataTable with four columns to store parsed sechedule
        private DataTable tblSched = new DataTable();
        // When starting up set columns in DataTable
        public ParseSched()
        {
            tblSched.Columns.Add("EventID", typeof(string));
            tblSched.Columns.Add("BillingReference", typeof(string));
            tblSched.Columns.Add("HouseNumber", typeof(string));
            tblSched.Columns.Add("AlternateId", typeof(string));
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
                bool blInsideElement = false;
                bool blInsideEventID = false;
                bool blBillingReferenceCode = false;
                bool blHouseNumber = false;
                bool blAlternateId = false;
                bool blInsideContent = false;
                // start are reading loop
                while (reader.Read())
                {

                    // Get element name and switch on it.
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            // starting Element, set blInsideElement if EventData and Primary
                            if (reader.LocalName.Equals("EventData") && 
                                reader["eventType"] == "Primary" )
                            {
                                blInsideElement = true;
                            }
                            if(blInsideElement)
                            {
                                if (reader.LocalName.Equals("EventId"))
                                {
                                    // set the blInsideEventID for testing EventId and BillingReferenceCode
                                    if (!blInsideEventID) blInsideEventID = true;                                
                                }
                                if (reader.LocalName.Equals("BillingReferenceCode"))
                                    if (!blBillingReferenceCode) blBillingReferenceCode = true;
                            }                
                            if(reader.LocalName.Equals("Content"))
                                if (!blInsideContent) blInsideContent = true;
                            if (reader.LocalName.Equals("HouseNumber")) blHouseNumber = true;
                            // Version 1.0.1 Adding a check for the correct attribute value of "ISCI" after Corus traffic sent <AlternateId idType="SUB"/>
                            if (reader.LocalName.Equals("AlternateId"))
                            {
                                if (reader.HasAttributes)
                                {
                                    reader.MoveToAttribute(0);
                                    if(reader.Value.Equals("ISCI"))
                                    blAlternateId = true;
                                }
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.LocalName.Equals("EventData"))
                            {
                                blInsideElement = false;
                                // we get some false rows, don't save them
                                if (eventID != null && eventID.Length > 3)
                                {
                                    tblSched.Rows.Add(eventID, eventBilling, eventHouseNum,eventAlternateId);
                                    objF.log2screen("Sched \t" + eventBilling +
                                        "\t" + eventHouseNum + "\t" + eventAlternateId);
                                }
                                // reset all the varibles
                                eventID = eventBilling = eventHouseNum = "";
                            }
                            if (reader.LocalName.Equals("EventId")) blInsideEventID = false;
                            if (reader.LocalName.Equals("BillingReferenceCode")) blBillingReferenceCode = false;
                            if (reader.LocalName.Equals("HouseNumber")) blHouseNumber = false;
                            if (reader.LocalName.Equals("Content")) blInsideContent = false;
                            if (reader.LocalName.Equals("AlternateId")) blAlternateId = false;
                            break;
                        case XmlNodeType.Text:
                            // if inside the Event ID and not in BillingReference you have Event ID
                            if (blInsideEventID && !blBillingReferenceCode) eventID = reader.Value;
                            if (blBillingReferenceCode) eventBilling = reader.Value;
                            // changed this after mike and molly had house number Content/ContentId/HouseNumber
                            // if (blHouseNumber&&blInsideContent) eventHouseNum = reader.Value;
                            if (blHouseNumber) eventHouseNum = reader.Value;
                            if (blAlternateId) eventAlternateId = reader.Value;
                            break;
                    }
                    
                }
            }
            return true;
        }
        public string getBillingFromID(string strEventID)
        {
            string strReturn = "";
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) strReturn = dr[0].Field<string>("BillingReference");
            return strReturn;
        }
        public string getAlternateIdFromID(string strEventID)
        {
            string strReturn = "";
            DataRow[] dr = tblSched.Select(string.Format("EventID ='{0}' ", strEventID));
            // return the value only if there is one row selected
            if (dr.Length == 1) strReturn = dr[0].Field<string>("AlternateId");
            return strReturn;
        }
    }
}
