using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAsRunFromTxt
{
    enum mode4time
    {
        None,
        UseTextFile,
        UseScheduleHeader,
    };
    public partial class Form1 : Form
    {
        private bool blFirstTimeRun = true;
        private mode4time timemode = mode4time.None;
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
            cbConfirm.Checked = Properties.Settings.Default.blConfirm;
            cbDoubleFrames.Checked = Properties.Settings.Default.blDouble;
            cbHTMLPage.Checked = Properties.Settings.Default.blHTML;
            cbDontCheckLive.Checked = Properties.Settings.Default.blDontLIve;
            cbDontComment.Checked = Properties.Settings.Default.blDontComment;
            cbDontSort.Checked = Properties.Settings.Default.blDontSort;
            cbCorrectDate.Checked = Properties.Settings.Default.blCorrectDate;
            rbCorrectSource.Checked = Properties.Settings.Default.blFirstInText;
            log2screen("Program starting");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.strDir = tbDirectory.Text;
            Properties.Settings.Default.strSched = tbSchedule.Text;
            Properties.Settings.Default.strTextFile = tbTextFile.Text;
            Properties.Settings.Default.dUpDown = nUpDnOffset.Value;
            Properties.Settings.Default.blConfirm = cbConfirm.Checked;
            Properties.Settings.Default.blDouble = cbDoubleFrames.Checked;
            Properties.Settings.Default.blHTML = cbHTMLPage.Checked;
            Properties.Settings.Default.blDontLIve = cbDontCheckLive.Checked;
            Properties.Settings.Default.blDontComment = cbDontComment.Checked;
            Properties.Settings.Default.blDontSort = cbDontSort.Checked;
            Properties.Settings.Default.blCorrectDate = cbCorrectDate.Checked;
            Properties.Settings.Default.blFirstInText = rbCorrectSource.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnBuildAll_Click(object sender, EventArgs e)
        {
            if(blFirstTimeRun&& cbConfirm.Checked)
            {
                blFirstTimeRun = false;
                DialogResult result1 = MessageBox.Show("Time offset is set at " + nUpDnOffset.Value.ToString() + " (No will escape to change)"
                    , "First Time Question (it will not repeat)",
                    MessageBoxButtons.YesNo);
                if (result1 == DialogResult.No) return;
            };
            rtbLogging.Clear();
            log2screen("Button Build All Clicked");
            CreateAsRun myParseText = new CreateAsRun();
            log2screen("Started Building BXF Log: " + tbSchedule.Text + " with version " +
                Application.ProductVersion.ToString());
            if (cbCorrectDate.Checked)
            {
                if (rbCorrectSource.Checked) timemode = mode4time.UseTextFile;
                else timemode = mode4time.UseScheduleHeader;
            }
            else timemode = mode4time.None;
            if (myParseText.WriteAsRunFile(tbTextFile.Text, tbSchedule.Text, tbOptTextFile.Text, this, timemode))
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

        public void log2screen (string strIn,int ierror = 0)
        {
            if (ierror==0)
            {
                rtbLogging.SelectionColor = Color.DarkBlue;
                rtbLogging.AppendText(DateTime.Now + " ");
                rtbLogging.SelectionColor = Color.DarkGray;
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

        private void btnClearOpt_Click(object sender, EventArgs e)
        {
            tbOptTextFile.Text = "";
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

        private void btnSelectOptTextFile_Click(object sender, EventArgs e)
        {
            // load directory if exist
            if (tbDirectory.Text.Length > 3) openFileDialog1.InitialDirectory = tbDirectory.Text;
            // set file filter
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                tbOptTextFile.Text = openFileDialog1.FileName;
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
        // added for 2.0 ParseTxtLog check for wiping out UUIDs
        public bool getCBSub(){ return cbSub.Checked; }
        // added for 2.0 ParseTxtLog check for wiping out UUIDs
        public bool getCBDont() { return cbDontCheckLive.Checked; }
        // added for dont comment
        public bool getCBDontComm() { return cbDontComment.Checked; }
        // added for parse lines
        public bool getCBDouble() { return cbDoubleFrames.Checked; }
        // added for sorting
        public bool getCBDontSort() { return cbDontSort.Checked; }

        #region dragdrop for textboxes
        // this function and DragOver function must be enabled to make this work
        private void tbDirectory_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                string strTemp = files[0];
                tbDirectory.Text = System.IO.Path.GetDirectoryName(strTemp);
            }
        }

        // this function and DragDrop function must be enabled to make this work
        private void tbDirectory_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tbSchedule_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                tbSchedule.Text = files[0];
            }
        }

        private void tbTextFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                tbTextFile.Text = files[0];
            }
        }

        private void tbOptTextFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                tbOptTextFile.Text = files[0];
            }
        }
        #endregion

        private void btnPackAndShip_Click(object sender, EventArgs e)
        {
            // Get Results from form
            PackingForm m_PackingF = new PackingForm();
            m_PackingF.SetDirs(tbDirectory.Text + "\\human readable " +
                Path.GetFileNameWithoutExtension(tbTextFile.Text), tbDirectory.Text + "\\BXF for " +
                Path.GetFileNameWithoutExtension(tbTextFile.Text),tbDirectory.Text);
            DialogResult pformResult = m_PackingF.ShowDialog();
            if (pformResult == DialogResult.OK)
            {
                // Older versions of this program had errror
                try
                {
                    // Put all bin files in root directory into directory.
                    // ... This is case-insensitive.
                    string[] arrayOfFiles = Directory.GetFiles(tbDirectory.Text, "*.HTM");
                    string strHtmlDir = m_PackingF.getHtml();
                    if (!Directory.Exists(strHtmlDir))
                    {
                        if (arrayOfFiles.Length > 0)
                        {
                            Directory.CreateDirectory(strHtmlDir);
                            foreach (string FileName in arrayOfFiles)
                            {
                                File.Move(FileName, strHtmlDir + "\\" + Path.GetFileName(FileName));
                            }
                            string strZipName = strHtmlDir + ".zip";
                            ZipFile.CreateFromDirectory(strHtmlDir, strZipName);
                            log2screen("Created " + strZipName + " with all the html files");
                        }
                        else log2screen("Didn't find any HTML files");
                    }
                    else
                    {
                        log2screen("Didn't create directory, because " +
                        strHtmlDir + " already exists, or move files to it!");
                    }
                    string[] arrayOfBFiles = Directory.GetFiles(tbDirectory.Text, "BXF_A*.xml");

                    string strBXFDir = m_PackingF.getBxf();
                    if (!Directory.Exists(strBXFDir))
                    {
                        if (arrayOfBFiles.Length > 0)
                        {
                            Directory.CreateDirectory(strBXFDir);
                            foreach (string FileNameB in arrayOfBFiles)
                            {
                                File.Move(FileNameB, strBXFDir + "\\" + Path.GetFileName(FileNameB));
                            }
                            string strZipName = tbDirectory.Text + "\\BXF for " +
                                Path.GetFileNameWithoutExtension(tbTextFile.Text) + ".zip";
                            ZipFile.CreateFromDirectory(strBXFDir, strZipName);

                            log2screen("Created " + strZipName + " with all the BXF files");
                        }
                        else log2screen("Didn't find any BXF_A*.xml files");
                    }
                    else
                    {
                        log2screen("Didn't create directory, because " +
                        strBXFDir + " already exists, or move files to it!");
                    }
                }
                catch(Exception ex)
                {
                    log2screen($"Error: {ex.Message}", 1);
                }
            }
        }

    }
}
