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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.prgProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBadChannelsCount = new System.Windows.Forms.Label();
            this.lblGoodChannelsCount = new System.Windows.Forms.Label();
            this.lblTotalChannelsCount = new System.Windows.Forms.Label();
            this.lblBadChannels = new System.Windows.Forms.Label();
            this.lblGoodChannels = new System.Windows.Forms.Label();
            this.lblTotalChecked = new System.Windows.Forms.Label();
            this.dgvChannels = new System.Windows.Forms.DataGridView();
            this.channelEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TvgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TvgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameRateInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl720x60Count = new System.Windows.Forms.Label();
            this.lbl1080x30Count = new System.Windows.Forms.Label();
            this.lbl1080x60Count = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl720x30Count = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOtherSdCount = new System.Windows.Forms.Label();
            this.lblOtherSd = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelEntryBindingSource)).BeginInit();
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
            this.btnOutputFile.Enabled = false;
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
            this.txtOutputFile.Enabled = false;
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
            this.btnGo.Location = new System.Drawing.Point(436, 123);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOtherSdCount);
            this.groupBox1.Controls.Add(this.lblOtherSd);
            this.groupBox1.Controls.Add(this.lbl720x30Count);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl720x60Count);
            this.groupBox1.Controls.Add(this.lbl1080x30Count);
            this.groupBox1.Controls.Add(this.lbl1080x60Count);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblBadChannelsCount);
            this.groupBox1.Controls.Add(this.lblGoodChannelsCount);
            this.groupBox1.Controls.Add(this.lblTotalChannelsCount);
            this.groupBox1.Controls.Add(this.lblBadChannels);
            this.groupBox1.Controls.Add(this.lblGoodChannels);
            this.groupBox1.Controls.Add(this.lblTotalChecked);
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channel Info";
            // 
            // lblBadChannelsCount
            // 
            this.lblBadChannelsCount.Location = new System.Drawing.Point(151, 46);
            this.lblBadChannelsCount.Name = "lblBadChannelsCount";
            this.lblBadChannelsCount.Size = new System.Drawing.Size(50, 14);
            this.lblBadChannelsCount.TabIndex = 5;
            this.lblBadChannelsCount.Text = "0";
            this.lblBadChannelsCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGoodChannelsCount
            // 
            this.lblGoodChannelsCount.Location = new System.Drawing.Point(151, 32);
            this.lblGoodChannelsCount.Name = "lblGoodChannelsCount";
            this.lblGoodChannelsCount.Size = new System.Drawing.Size(50, 14);
            this.lblGoodChannelsCount.TabIndex = 4;
            this.lblGoodChannelsCount.Text = "0";
            this.lblGoodChannelsCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalChannelsCount
            // 
            this.lblTotalChannelsCount.Location = new System.Drawing.Point(151, 18);
            this.lblTotalChannelsCount.Name = "lblTotalChannelsCount";
            this.lblTotalChannelsCount.Size = new System.Drawing.Size(50, 14);
            this.lblTotalChannelsCount.TabIndex = 3;
            this.lblTotalChannelsCount.Text = "0";
            this.lblTotalChannelsCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBadChannels
            // 
            this.lblBadChannels.AutoSize = true;
            this.lblBadChannels.Location = new System.Drawing.Point(17, 46);
            this.lblBadChannels.Name = "lblBadChannels";
            this.lblBadChannels.Size = new System.Drawing.Size(85, 14);
            this.lblBadChannels.TabIndex = 2;
            this.lblBadChannels.Text = "Bad Channels:";
            // 
            // lblGoodChannels
            // 
            this.lblGoodChannels.AutoSize = true;
            this.lblGoodChannels.Location = new System.Drawing.Point(17, 32);
            this.lblGoodChannels.Name = "lblGoodChannels";
            this.lblGoodChannels.Size = new System.Drawing.Size(93, 14);
            this.lblGoodChannels.TabIndex = 1;
            this.lblGoodChannels.Text = "Good Channels:";
            // 
            // lblTotalChecked
            // 
            this.lblTotalChecked.AutoSize = true;
            this.lblTotalChecked.Location = new System.Drawing.Point(17, 18);
            this.lblTotalChecked.Name = "lblTotalChecked";
            this.lblTotalChecked.Size = new System.Drawing.Size(109, 14);
            this.lblTotalChecked.TabIndex = 0;
            this.lblTotalChecked.Text = "Channels Checked:";
            // 
            // dgvChannels
            // 
            this.dgvChannels.AllowUserToAddRows = false;
            this.dgvChannels.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChannels.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvChannels.AutoGenerateColumns = false;
            this.dgvChannels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TvgId,
            this.TvgName,
            this.GroupTitle,
            this.ChannelName,
            this.Width,
            this.Height,
            this.FrameRateInt,
            this.QualityLevel,
            this.ErrorType});
            this.dgvChannels.DataSource = this.channelEntryBindingSource;
            this.dgvChannels.Location = new System.Drawing.Point(22, 292);
            this.dgvChannels.Name = "dgvChannels";
            this.dgvChannels.ReadOnly = true;
            this.dgvChannels.RowHeadersVisible = false;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChannels.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvChannels.ShowEditingIcon = false;
            this.dgvChannels.Size = new System.Drawing.Size(1012, 150);
            this.dgvChannels.TabIndex = 9;
            // 
            // TvgId
            // 
            this.TvgId.DataPropertyName = "TvgId";
            this.TvgId.HeaderText = "Tvg Id";
            this.TvgId.Name = "TvgId";
            this.TvgId.ReadOnly = true;
            // 
            // TvgName
            // 
            this.TvgName.DataPropertyName = "TvgName";
            this.TvgName.HeaderText = "Tvg Name";
            this.TvgName.Name = "TvgName";
            this.TvgName.ReadOnly = true;
            // 
            // GroupTitle
            // 
            this.GroupTitle.DataPropertyName = "GroupTitle";
            this.GroupTitle.HeaderText = "Group Title";
            this.GroupTitle.Name = "GroupTitle";
            this.GroupTitle.ReadOnly = true;
            // 
            // ChannelName
            // 
            this.ChannelName.DataPropertyName = "ChannelName";
            this.ChannelName.HeaderText = "Channel Name";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.ReadOnly = true;
            // 
            // Width
            // 
            this.Width.DataPropertyName = "Width";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Width.DefaultCellStyle = dataGridViewCellStyle14;
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            // 
            // Height
            // 
            this.Height.DataPropertyName = "Height";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Height.DefaultCellStyle = dataGridViewCellStyle15;
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            // 
            // FrameRateInt
            // 
            this.FrameRateInt.DataPropertyName = "FrameRateInt";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.FrameRateInt.DefaultCellStyle = dataGridViewCellStyle16;
            this.FrameRateInt.HeaderText = "Frame Rate";
            this.FrameRateInt.Name = "FrameRateInt";
            this.FrameRateInt.ReadOnly = true;
            // 
            // QualityLevel
            // 
            this.QualityLevel.DataPropertyName = "QualityLevel";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.QualityLevel.DefaultCellStyle = dataGridViewCellStyle17;
            this.QualityLevel.HeaderText = "Quality Level";
            this.QualityLevel.Name = "QualityLevel";
            this.QualityLevel.ReadOnly = true;
            // 
            // ErrorType
            // 
            this.ErrorType.DataPropertyName = "ErrorType";
            this.ErrorType.HeaderText = "Error Type";
            this.ErrorType.Name = "ErrorType";
            this.ErrorType.ReadOnly = true;
            // 
            // lbl720x60Count
            // 
            this.lbl720x60Count.Location = new System.Drawing.Point(452, 46);
            this.lbl720x60Count.Name = "lbl720x60Count";
            this.lbl720x60Count.Size = new System.Drawing.Size(50, 14);
            this.lbl720x60Count.TabIndex = 11;
            this.lbl720x60Count.Text = "0";
            this.lbl720x60Count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl1080x30Count
            // 
            this.lbl1080x30Count.Location = new System.Drawing.Point(452, 32);
            this.lbl1080x30Count.Name = "lbl1080x30Count";
            this.lbl1080x30Count.Size = new System.Drawing.Size(50, 14);
            this.lbl1080x30Count.TabIndex = 10;
            this.lbl1080x30Count.Text = "0";
            this.lbl1080x30Count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl1080x60Count
            // 
            this.lbl1080x60Count.Location = new System.Drawing.Point(452, 18);
            this.lbl1080x60Count.Name = "lbl1080x60Count";
            this.lbl1080x60Count.Size = new System.Drawing.Size(50, 14);
            this.lbl1080x60Count.TabIndex = 9;
            this.lbl1080x60Count.Text = "0";
            this.lbl1080x60Count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "720x60:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "1080x30:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "1080x60:";
            // 
            // lbl720x30Count
            // 
            this.lbl720x30Count.Location = new System.Drawing.Point(452, 60);
            this.lbl720x30Count.Name = "lbl720x30Count";
            this.lbl720x30Count.Size = new System.Drawing.Size(50, 14);
            this.lbl720x30Count.TabIndex = 13;
            this.lbl720x30Count.Text = "0";
            this.lbl720x30Count.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "720x30:";
            // 
            // lblOtherSdCount
            // 
            this.lblOtherSdCount.Location = new System.Drawing.Point(452, 74);
            this.lblOtherSdCount.Name = "lblOtherSdCount";
            this.lblOtherSdCount.Size = new System.Drawing.Size(50, 14);
            this.lblOtherSdCount.TabIndex = 15;
            this.lblOtherSdCount.Text = "0";
            this.lblOtherSdCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblOtherSd
            // 
            this.lblOtherSd.AutoSize = true;
            this.lblOtherSd.Location = new System.Drawing.Point(318, 74);
            this.lblOtherSd.Name = "lblOtherSd";
            this.lblOtherSd.Size = new System.Drawing.Size(65, 14);
            this.lblOtherSd.TabIndex = 14;
            this.lblOtherSd.Text = "Other (SD):";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(436, 150);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(97, 25);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 464);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.dgvChannels);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelEntryBindingSource)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBadChannels;
        private System.Windows.Forms.Label lblGoodChannels;
        private System.Windows.Forms.Label lblTotalChecked;
        private System.Windows.Forms.Label lblBadChannelsCount;
        private System.Windows.Forms.Label lblGoodChannelsCount;
        private System.Windows.Forms.Label lblTotalChannelsCount;
        private System.Windows.Forms.DataGridView dgvChannels;
        private System.Windows.Forms.BindingSource channelEntryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn TvgId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TvgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameRateInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorType;
        private System.Windows.Forms.Label lblOtherSdCount;
        private System.Windows.Forms.Label lblOtherSd;
        private System.Windows.Forms.Label lbl720x30Count;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl720x60Count;
        private System.Windows.Forms.Label lbl1080x30Count;
        private System.Windows.Forms.Label lbl1080x60Count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStop;
    }
}

