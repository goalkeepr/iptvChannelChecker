namespace iptvChannelChecker
{
    partial class frmMain
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
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.prgProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(13, 14);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(417, 22);
            this.txtInputFile.TabIndex = 0;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(436, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(97, 25);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.Text = "Input File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(436, 40);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(97, 25);
            this.btnOutputFile.TabIndex = 3;
            this.btnOutputFile.Text = "Output File";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.BtnOutputFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(13, 42);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(417, 22);
            this.txtOutputFile.TabIndex = 2;
            // 
            // prgProgressBar
            // 
            this.prgProgressBar.Location = new System.Drawing.Point(13, 124);
            this.prgProgressBar.Name = "prgProgressBar";
            this.prgProgressBar.Size = new System.Drawing.Size(417, 23);
            this.prgProgressBar.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(436, 122);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(97, 25);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(330, 150);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(100, 14);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "0 / 0 (0%)";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 193);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.prgProgressBar);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtInputFile);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "IPTV Channel Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.ProgressBar prgProgressBar;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblProgress;
    }
}

