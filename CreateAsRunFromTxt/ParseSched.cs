using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreateAsRunFromTxt
{
    class ParseSched
    {
        public string headerDate { get; set; }
        public string headerUUID { get; set; }
        public string headerScheduleStart { get; set; }
        public string headerScheduleEnd { get; set; }
        public string headerChannelNumber { get; set; }
        public string headerStatus { get; set; }
        public string headerShortName { get; set; }
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
                                headerUUID = reader["scheduleId"].ToString();
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
                 
                headerUUID = reader.ReadContentAsString();
      
            }
            return true;
        }
    }
}
