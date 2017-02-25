using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAsRunFromTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // changes of form title has to happen after initialization
            this.Text = this.Text + " version " +
                Application.ProductVersion.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbDirectory.Text = Properties.Settings.Default.strDir;
            tbSchedule.Text = Properties.Settings.Default.strSched;
            tbTextFile.Text = Properties.Settings.Default.strTextFile;
            nUpDnOffset.Value = Properties.Settings.Default.dUpDown;
            log2screen("Program starting");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.strDir = tbDirectory.Text;
            Properties.Settings.Default.strSched = tbSchedule.Text;
            Properties.Settings.Default.strTextFile = tbTextFile.Text;
            Properties.Settings.Default.dUpDown = nUpDnOffset.Value;
            Properties.Settings.Default.Save();
        }

        private void btnBuildAll_Click(object sender, EventArgs e)
        {
            rtbLogging.Clear();
            log2screen("Button Build All Clicked");
            //ParseTxtLog myParseText = new ParseTxtLog("11/2/2016");
            ParseTxtLog myParseText = new ParseTxtLog();
            log2screen("Started Building BXF Log: " + tbSchedule.Text + " with version " +
                Application.ProductVersion.ToString());
            if (myParseText.WriteAsRunFile(tbTextFile.Text, tbSchedule.Text, this, cbDoubleFrames.Checked))
            {
                log2screen("Writing As Run Returned: True");
                if (cbHTMLPage.Checked)
                {
                    cTransformXML myXLS = new cTransformXML();
                    string strWriteFile = Path.GetDirectoryName(tbTextFile.Text) + "\\BXF_Automation_" +
                     Path.GetFileNameWithoutExtension(tbSchedule.Text) + ".xml";
                    string strTemp = myXLS.doTransform(strWriteFile, nUpDnOffset.Value);
                    log2screen("Transfor returned: " + strTemp);
                    if (strTemp.Contains("No error writing ") && cbOpenHTML.Checked)
                    {
                        System.Diagnostics.Process.Start(strTemp.Substring(17));
                    }
                }
            }
            else log2screen("Error Creating As Run");

        }// End funxtion btnBuildAll

        private void btnSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbDirectory.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbDirectory.Text = folderBrowserDialog1.SelectedPath;
                log2screen("Set directory " + tbDirectory.Text);
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                log2screen("Files found: " + files.Length.ToString());
            }
        }

        public void log2screen (string strIn,int ierror = 0)
        {
            if (ierror==0)
            {
                rtbLogging.SelectionColor = Color.DarkBlue;
                rtbLogging.AppendText(DateTime.Now + " ");
                rtbLogging.SelectionColor = Color.Black;
                rtbLogging.AppendText(strIn + "\r\n");
                rtbLogging.ScrollToCaret();
            } else
            {
                rtbLogging.SelectionColor = Color.DarkBlue;
                rtbLogging.AppendText(DateTime.Now + " ");
                rtbLogging.SelectionColor = Color.DarkRed;
                rtbLogging.AppendText(strIn + "\r\n");
                rtbLogging.ScrollToCaret();
            }
        }


        private void btnSelectSchedule_Click(object sender, EventArgs e)
        {
            // load directory if exist
            if(tbDirectory.Text.Length >3) openFileDialog1.InitialDirectory = tbDirectory.Text;
            // set file filter
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                tbSchedule.Text = openFileDialog1.FileName;
            }
        }

        private void btnSelectTextFile_Click(object sender, EventArgs e)
        {
            // load directory if exist
            if (tbDirectory.Text.Length > 3) openFileDialog1.InitialDirectory = tbDirectory.Text;
            // set file filter
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                tbTextFile.Text = openFileDialog1.FileName;
            }
        }

        private void cbSaveLog_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                rtbLogging.SaveFile(saveFile1.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }
    }
}
