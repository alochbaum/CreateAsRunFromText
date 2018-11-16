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
            this.nUpDnOffset = new System.Windows.Forms.NumericUpDown();
            this.cbHTMLPage = new System.Windows.Forms.CheckBox();
            this.cbOpenHTML = new System.Windows.Forms.CheckBox();
            this.cbSaveLog = new System.Windows.Forms.Button();
            this.cbSub = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDontCheckLive = new System.Windows.Forms.CheckBox();
            this.btnSelectOptTextFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOptTextFile = new System.Windows.Forms.TextBox();
            this.cbConfirm = new System.Windows.Forms.CheckBox();
            this.btnClearOpt = new System.Windows.Forms.Button();
            this.cbDontComment = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbTimeInSchedule = new System.Windows.Forms.RadioButton();
            this.rbCorrectSource = new System.Windows.Forms.RadioButton();
            this.cbCorrectDate = new System.Windows.Forms.CheckBox();
            this.cbDontSort = new System.Windows.Forms.CheckBox();
            this.btnPackAndShip = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnOffset)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDirectory);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(953, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "(Optional) Default Directory to use for selection buttons next to Schedule and Te" +
    "xt Files. (BXF schedules from traffic systems end with .XML)";
            // 
            // tbDirectory
            // 
            this.tbDirectory.AllowDrop = true;
            this.tbDirectory.Location = new System.Drawing.Point(150, 22);
            this.tbDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(798, 22);
            this.tbDirectory.TabIndex = 1;
            this.tbDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbDirectory_DragDrop);
            this.tbDirectory.DragOver += new System.Windows.Forms.DragEventHandler(this.tbDirectory_DragOver);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(7, 21);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(138, 26);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "select folder -->";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnBuildAll
            // 
            this.btnBuildAll.Location = new System.Drawing.Point(13, 70);
            this.btnBuildAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuildAll.Name = "btnBuildAll";
            this.btnBuildAll.Size = new System.Drawing.Size(192, 53);
            this.btnBuildAll.TabIndex = 1;
            this.btnBuildAll.Text = "Create BXF As Run Log (Please set files-> first)";
            this.btnBuildAll.UseVisualStyleBackColor = true;
            this.btnBuildAll.Click += new System.EventHandler(this.btnBuildAll_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(15, 333);
            this.rtbLogging.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(946, 283);
            this.rtbLogging.TabIndex = 2;
            this.rtbLogging.Text = "";
            // 
            // tbSchedule
            // 
            this.tbSchedule.AllowDrop = true;
            this.tbSchedule.Location = new System.Drawing.Point(284, 69);
            this.tbSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(626, 22);
            this.tbSchedule.TabIndex = 3;
            this.tbSchedule.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbSchedule_DragDrop);
            this.tbSchedule.DragOver += new System.Windows.Forms.DragEventHandler(this.tbDirectory_DragOver);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "schedule";
            // 
            // btnSelectSchedule
            // 
            this.btnSelectSchedule.Location = new System.Drawing.Point(920, 68);
            this.btnSelectSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectSchedule.Name = "btnSelectSchedule";
            this.btnSelectSchedule.Size = new System.Drawing.Size(41, 25);
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
            this.cbDoubleFrames.Location = new System.Drawing.Point(9, 90);
            this.cbDoubleFrames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDoubleFrames.Name = "cbDoubleFrames";
            this.cbDoubleFrames.Size = new System.Drawing.Size(190, 21);
            this.cbDoubleFrames.TabIndex = 6;
            this.cbDoubleFrames.Text = "x2 Frames (posible 720p)";
            this.cbDoubleFrames.UseVisualStyleBackColor = true;
            // 
            // tbTextFile
            // 
            this.tbTextFile.AllowDrop = true;
            this.tbTextFile.Location = new System.Drawing.Point(284, 100);
            this.tbTextFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTextFile.Name = "tbTextFile";
            this.tbTextFile.Size = new System.Drawing.Size(626, 22);
            this.tbTextFile.TabIndex = 3;
            this.tbTextFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbTextFile_DragDrop);
            this.tbTextFile.DragOver += new System.Windows.Forms.DragEventHandler(this.tbDirectory_DragOver);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "text file";
            // 
            // btnSelectTextFile
            // 
            this.btnSelectTextFile.Location = new System.Drawing.Point(920, 98);
            this.btnSelectTextFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectTextFile.Name = "btnSelectTextFile";
            this.btnSelectTextFile.Size = new System.Drawing.Size(41, 28);
            this.btnSelectTextFile.TabIndex = 5;
            this.btnSelectTextFile.Text = "...";
            this.btnSelectTextFile.UseVisualStyleBackColor = true;
            this.btnSelectTextFile.Click += new System.EventHandler(this.btnSelectTextFile_Click);
            // 
            // nUpDnOffset
            // 
            this.nUpDnOffset.Location = new System.Drawing.Point(398, 17);
            this.nUpDnOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.nUpDnOffset.Size = new System.Drawing.Size(50, 22);
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
            this.cbHTMLPage.Location = new System.Drawing.Point(37, 28);
            this.cbHTMLPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbHTMLPage.Name = "cbHTMLPage";
            this.cbHTMLPage.Size = new System.Drawing.Size(151, 21);
            this.cbHTMLPage.TabIndex = 9;
            this.cbHTMLPage.Text = "Create HMTL Page";
            this.cbHTMLPage.UseVisualStyleBackColor = true;
            // 
            // cbOpenHTML
            // 
            this.cbOpenHTML.AutoSize = true;
            this.cbOpenHTML.Checked = true;
            this.cbOpenHTML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenHTML.Location = new System.Drawing.Point(204, 28);
            this.cbOpenHTML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOpenHTML.Name = "cbOpenHTML";
            this.cbOpenHTML.Size = new System.Drawing.Size(265, 21);
            this.cbOpenHTML.TabIndex = 9;
            this.cbOpenHTML.Text = "Open HTML in Browser after creating";
            this.cbOpenHTML.UseVisualStyleBackColor = true;
            // 
            // cbSaveLog
            // 
            this.cbSaveLog.Location = new System.Drawing.Point(464, 303);
            this.cbSaveLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSaveLog.Name = "cbSaveLog";
            this.cbSaveLog.Size = new System.Drawing.Size(219, 26);
            this.cbSaveLog.TabIndex = 10;
            this.cbSaveLog.Text = "save log shown below (optional)";
            this.cbSaveLog.UseVisualStyleBackColor = true;
            this.cbSaveLog.Click += new System.EventHandler(this.cbSaveLog_Click);
            // 
            // cbSub
            // 
            this.cbSub.AutoSize = true;
            this.cbSub.Checked = true;
            this.cbSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSub.Location = new System.Drawing.Point(9, 25);
            this.cbSub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(354, 21);
            this.cbSub.TabIndex = 9;
            this.cbSub.Text = "Substitute when UUID doesn\'t match house number";
            this.cbSub.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(392, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter hour: -5 (for EST) -4 (EDT) -6 (CST) -8 (PST) -7 (PDT)";
            // 
            // cbDontCheckLive
            // 
            this.cbDontCheckLive.AutoSize = true;
            this.cbDontCheckLive.Checked = true;
            this.cbDontCheckLive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDontCheckLive.Location = new System.Drawing.Point(9, 46);
            this.cbDontCheckLive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDontCheckLive.Name = "cbDontCheckLive";
            this.cbDontCheckLive.Size = new System.Drawing.Size(400, 21);
            this.cbDontCheckLive.TabIndex = 9;
            this.cbDontCheckLive.Text = "Don\'t check UUID matching house numbers on Live events";
            this.cbDontCheckLive.UseVisualStyleBackColor = true;
            // 
            // btnSelectOptTextFile
            // 
            this.btnSelectOptTextFile.Location = new System.Drawing.Point(920, 138);
            this.btnSelectOptTextFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectOptTextFile.Name = "btnSelectOptTextFile";
            this.btnSelectOptTextFile.Size = new System.Drawing.Size(41, 28);
            this.btnSelectOptTextFile.TabIndex = 13;
            this.btnSelectOptTextFile.Text = "...";
            this.btnSelectOptTextFile.UseVisualStyleBackColor = true;
            this.btnSelectOptTextFile.Click += new System.EventHandler(this.btnSelectOptTextFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "(Optional) text file from other FW";
            // 
            // tbOptTextFile
            // 
            this.tbOptTextFile.AllowDrop = true;
            this.tbOptTextFile.Location = new System.Drawing.Point(284, 140);
            this.tbOptTextFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOptTextFile.Name = "tbOptTextFile";
            this.tbOptTextFile.Size = new System.Drawing.Size(626, 22);
            this.tbOptTextFile.TabIndex = 11;
            this.tbOptTextFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbOptTextFile_DragDrop);
            this.tbOptTextFile.DragOver += new System.Windows.Forms.DragEventHandler(this.tbDirectory_DragOver);
            // 
            // cbConfirm
            // 
            this.cbConfirm.AutoSize = true;
            this.cbConfirm.Checked = true;
            this.cbConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConfirm.Location = new System.Drawing.Point(19, 38);
            this.cbConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbConfirm.Name = "cbConfirm";
            this.cbConfirm.Size = new System.Drawing.Size(415, 21);
            this.cbConfirm.TabIndex = 6;
            this.cbConfirm.Text = "Confirm offset in the above section during first create session";
            this.cbConfirm.UseVisualStyleBackColor = true;
            // 
            // btnClearOpt
            // 
            this.btnClearOpt.Location = new System.Drawing.Point(229, 138);
            this.btnClearOpt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearOpt.Name = "btnClearOpt";
            this.btnClearOpt.Size = new System.Drawing.Size(53, 28);
            this.btnClearOpt.TabIndex = 14;
            this.btnClearOpt.Text = "clear";
            this.btnClearOpt.UseVisualStyleBackColor = true;
            this.btnClearOpt.Click += new System.EventHandler(this.btnClearOpt_Click);
            // 
            // cbDontComment
            // 
            this.cbDontComment.AutoSize = true;
            this.cbDontComment.Location = new System.Drawing.Point(9, 68);
            this.cbDontComment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDontComment.Name = "cbDontComment";
            this.cbDontComment.Size = new System.Drawing.Size(251, 21);
            this.cbDontComment.TabIndex = 9;
            this.cbDontComment.Text = "Don\'t include comment lines in BXF";
            this.cbDontComment.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nUpDnOffset);
            this.groupBox2.Controls.Add(this.cbConfirm);
            this.groupBox2.Location = new System.Drawing.Point(20, 56);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(460, 62);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UTC offset in HTML for local time";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbTimeInSchedule);
            this.groupBox3.Controls.Add(this.rbCorrectSource);
            this.groupBox3.Controls.Add(this.cbCorrectDate);
            this.groupBox3.Controls.Add(this.cbDontSort);
            this.groupBox3.Controls.Add(this.cbSub);
            this.groupBox3.Controls.Add(this.cbDontCheckLive);
            this.groupBox3.Controls.Add(this.cbDontComment);
            this.groupBox3.Controls.Add(this.cbDoubleFrames);
            this.groupBox3.Location = new System.Drawing.Point(21, 171);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(437, 146);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BXF Options";
            // 
            // rbTimeInSchedule
            // 
            this.rbTimeInSchedule.AutoSize = true;
            this.rbTimeInSchedule.Location = new System.Drawing.Point(215, 119);
            this.rbTimeInSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTimeInSchedule.Name = "rbTimeInSchedule";
            this.rbTimeInSchedule.Size = new System.Drawing.Size(214, 21);
            this.rbTimeInSchedule.TabIndex = 13;
            this.rbTimeInSchedule.Text = "Use schedule time (2 txt files)";
            this.rbTimeInSchedule.UseVisualStyleBackColor = true;
            // 
            // rbCorrectSource
            // 
            this.rbCorrectSource.AutoSize = true;
            this.rbCorrectSource.Checked = true;
            this.rbCorrectSource.Location = new System.Drawing.Point(9, 119);
            this.rbCorrectSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbCorrectSource.Name = "rbCorrectSource";
            this.rbCorrectSource.Size = new System.Drawing.Size(199, 21);
            this.rbCorrectSource.TabIndex = 12;
            this.rbCorrectSource.TabStop = true;
            this.rbCorrectSource.Text = "Use Txt file time (standard)";
            this.rbCorrectSource.UseVisualStyleBackColor = true;
            // 
            // cbCorrectDate
            // 
            this.cbCorrectDate.AutoSize = true;
            this.cbCorrectDate.Location = new System.Drawing.Point(208, 93);
            this.cbCorrectDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCorrectDate.Name = "cbCorrectDate";
            this.cbCorrectDate.Size = new System.Drawing.Size(206, 21);
            this.cbCorrectDate.TabIndex = 11;
            this.cbCorrectDate.Text = "Correct Txt File(s) start date";
            this.cbCorrectDate.UseVisualStyleBackColor = true;
            // 
            // cbDontSort
            // 
            this.cbDontSort.AutoSize = true;
            this.cbDontSort.Location = new System.Drawing.Point(275, 68);
            this.cbDontSort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDontSort.Name = "cbDontSort";
            this.cbDontSort.Size = new System.Drawing.Size(135, 21);
            this.cbDontSort.TabIndex = 10;
            this.cbDontSort.Text = "Don\'t Sort Times";
            this.cbDontSort.UseVisualStyleBackColor = true;
            // 
            // btnPackAndShip
            // 
            this.btnPackAndShip.Location = new System.Drawing.Point(688, 302);
            this.btnPackAndShip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPackAndShip.Name = "btnPackAndShip";
            this.btnPackAndShip.Size = new System.Drawing.Size(260, 26);
            this.btnPackAndShip.TabIndex = 17;
            this.btnPackAndShip.Text = "collect finished files and zip those files";
            this.btnPackAndShip.UseVisualStyleBackColor = true;
            this.btnPackAndShip.Click += new System.EventHandler(this.btnPackAndShip_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbHTMLPage);
            this.groupBox4.Controls.Add(this.cbOpenHTML);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(468, 178);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(492, 121);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HTML Creation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(972, 624);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnPackAndShip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClearOpt);
            this.Controls.Add(this.btnSelectOptTextFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbOptTextFile);
            this.Controls.Add(this.cbSaveLog);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Create BXF As Run";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDnOffset)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown nUpDnOffset;
        private System.Windows.Forms.CheckBox cbHTMLPage;
        private System.Windows.Forms.CheckBox cbOpenHTML;
        private System.Windows.Forms.Button cbSaveLog;
        private System.Windows.Forms.CheckBox cbSub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDontCheckLive;
        private System.Windows.Forms.Button btnSelectOptTextFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbOptTextFile;
        private System.Windows.Forms.CheckBox cbConfirm;
        private System.Windows.Forms.Button btnClearOpt;
        private System.Windows.Forms.CheckBox cbDontComment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbDontSort;
        private System.Windows.Forms.Button btnPackAndShip;
        private System.Windows.Forms.RadioButton rbTimeInSchedule;
        private System.Windows.Forms.RadioButton rbCorrectSource;
        private System.Windows.Forms.CheckBox cbCorrectDate;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

