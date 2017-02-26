namespace CreateAsRunFromTxt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBuildAll = new System.Windows.Forms.Button();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.tbSchedule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectSchedule = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbDoubleFrames = new System.Windows.Forms.CheckBox();
            this.tbTextFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectTextFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nUpDnOffset = new System.Windows.Forms.NumericUpDown();
            this.cbHTMLPage = new System.Windows.Forms.CheckBox();
            this.cbOpenHTML = new System.Windows.Forms.CheckBox();
            this.cbSaveLog = new System.Windows.Forms.Button();
            this.cbSub = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDirectory);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(692, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Directory to use for selection buttons next to Schedule and Text Files, B" +
    "XF schedules from traffic system ending with .XML";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(66, 20);
            this.tbDirectory.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(612, 20);
            this.tbDirectory.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(2, 16);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(46, 21);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnBuildAll
            // 
            this.btnBuildAll.Location = new System.Drawing.Point(10, 57);
            this.btnBuildAll.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnBuildAll.Name = "btnBuildAll";
            this.btnBuildAll.Size = new System.Drawing.Size(144, 20);
            this.btnBuildAll.TabIndex = 1;
            this.btnBuildAll.Text = "Build BXF As Run Log";
            this.btnBuildAll.UseVisualStyleBackColor = true;
            this.btnBuildAll.Click += new System.EventHandler(this.btnBuildAll_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(11, 147);
            this.rtbLogging.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(684, 244);
            this.rtbLogging.TabIndex = 2;
            this.rtbLogging.Text = "";
            // 
            // tbSchedule
            // 
            this.tbSchedule.Location = new System.Drawing.Point(218, 59);
            this.tbSchedule.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(448, 20);
            this.tbSchedule.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "schedule";
            // 
            // btnSelectSchedule
            // 
            this.btnSelectSchedule.Location = new System.Drawing.Point(674, 58);
            this.btnSelectSchedule.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSelectSchedule.Name = "btnSelectSchedule";
            this.btnSelectSchedule.Size = new System.Drawing.Size(22, 17);
            this.btnSelectSchedule.TabIndex = 5;
            this.btnSelectSchedule.Text = "...";
            this.btnSelectSchedule.UseVisualStyleBackColor = true;
            this.btnSelectSchedule.Click += new System.EventHandler(this.btnSelectSchedule_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbDoubleFrames
            // 
            this.cbDoubleFrames.AutoSize = true;
            this.cbDoubleFrames.Location = new System.Drawing.Point(10, 86);
            this.cbDoubleFrames.Margin = new System.Windows.Forms.Padding(2);
            this.cbDoubleFrames.Name = "cbDoubleFrames";
            this.cbDoubleFrames.Size = new System.Drawing.Size(143, 17);
            this.cbDoubleFrames.TabIndex = 6;
            this.cbDoubleFrames.Text = "x2 Frames (posible 720p)";
            this.cbDoubleFrames.UseVisualStyleBackColor = true;
            // 
            // tbTextFile
            // 
            this.tbTextFile.Location = new System.Drawing.Point(218, 86);
            this.tbTextFile.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbTextFile.Name = "tbTextFile";
            this.tbTextFile.Size = new System.Drawing.Size(448, 20);
            this.tbTextFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "text file";
            // 
            // btnSelectTextFile
            // 
            this.btnSelectTextFile.Location = new System.Drawing.Point(674, 84);
            this.btnSelectTextFile.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSelectTextFile.Name = "btnSelectTextFile";
            this.btnSelectTextFile.Size = new System.Drawing.Size(22, 17);
            this.btnSelectTextFile.TabIndex = 5;
            this.btnSelectTextFile.Text = "...";
            this.btnSelectTextFile.UseVisualStyleBackColor = true;
            this.btnSelectTextFile.Click += new System.EventHandler(this.btnSelectTextFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "used in created HTML Pages";
            // 
            // nUpDnOffset
            // 
            this.nUpDnOffset.Location = new System.Drawing.Point(318, 116);
            this.nUpDnOffset.Margin = new System.Windows.Forms.Padding(2);
            this.nUpDnOffset.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nUpDnOffset.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.nUpDnOffset.Name = "nUpDnOffset";
            this.nUpDnOffset.Size = new System.Drawing.Size(37, 20);
            this.nUpDnOffset.TabIndex = 8;
            this.nUpDnOffset.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // cbHTMLPage
            // 
            this.cbHTMLPage.AutoSize = true;
            this.cbHTMLPage.Checked = true;
            this.cbHTMLPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHTMLPage.Location = new System.Drawing.Point(370, 110);
            this.cbHTMLPage.Margin = new System.Windows.Forms.Padding(2);
            this.cbHTMLPage.Name = "cbHTMLPage";
            this.cbHTMLPage.Size = new System.Drawing.Size(118, 17);
            this.cbHTMLPage.TabIndex = 9;
            this.cbHTMLPage.Text = "Create HMTL Page";
            this.cbHTMLPage.UseVisualStyleBackColor = true;
            // 
            // cbOpenHTML
            // 
            this.cbOpenHTML.AutoSize = true;
            this.cbOpenHTML.Checked = true;
            this.cbOpenHTML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenHTML.Location = new System.Drawing.Point(496, 110);
            this.cbOpenHTML.Margin = new System.Windows.Forms.Padding(2);
            this.cbOpenHTML.Name = "cbOpenHTML";
            this.cbOpenHTML.Size = new System.Drawing.Size(137, 17);
            this.cbOpenHTML.TabIndex = 9;
            this.cbOpenHTML.Text = "Open HTML in Browser";
            this.cbOpenHTML.UseVisualStyleBackColor = true;
            // 
            // cbSaveLog
            // 
            this.cbSaveLog.Location = new System.Drawing.Point(637, 107);
            this.cbSaveLog.Margin = new System.Windows.Forms.Padding(2);
            this.cbSaveLog.Name = "cbSaveLog";
            this.cbSaveLog.Size = new System.Drawing.Size(59, 37);
            this.cbSaveLog.TabIndex = 10;
            this.cbSaveLog.Text = "save log (optional)";
            this.cbSaveLog.UseVisualStyleBackColor = true;
            this.cbSaveLog.Click += new System.EventHandler(this.cbSaveLog_Click);
            // 
            // cbSub
            // 
            this.cbSub.AutoSize = true;
            this.cbSub.Checked = true;
            this.cbSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSub.Location = new System.Drawing.Point(370, 129);
            this.cbSub.Margin = new System.Windows.Forms.Padding(2);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(268, 17);
            this.cbSub.TabIndex = 9;
            this.cbSub.Text = "Subsitute when UUID doesn\'t match house number";
            this.cbSub.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(304, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "UTC offset as a number -5 (for EST) -4 (EDT) -8 (PST) -7 (PDT)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(706, 401);
            this.Controls.Add(this.cbSaveLog);
            this.Controls.Add(this.cbOpenHTML);
            this.Controls.Add(this.cbSub);
            this.Controls.Add(this.cbHTMLPage);
            this.Controls.Add(this.nUpDnOffset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDoubleFrames);
            this.Controls.Add(this.btnSelectTextFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectSchedule);
            this.Controls.Add(this.tbTextFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSchedule);
            this.Controls.Add(this.rtbLogging);
            this.Controls.Add(this.btnBuildAll);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Create BXF As Run";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBuildAll;
        private System.Windows.Forms.RichTextBox rtbLogging;
        private System.Windows.Forms.TextBox tbSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSchedule;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbDoubleFrames;
        private System.Windows.Forms.TextBox tbTextFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectTextFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUpDnOffset;
        private System.Windows.Forms.CheckBox cbHTMLPage;
        private System.Windows.Forms.CheckBox cbOpenHTML;
        private System.Windows.Forms.Button cbSaveLog;
        private System.Windows.Forms.CheckBox cbSub;
        private System.Windows.Forms.Label label4;
    }
}

