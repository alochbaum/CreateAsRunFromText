using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        

    }
}
