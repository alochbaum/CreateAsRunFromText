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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDirectory);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1193, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directory Containing BXF schedules ending with .XML and iTX logs ending with .txt" +
    "";
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(130, 38);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(1012, 31);
            this.tbDirectory.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 30);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 40);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnBuildAll
            // 
            this.btnBuildAll.Location = new System.Drawing.Point(18, 110);
            this.btnBuildAll.Name = "btnBuildAll";
            this.btnBuildAll.Size = new System.Drawing.Size(225, 39);
            this.btnBuildAll.TabIndex = 1;
            this.btnBuildAll.Text = "Build All As Run Logs";
            this.btnBuildAll.UseVisualStyleBackColor = true;
            this.btnBuildAll.Click += new System.EventHandler(this.btnBuildAll_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(18, 176);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(1187, 339);
            this.rtbLogging.TabIndex = 2;
            this.rtbLogging.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 527);
            this.Controls.Add(this.rtbLogging);
            this.Controls.Add(this.btnBuildAll);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Create BXF As Run";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBuildAll;
        private System.Windows.Forms.RichTextBox rtbLogging;
    }
}

