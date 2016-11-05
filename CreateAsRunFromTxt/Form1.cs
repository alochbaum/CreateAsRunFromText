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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.strDir = tbDirectory.Text;
            Properties.Settings.Default.Save();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = tbDirectory.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbDirectory.Text = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }
    }
}
