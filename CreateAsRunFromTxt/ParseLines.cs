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
        private DataTable sortedDT = new DataTable();
        private DataRow dRow;
        private DateTime dtStartLog = Convert.ToDateTime("09/25/1991 00:00:50.42");
        private Form1 myForm1;  // moving around the different functions
        private bool blDontMakeComment = false;  // I'm thinking saving this local will save some speed
        private bool blDoingOldTime = false;  // holds the type of time in native As Run
        private bool blDoubleFrames = false;  // moved this out of parameter string pass
        private bool blFirstLine = true;  // moved this out of subroutine
        public string strDateToFind { get; set; }
        public int iCount { get; set; }
        public ParseLines(string strFileName, string strOptFileName,  Form1 objF)
        {
            // setting pointer for other functions
            myForm1 = objF;
            blDontMakeComment = myForm1.getCBDontComm();
            blDoubleFrames = myForm1.getCBDouble();
            tblLog.Columns.Add("EventID", typeof(string)); // first [7]
            tblLog.Columns.Add("HouseNumber", typeof(string)); //third [2]
            tblLog.Columns.Add("Name", typeof(string)); //fourth [3]
            tblLog.Columns.Add("Duration", typeof(string)); //fourth [4]
            tblLog.Columns.Add("SOM", typeof(string)); //fifth [5]
            tblLog.Columns.Add("EOM", typeof(string)); //sixth [6]
            tblLog.Columns.Add("StartDate", typeof(string)); //ninth A [0]* Needs split
            tblLog.Columns.Add("StartTime", typeof(string)); //ninth B [0]* Needs split and convert
            tblLog.Columns.Add("Type", typeof(string)); //added for comments

            try
            {
                using (TextReader reader = File.OpenText(strFileName))
                {
                    string strLine = "";
                    blFirstLine = true;
                    // Read line by line primary text file
                    while ((strLine = reader.ReadLine()) != null)
                    {
                        addrow2table(strLine);
                    }
                }
            }
            catch (IOException e)
            {
                objF.log2screen("Error: parsing non-optional text file " + e.ToString(), 1);
            }

            if(File.Exists(strOptFileName))
            {
                objF.log2screen("Found optional 2nd text file " +strOptFileName);
                try
                {
                    using (TextReader reader2 = File.OpenText(strOptFileName))
                    {
                        string strLine = "";
                        blFirstLine = true;
                        // Read line by line primary text file
                        while ((strLine = reader2.ReadLine()) != null)
                        {
                            addrow2table(strLine);
                        }
                    }
                }
                catch (IOException e)
                {
                    objF.log2screen("Error: parsing optional text file " + e.ToString(), 1);
                }
            }
            DataView dv = tblLog.DefaultView;
            if(!(objF.getCBDontSort())) dv.Sort = "StartDate, StartTime ASC";
            sortedDT = dv.ToTable();
            iCount = sortedDT.Rows.Count;
        }
        private void addrow2table(string strInLine)
        {
            string[] strArray = strInLine.Split('|');
            if (strArray.Count() == 9)
            {
                // parse the first sub string to get starting date, then hour. 12/45/7890-hh
                string[] strSubSplit = strArray[0].Split('-');
                // Not sure if this will work internationally
                if (!DateTime.TryParseExact(strSubSplit[0], "M/d/yyyy",
                    CultureInfo.CurrentCulture, DateTimeStyles.None, out dtStartLog))
                {
                    // failure to read date break the loop
                    return;
                }

                // Need to set type of time in text file, but only need to do it once for non-comments
                if (blFirstLine && strArray[1] != "Comment")
                {
                        blFirstLine = false;
                        blDoingOldTime = blIsOldTime(strArray[0]);
                }

                // Fix the time this will also fix computed date if over 24 hours
                if (blDoingOldTime) strArray[0] = ConvertOldTime2New(strSubSplit[1]);
                else strArray[0] = ConvertNewTime(strSubSplit[1]);

                // continue only if type is "Video Clip" or "Live" 1.x series, 
                // "Comment has new time format so process it later.
                if (strArray[1] == "Video Clip" || strArray[1] == "Live")
                {
                    // The final passed type is corrected to "Primary" in the ParseTxtLogs class 2.x series 
                    tblLog.Rows.Add(strArray[7], strArray[2], strArray[3], fixDot(strArray[4]), fixDot(strArray[5]),
                        fixDot(strArray[6]),
                        dtStartLog.ToString("yyyy-MM-dd"), strArray[0], strArray[1]);

                } // end of "Video Clip" or "live"  processing
                  // for 2.x added Logo and GPI
                else if (strArray[1] == "Logo" || strArray[1] == "GPI")
                {
                    tblLog.Rows.Add(strArray[7], strArray[2], strArray[3], fixDot(strArray[4]), fixDot(strArray[5]),
                        fixDot(strArray[6]),
                        dtStartLog.ToString("yyyy-MM-dd"), strArray[0], "NonPrimary");
                }
                else
                {
                    if (strArray[1] == "Comment" && !blDontMakeComment)
                    {
                        // uuid [7] has comment with ' characters or "
                        strArray[7] = strArray[7].Replace('\'', '`');
                        strArray[7] = strArray[7].Replace('"', '`');
                        // Version 1.1.5 EventID, House number, Name,Duration,SOM,EOM,StartDate,StartTime,Type
                        tblLog.Rows.Add("", "NULL", strArray[7], fixDot(strArray[4]), fixDot(strArray[5]),
                        fixDot(strArray[6]),
                         dtStartLog.ToString("yyyy-MM-dd"), strArray[0], "Comment");
                    }
                    else
                        myForm1.log2screen("Text file has non-processed type of: " + strArray[1] + " @ " + strArray[0]);
                }
            } // end of if statement on array count
        }
        // this is first function called which loads the row data for all the rest of the calls
        public string getEventID(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            // added this to prevent problem with missing uuids
            if (dRow["EventID"].ToString().Length < 5) return "";
            return "urn:uuid:"+ dRow["EventID"].ToString();
        }
        public string getHouseNumber(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["HouseNumber"].ToString();
        }
        public string getName(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["Name"].ToString();
        }
        public string getDuration(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["Duration"].ToString();
        }
        public string getSOM(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["SOM"].ToString();
        }
        public string getEOM(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["EOM"].ToString();
        }
        public string getStartDate(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["StartDate"].ToString();
        }
        public string getStartTime(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["StartTime"].ToString();
        }
        public string getType(int iRow)
        {
            dRow = (DataRow)sortedDT.Rows[iRow];
            return dRow["Type"].ToString();
        }
        //
        // This function takes in old time format hh:MM:ss.uuu and converts 
        // to new time format of hh:MM:ss.ff where ff is 30 frames per second
        // Then it calls the convert hour function
        //
        private string ConvertOldTime2New(string strIn)
        {
            string[] strConvert = strIn.Split('.');
            //confirming it is old time format
            if (strConvert[1].Length > 2)
            {
                Int64 iTemp = Convert.ToInt64(strConvert[1]);
                if(blDoubleFrames) iTemp = iTemp / (Int64)66;
                else iTemp = iTemp / (Int64)33;
                strIn = strConvert[0] + ":" + iTemp.ToString("00");
            }
            return ConvertOver24Time(strIn);
        }
        //
        // This function takes hh:MM:ss.ff converts to hh:MM:ss:ff and calls hour function
        //
        private string ConvertNewTime(string strIn)
        {
            // converting time from hh:MM:ss.frame to hh:MM:ss:frame for SMPTE time in XML
            strIn = strIn.Replace('.', ':');
            return ConvertOver24Time(strIn);
        }
        //
        // This function checks for hours over 24 and if it finds that value, it increments date and subtracts 24
        //
        private string ConvertOver24Time(string strIn)
        {
            // splitting time after replace for frame doubling calc on frames
            string[] strSubSubSplit = strIn.Split(':');
            if (Convert.ToInt16(strSubSubSplit[0]) > 23)
            {
                // day increament will take care of added hours, now make hours normal
                dtStartLog = dtStartLog.AddDays(1);
                Int64 iTemp = Convert.ToInt64(strSubSubSplit[0]);
                iTemp -= 24;
                strSubSubSplit[0] = iTemp.ToString("00");
            }
            return strSubSubSplit[0] + ":" + strSubSubSplit[1] + ":" + strSubSubSplit[2] + ":" + strSubSubSplit[3];

        }
        // This function checks for old time format hh:MM:ss.uuu by counting
        // the uuu substring length
        //
        private bool blIsOldTime(string strIn)
        {
            // added this code for Dan Myers TXT file with frames
            if (strIn.IndexOf('.') > 0)
            {
                string[] strConvert = strIn.Split('.');
                if (strConvert[1].Length > 2) return true;
                else return false;
            }
            return false;
        }
        //
        // function replaces . with : in sent string
        //
        private string fixDot(string strIn)
        {
            return strIn.Replace('.', ':');
        }
    }
}
