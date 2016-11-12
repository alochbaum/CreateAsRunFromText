using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateAsRunFromTxt
{
    class ParseLines
    {
        // Here we create a DataTable with four columns to store parsed sechedule
        private DataTable tblLog = new DataTable();
        private DataRow dRow;
        private DateTime dtStartLog = Convert.ToDateTime("09/25/1991 00:00:50.42");
        private int iStartHour;
        public string strDateToFind { get; set; }
        public int iCount { get; set; }
        public ParseLines(string strFileName, bool blDoubleFrames)
        {
            tblLog.Columns.Add("EventID", typeof(string)); // first [7]
            tblLog.Columns.Add("HouseNumber", typeof(string)); //third [2]
            tblLog.Columns.Add("Name", typeof(string)); //fourth [3]
            tblLog.Columns.Add("SOM", typeof(string)); //fifth [5]
            tblLog.Columns.Add("EOM", typeof(string)); //sixth [6]
            tblLog.Columns.Add("StartDate", typeof(string)); //ninth A [0]* Needs split
            tblLog.Columns.Add("StartTime", typeof(string)); //ninth B [0]* Needs split and convert
            using (TextReader reader = File.OpenText(strFileName))
            {
                string strLine = "";
                bool blFirstLine = true;
                bool blDateNotUpdated = true;
                // Read line by line
                while ((strLine = reader.ReadLine()) != null)
                {
                    string[] strArray = strLine.Split('|');
                    if (strArray.Count() == 9)
                    {
                        if (blFirstLine)
                        {
                            //
                            // parse the first sub string to get starting date, then hour. 12/45/7890-hh
                            //
                            string[] strSubSplit = strArray[0].Split('-');
                            // Not sure if this will work internationally
                            if (!DateTime.TryParseExact(strSubSplit[0], "M/d/yyyy",
                                CultureInfo.CurrentCulture, DateTimeStyles.None, out dtStartLog))
                            {
                                // failure to read date break the loop
                                break;
                            }
                            blFirstLine = false;
                            
                        }
                        // continue only if type is "Video Clip" or "Live"
                        if (strArray[1] == "Video Clip" || strArray[1] == "Live")
                        {
                            // Need to process the hour and first time hour is greater than 24 need to add to date
                            string[] strSubSplit = strArray[0].Split('-');
                            // converting time from hh:MM:ss.frame to hh:MM:ss:frame for SMPTE time in XML
                            strSubSplit[1] = strSubSplit[1].Replace('.', ':');
                            // splitting time after replace for frame doubling calc on frames
                            string[] strSubSubSplit = strSubSplit[1].Split(':');
                            if (Convert.ToInt16(strSubSubSplit[0]) > 23) { 
                                if (blDateNotUpdated)
                                {
                                    dtStartLog.AddDays(1);
                                    blDateNotUpdated = false;
                                }
                                // day increament will take care of added hours, now make hours normal
                                strSubSubSplit[0] = Convert.ToString(Convert.ToInt16(strSubSubSplit[0]) - 24);
                            }
                            // if frames have to be doubled; double them
                            if(blDoubleFrames)
                            {
                                strSubSubSplit[3]=Convert.ToString(Convert.ToInt16(strSubSubSplit[3])*2);
                            }

                            tblLog.Rows.Add(strArray[7], strArray[2], strArray[3], strArray[5], strArray[6], 
                                dtStartLog.ToString("yyyy-MM-dd"),
                                strSubSubSplit[0]+":"+ strSubSubSplit[1] + ":" + strSubSubSplit[2] + ":" + strSubSubSplit[3]);
                        }
                    }
                }
                iCount = tblLog.Rows.Count;
            }
        }
        // this is first function called which loads the row data for all the rest of the calls
        public string getEventID(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return "urn:uuid:"+ dRow["EventID"].ToString();
        }
        public string getHouseNumber(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["HouseNumber"].ToString();
        }
        public string getName(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["Name"].ToString();
        }
        public string getSOM(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["SOM"].ToString();
        }
        public string getEOM(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["EOM"].ToString();
        }
        public string getStartDate(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["StartDate"].ToString();
        }
        public string getStartTime(int iRow)
        {
            dRow = (DataRow)tblLog.Rows[iRow];
            return dRow["StartTime"].ToString();
        }


    }
}
