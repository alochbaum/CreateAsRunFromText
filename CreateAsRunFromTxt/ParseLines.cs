using System;
using System.Collections.Generic;
using System.Data;
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
        public string strDateToFind { get; set; }
        public int iCount { get; set; }
        public ParseLines(string strFileName)
        {
            tblLog.Columns.Add("EventID", typeof(string)); // first [7]
            tblLog.Columns.Add("HouseNumber", typeof(string)); //third [2]
            tblLog.Columns.Add("Name", typeof(string)); //fourth [3]
            tblLog.Columns.Add("SOM", typeof(string)); //fifth [5]
            tblLog.Columns.Add("EOM", typeof(string)); //sixth [6]
            tblLog.Columns.Add("StartDate", typeof(string)); //ninth A [4]*
            tblLog.Columns.Add("StartTime", typeof(string)); //ninth B [4]*
            using (TextReader reader = File.OpenText(strFileName))
            {
                string strLine = "";
                // Read line by line
                while ((strLine = reader.ReadLine()) != null)
                {
                    string[] strArray = strLine.Split('|');
                    if (strArray.Count() == 9)
                    {
                        // continue only if type is "Video Clip" or "Live"
                        if (strArray[1] == "Video Clip" || strArray[1] == "Live")
                        {
                            tblLog.Rows.Add(strArray[7], strArray[2], strArray[3], strArray[5], strArray[6], strArray[4], strArray[4]);
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
