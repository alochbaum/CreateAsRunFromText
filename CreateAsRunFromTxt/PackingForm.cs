using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAsRunFromTxt
{
    public partial class PackingForm : Form
    {
        private string strPath =@"c:\";
        public PackingForm()
        {
            InitializeComponent();
        }
        public void SetDirs(string strHtml,string strBxf, string strRoot)
        {
            tbBxfDir.Text = strBxf;
            tbHtmlDir.Text = strHtml;
            strPath = strRoot;
        }
        public string getBxf() { return tbBxfDir.Text; }
        public string getHtml() { return tbHtmlDir.Text; }

        private void btnSetHtml_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = strPath;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbHtmlDir.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void btnSetBxf_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = strPath;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbBxfDir.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbWarnNotEmpty.Checked)
            {

                // Warn if directories aren't empty, but first check if they exist
                if(Directory.Exists(tbBxfDir.Text)&&
                   Directory.EnumerateFiles(tbBxfDir.Text).Any())
                    MessageBox.Show(tbBxfDir.Text + " is not empty");
                if (Directory.Exists(tbBxfDir.Text) &&
                    Directory.EnumerateFiles(tbHtmlDir.Text).Any())
                    MessageBox.Show(tbHtmlDir.Text + " is not empty");
            }
        }
    }
}
