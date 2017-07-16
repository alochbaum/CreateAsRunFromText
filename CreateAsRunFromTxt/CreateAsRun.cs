using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CreateAsRunFromTxt
{
    class CreateAsRun
    {
        // Create new table
        DataTable myTextTable = new DataTable();
        public string strDateToFind { get; set; }
        public string strLogTxt { get; set; }
        // Create class with no parameters
        public CreateAsRun()
        {
            strDateToFind = DateTime.Now.ToString("M/d/yyy");
        }

        public bool WriteAsRunFile(string strFileName,string strSchedName,string strOptFile,Form1 objF)
        {
            string strWriteFile = Path.GetDirectoryName(strFileName) + "\\BXF_Automation_" +
                Path.GetFileNameWithoutExtension(strSchedName) + ".xml";
            XmlWriterSettings myXMLsettings = new XmlWriterSettings();
            myXMLsettings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(strWriteFile,myXMLsettings))
            {
                ParseSched myPS = new ParseSched();
                if (myPS.openSchedHeader(strSchedName)) objF.log2screen("Succesfully parsed header");
                else {
                    objF.log2screen("Error paring header of " + strSchedName);
                    return false;
                }
                if (myPS.makeTableOfSched(strSchedName, objF)) objF.log2screen("Returned from parsing schedule");
                writer.WriteStartDocument();
                // Start BXF Message, need to add basic namespace here to have it as attribute
                writer.WriteStartElement("BxfMessage", "http://smpte-ra.org/schemas/2021/2008/BXF"); // Start BXF Message
                    writer.WriteAttributeString("id", "urn:uuid:"+Guid.NewGuid().ToString());
                    writer.WriteAttributeString("origin", "Automation System");
                    //need to update this with first event start for accuracy
                    writer.WriteAttributeString("dateTime", myPS.headerScheduleStart);
                    //this would be iTXadmin or user running As Run service
                    writer.WriteAttributeString("userName", "BXFasRunCreator");
                    // using namespace overload
                    writer.WriteAttributeString("ext","usage","AsRun");
                    writer.WriteAttributeString("originType", "Automation");
                    writer.WriteAttributeString("destination", "Traffic System");
                    writer.WriteAttributeString("messageType", "Information");
                    // can't have colon in http name
                    writer.WriteAttributeString("xmlns", null, null, "http://smpte-ra.org/schemas/2021/2008/BXF");
                    writer.WriteAttributeString("xmlns","ext",null, "http://smpte-ra.org/schemas/2021/2008/BXF/Extension");
                    writer.WriteAttributeString("xmlns","xsi",null, "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xmlns","pmcp", null, "http://www.atsc.org/XMLSchemas/pmcp/2007/3.1");
                writer.WriteStartElement("BxfData"); // Start BXF Data
                    writer.WriteAttributeString("action", "add");
                writer.WriteStartElement("Schedule"); // Start Schedule
                    writer.WriteAttributeString("action", "add");
                    writer.WriteAttributeString("type", "Primary");
                    writer.WriteAttributeString("scheduleId", myPS.headerUUID);
                    writer.WriteAttributeString("scheduleEnd", myPS.headerScheduleEnd);
                    writer.WriteAttributeString("scheduleStart", myPS.headerScheduleStart);
                writer.WriteStartElement("Channel"); // Start Channel
                    writer.WriteAttributeString("type", "digital_television");
                    writer.WriteAttributeString("status", myPS.headerStatus);
                    writer.WriteAttributeString("network", "1");
                    writer.WriteAttributeString("shortName", myPS.headerShortName);
                    writer.WriteAttributeString("channelNumber", myPS.headerChannelNumber);
                writer.WriteEndElement(); // End Channel
                //This is looping section for each event parse the schedule

                // parsing the text log
                ParseLines myTxtLog = new ParseLines(strFileName, strOptFile,objF);
                if (myTxtLog.iCount < 1) objF.log2screen("Error: Low parsing count on Txt file");
                objF.log2screen("Number of lines with Video Clip or Live in Log: "+myTxtLog.iCount.ToString());
                string strTemp = "";
                string strUUIDHold = "";
                EventType tmpEventType = EventType.None;
                for (int iloop = 0; iloop < myTxtLog.iCount; iloop++)
                {
                    writer.WriteStartElement("AsRun"); // Start AsRun
                    writer.WriteStartElement("BasicAsRun"); // Start AsRun
                    // Version 1.0.1 made BasicAsRun more complete
                    writer.WriteAttributeString("xmlns", null, null, "http://smpte-ra.org/schemas/2021/2008/BXF");
                    writer.WriteStartElement("AsRunEventId"); // Start AsRunEventId
                    writer.WriteStartElement("EventId"); // Start EventId
                                                         // [7] is first AsRunEventId/EventId
                                                         // |4a31eba0-55ce-49f0-889b-2ccd5c857afd|
                                                         // the recall adds urn:uuid: at top of string.

                    // Getting line from parsed text file table
                    strUUIDHold = myTxtLog.getEventID(iloop);

                    // Checking the House Number for UUID match added for 2.x if it is a primary event
                    strTemp = myTxtLog.getHouseNumber(iloop);
                    tmpEventType = myPS.getEventType(strUUIDHold);
                    // Added skip UUID check if getCBDont finds Live
                    if (tmpEventType == EventType.Primary && (!(myTxtLog.getType(iloop) == "Live" && objF.getCBDont())))
                    {
                        if (strTemp.Equals(myPS.getHouseNumberFromID(strUUIDHold)))
                        {
                            // Reporting back to screen UUID, Start Date, Start Time if good
                            objF.log2screen("Writing: " + strUUIDHold + "\t" + myTxtLog.getStartDate(iloop) + "\t" + myTxtLog.getStartTime(iloop));
                            // Writing String if good
                            writer.WriteString(strUUIDHold);
                        }
                        else
                        {
                            // Report error back to screen
                            objF.log2screen("Error Non-Equal House Numbers:" + strUUIDHold + "\t" + strTemp + " doesn't equal " + myPS.getHouseNumberFromID(strUUIDHold), 1);
                            // Set for subsitution and if set wipe out UUID
                            if (objF.getCBSub()) strUUIDHold = "Bad";
                        }
                    } else
                    {
                        // Reporting back to screen UUID, Start Date, Start Time if good
                        objF.log2screen("Writing: " + strUUIDHold + "\t" + myTxtLog.getStartDate(iloop) + "\t" + myTxtLog.getStartTime(iloop));
                    }

                    writer.WriteEndElement(); // End EventId
                    // second AsRunEventId/BillingReferenceCode
                    // this might not exist searching for value
                    strTemp = myPS.getBillingFromID(strUUIDHold);
                    // testing value and writing if found
                    if (strTemp != null && strTemp.Length > 0)
                    {
                        writer.WriteStartElement("BillingReferenceCode"); // Start BillingReferenceCode
                        writer.WriteString(strTemp);
                        writer.WriteEndElement(); // End BillingReferenceCode
                    }

                    writer.WriteEndElement(); // End AsRunEventId
                    writer.WriteStartElement("Content"); // Start Content
                    // [2] is third Content/ContentId/HouseNumber
                    writer.WriteStartElement("ContentId"); // Start ContentId
                    writer.WriteStartElement("HouseNumber"); // Start HouseNumber
                        writer.WriteString(myTxtLog.getHouseNumber(iloop));
                    writer.WriteEndElement(); // End HouseNumber
                    //  AsRunEventId
                    // this might not exist searching for value
                    strTemp = myPS.getAlternateIdFromID(strUUIDHold);
                    // testing value and writing if found
                    if (strTemp!=null && strTemp.Length > 0)
                    {
                        writer.WriteStartElement("AlternateId"); // Start AlternateId
                        writer.WriteAttributeString("idType", "ISCI");
                        writer.WriteString(strTemp);
                        writer.WriteEndElement(); // End AlternateId
                    }

                    writer.WriteEndElement(); // End ContentId
                    // [3] is fourth Content/Name
                    // |SCRTYPY_136 -01|The Security Brief - 1
                    //
                    writer.WriteStartElement("Name"); // Start Name
                    // use XML safe name
                    // for non primary get the Event name in 2.x currently that is Logo or GPI
                    if(tmpEventType==EventType.NonPrimary)
                    {
                        writer.WriteString(myPS.getNonPrimaryEventName(strUUIDHold).ToString());
                    }
                    else
                    writer.WriteString(myTxtLog.getName(iloop));
                    writer.WriteEndElement(); // End Name
                    //
                    // [5] is fifth Content/Media/MediaLocation/SOM/SmpteTimeCode
                    // |00:00:20.00
                    //
                    // [6] is sixth Content/Media/MediaLocation/EOM/SmpteTimeCode  looks more like EOM than duration
                    // |00:12:35.29
                    // 
                    // End Content
                    writer.WriteEndElement();
                    // seventh AsRunDetail/Status == Aired Without Discrepancy
                    writer.WriteStartElement("AsRunDetail");
                    writer.WriteStartElement("Status");
                    if(myTxtLog.getType(iloop)!="Comment")
                        writer.WriteString("Aired Without Discrepancy");
                    else writer.WriteString("Did not air");
                    // End Status
                    writer.WriteEndElement();
                    // eighth AsRunDetail/Type == Primary
                    writer.WriteStartElement("Type");
                    // Corrected for 2.x series so I can get live value for not checking UUID
                    if(myTxtLog.getType(iloop) == "Video Clip" || myTxtLog.getType(iloop) == "Live") writer.WriteString("Primary");
                    else writer.WriteString(myTxtLog.getType(iloop));
                    // End Type
                    writer.WriteEndElement();
                    // [4] ninth is AsRunDetail/StartDateTime/SmpteDateTime with date/SmpteTimeCode
                    // |00:12:15.29
                    writer.WriteStartElement("StartDateTime");
                    writer.WriteStartElement("SmpteDateTime");
                    writer.WriteAttributeString("broadcastDate", myTxtLog.getStartDate(iloop));
                    writer.WriteStartElement("SmpteTimeCode");
                    writer.WriteString(myTxtLog.getStartTime(iloop));
                    // End SmpteTimeCode
                    writer.WriteEndElement();
                    // End SmpteDateTime
                    writer.WriteEndElement();
                    // End StartDateTime
                    writer.WriteEndElement();
                    writer.WriteStartElement("Duration");
                    writer.WriteStartElement("SmpteDuration");
                    writer.WriteStartElement("SmpteTimeCode");
                    writer.WriteString(myTxtLog.getDuration(iloop));
                    // End SmpteTimeCode
                    writer.WriteEndElement();
                    // End SmpteDuration
                    writer.WriteEndElement();
                    // End Duration
                    writer.WriteEndElement();
                    // End AsRunDetail
                    writer.WriteEndElement(); 
                    writer.WriteEndElement(); // End BasicAsRun
                    writer.WriteEndElement(); // End AsRun
                }
                // End looping section
                writer.WriteEndElement(); // End Schedule
                writer.WriteEndElement(); // End BXF Data
                writer.WriteEndElement(); // End BXF Message
                writer.WriteEndDocument();
            }
            return true;
        }

    }
}
