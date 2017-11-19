namespace CreateAsRunFromTxt
{
    partial class PackingForm
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
            this.tbHtmlDir = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetHtml = new System.Windows.Forms.Button();
            this.btnSetBxf = new System.Windows.Forms.Button();
            this.tbBxfDir = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbWarnNotEmpty = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbHtmlDir
            // 
            this.tbHtmlDir.Location = new System.Drawing.Point(6, 25);
            this.tbHtmlDir.Name = "tbHtmlDir";
            this.tbHtmlDir.Size = new System.Drawing.Size(768, 26);
            this.tbHtmlDir.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetHtml);
            this.groupBox1.Controls.Add(this.tbHtmlDir);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HTML Directory and Zip name";
            // 
            // btnSetHtml
            // 
            this.btnSetHtml.Location = new System.Drawing.Point(780, 22);
            this.btnSetHtml.Name = "btnSetHtml";
            this.btnSetHtml.Size = new System.Drawing.Size(70, 32);
            this.btnSetHtml.TabIndex = 1;
            this.btnSetHtml.Text = "...";
            this.btnSetHtml.UseVisualStyleBackColor = true;
            this.btnSetHtml.Click += new System.EventHandler(this.btnSetHtml_Click);
            // 
            // btnSetBxf
            // 
            this.btnSetBxf.Location = new System.Drawing.Point(780, 22);
            this.btnSetBxf.Name = "btnSetBxf";
            this.btnSetBxf.Size = new System.Drawing.Size(70, 32);
            this.btnSetBxf.TabIndex = 1;
            this.btnSetBxf.Text = "...";
            this.btnSetBxf.UseVisualStyleBackColor = true;
            this.btnSetBxf.Click += new System.EventHandler(this.btnSetBxf_Click);
            // 
            // tbBxfDir
            // 
            this.tbBxfDir.Location = new System.Drawing.Point(6, 25);
            this.tbBxfDir.Name = "tbBxfDir";
            this.tbBxfDir.Size = new System.Drawing.Size(768, 26);
            this.tbBxfDir.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetBxf);
            this.groupBox2.Controls.Add(this.tbBxfDir);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BXF Directory and Zip name";
            // 
            // cbWarnNotEmpty
            // 
            this.cbWarnNotEmpty.AutoSize = true;
            this.cbWarnNotEmpty.Checked = true;
            this.cbWarnNotEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWarnNotEmpty.Location = new System.Drawing.Point(18, 176);
            this.cbWarnNotEmpty.Name = "cbWarnNotEmpty";
            this.cbWarnNotEmpty.Size = new System.Drawing.Size(363, 24);
            this.cbWarnNotEmpty.TabIndex = 3;
            this.cbWarnNotEmpty.Text = "Warn if either or both the folders are not empty";
            this.cbWarnNotEmpty.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(700, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "&Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Location = new System.Drawing.Point(793, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 36);
            this.button4.TabIndex = 5;
            this.button4.Text = "&OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 224);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbWarnNotEmpty);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PackingForm";
            this.Text = "PackingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHtmlDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetHtml;
        private System.Windows.Forms.Button btnSetBxf;
        private System.Windows.Forms.TextBox tbBxfDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbWarnNotEmpty;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}