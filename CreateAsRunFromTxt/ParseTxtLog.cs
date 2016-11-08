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
    class ParseTxtLog
    {
        // Create new table
        DataTable myTextTable = new DataTable();
        public string strDateToFind { get; set; }
        public string strLogTxt { get; set; }
        // Create class with no parameters
        public ParseTxtLog()
        {
            strDateToFind = DateTime.Now.ToString("M/d/yyy");
        }
        // made shortcut to set the date at starting up class
        public ParseTxtLog(string strDate)
        {
            strDateToFind = strDate;
        }
        public bool CompareTxtFile(string strFileName)
        {
            //
            // Read first 10 text characters with TextReader. 12/45/7890
            //
            using (TextReader reader = File.OpenText(strFileName))
            {
                char[] block = new char[10];
                reader.ReadBlock(block, 0, 10);
                string strMessage = new string(block);
                // could be short date like 5/4/2016-1 so finding - character
                int i = strMessage.IndexOf('-');
                if( i > 0)
                {
                    strMessage = strMessage.Substring(0, i);
                }
                if (strMessage.CompareTo(strDateToFind)==0) return true;
            }
            return false;
        }
        public string WriteAsRunFile(string strFileName,string strSchedName)
        {
            string strWriteFile = Path.GetDirectoryName(strFileName) + "\\BXF_Automation_" +
                Path.GetFileNameWithoutExtension(strFileName) + ".xml";
            XmlWriterSettings myXMLsettings = new XmlWriterSettings();
            myXMLsettings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(strWriteFile,myXMLsettings))
            {
                ParseSched myPS = new ParseSched();
                myPS.openSchedHeader(strSchedName);
                writer.WriteStartDocument();
                writer.WriteStartElement("BxfMessage"); // Start BXF Message
                    writer.WriteAttributeString("id", "urn:uuid:"+Guid.NewGuid().ToString());
                    writer.WriteAttributeString("origin", "Automation System");
                writer.WriteStartElement("BxfData"); // Start BXF Data
                    writer.WriteAttributeString("action", "add");
                writer.WriteStartElement("Schedule"); // Start Schedule
                    writer.WriteAttributeString("action", "add");
                    writer.WriteAttributeString("type", "Primary");
                    writer.WriteAttributeString("scheduleId", myPS.headerUUID);
                writer.WriteStartElement("Channel"); // Start Channel
                    writer.WriteAttributeString("type", "digital_television");
                    writer.WriteAttributeString("status", myPS.headerStatus);
                    writer.WriteAttributeString("network", "1");
                    writer.WriteAttributeString("shortName", myPS.headerShortName);
                    writer.WriteAttributeString("channelNumber", myPS.headerChannelNumber);
                writer.WriteEndElement(); // End Channel
                //This is looping section for each event
                writer.WriteStartElement("AsRun"); // Start AsRun
                writer.WriteStartElement("BasicAsRun"); // Start AsRun
                writer.WriteEndElement(); // End BasicAsRun
                writer.WriteEndElement(); // End AsRun
                writer.WriteEndElement(); // End Schedule
                writer.WriteEndElement(); // End BXF Data
                writer.WriteEndElement(); // End BXF Message
                writer.WriteEndDocument();
            }
            return "Finished As Run";
        }

    }
}
