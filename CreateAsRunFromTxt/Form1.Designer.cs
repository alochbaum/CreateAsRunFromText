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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDirectory);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1037, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directory Containing BXF schedules ending with .XML and iTX logs ending with .txt" +
    "";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(98, 30);
            this.tbDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(916, 26);
            this.tbDirectory.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(4, 24);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(70, 32);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnBuildAll
            // 
            this.btnBuildAll.Location = new System.Drawing.Point(14, 88);
            this.btnBuildAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildAll.Name = "btnBuildAll";
            this.btnBuildAll.Size = new System.Drawing.Size(136, 31);
            this.btnBuildAll.TabIndex = 1;
            this.btnBuildAll.Text = "Build All As Run Logs";
            this.btnBuildAll.UseVisualStyleBackColor = true;
            this.btnBuildAll.Click += new System.EventHandler(this.btnBuildAll_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(14, 181);
            this.rtbLogging.Margin = new System.Windows.Forms.Padding(2);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(1032, 305);
            this.rtbLogging.TabIndex = 2;
            this.rtbLogging.Text = "";
            // 
            // tbSchedule
            // 
            this.tbSchedule.Location = new System.Drawing.Point(327, 91);
            this.tbSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.tbSchedule.Name = "tbSchedule";
            this.tbSchedule.Size = new System.Drawing.Size(669, 26);
            this.tbSchedule.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "schedule";
            // 
            // btnSelectSchedule
            // 
            this.btnSelectSchedule.Location = new System.Drawing.Point(1013, 91);
            this.btnSelectSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectSchedule.Name = "btnSelectSchedule";
            this.btnSelectSchedule.Size = new System.Drawing.Size(33, 26);
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
            this.cbDoubleFrames.Location = new System.Drawing.Point(14, 132);
            this.cbDoubleFrames.Name = "cbDoubleFrames";
            this.cbDoubleFrames.Size = new System.Drawing.Size(213, 24);
            this.cbDoubleFrames.TabIndex = 6;
            this.cbDoubleFrames.Text = "x2 Frames (posible 720p)";
            this.cbDoubleFrames.UseVisualStyleBackColor = true;
            // 
            // tbTextFile
            // 
            this.tbTextFile.Location = new System.Drawing.Point(327, 132);
            this.tbTextFile.Margin = new System.Windows.Forms.Padding(2);
            this.tbTextFile.Name = "tbTextFile";
            this.tbTextFile.Size = new System.Drawing.Size(669, 26);
            this.tbTextFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "text file";
            // 
            // btnSelectTextFile
            // 
            this.btnSelectTextFile.Location = new System.Drawing.Point(1013, 132);
            this.btnSelectTextFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectTextFile.Name = "btnSelectTextFile";
            this.btnSelectTextFile.Size = new System.Drawing.Size(33, 26);
            this.btnSelectTextFile.TabIndex = 5;
            this.btnSelectTextFile.Text = "...";
            this.btnSelectTextFile.UseVisualStyleBackColor = true;
            this.btnSelectTextFile.Click += new System.EventHandler(this.btnSelectTextFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 497);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Create BXF As Run";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

