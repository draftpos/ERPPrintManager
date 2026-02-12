namespace ERPPrintManager.TxtPrinting_Folder
{
    partial class frm_font_setting
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
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.lblContentSample = new System.Windows.Forms.Label();
            this.cmbContentStyle = new System.Windows.Forms.ComboBox();
            this.lblContentStyle = new System.Windows.Forms.Label();
            this.nudContentSize = new System.Windows.Forms.NumericUpDown();
            this.lblContentSize = new System.Windows.Forms.Label();
            this.cmbContentFontName = new System.Windows.Forms.ComboBox();
            this.lblContentFontName = new System.Windows.Forms.Label();
            this.gbContentHeader = new System.Windows.Forms.GroupBox();
            this.lblContentHeaderSample = new System.Windows.Forms.Label();
            this.cmbContentHeaderStyle = new System.Windows.Forms.ComboBox();
            this.lblContentHeaderStyle = new System.Windows.Forms.Label();
            this.nudContentHeaderSize = new System.Windows.Forms.NumericUpDown();
            this.lblContentHeaderSize = new System.Windows.Forms.Label();
            this.cmbContentHeaderFontName = new System.Windows.Forms.ComboBox();
            this.lblContentHeaderFontName = new System.Windows.Forms.Label();
            this.gbSubheader = new System.Windows.Forms.GroupBox();
            this.lblSubheaderSample = new System.Windows.Forms.Label();
            this.cmbSubheaderStyle = new System.Windows.Forms.ComboBox();
            this.lblSubheaderStyle = new System.Windows.Forms.Label();
            this.nudSubheaderSize = new System.Windows.Forms.NumericUpDown();
            this.lblSubheaderSize = new System.Windows.Forms.Label();
            this.cmbSubheaderFontName = new System.Windows.Forms.ComboBox();
            this.lblSubheaderFontName = new System.Windows.Forms.Label();
            this.gbOrderContent = new System.Windows.Forms.GroupBox();
            this.lblOrderContentSample = new System.Windows.Forms.Label();
            this.cmbOrderContentStyle = new System.Windows.Forms.ComboBox();
            this.lblOrderContentStyle = new System.Windows.Forms.Label();
            this.nudOrderContentSize = new System.Windows.Forms.NumericUpDown();
            this.lblOrderContentSize = new System.Windows.Forms.Label();
            this.cmbOrderContentFontName = new System.Windows.Forms.ComboBox();
            this.lblOrderContentFontName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContentSize)).BeginInit();
            this.gbContentHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContentHeaderSize)).BeginInit();
            this.gbSubheader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubheaderSize)).BeginInit();
            this.gbOrderContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderContentSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.lblContentSample);
            this.gbContent.Controls.Add(this.cmbContentStyle);
            this.gbContent.Controls.Add(this.lblContentStyle);
            this.gbContent.Controls.Add(this.nudContentSize);
            this.gbContent.Controls.Add(this.lblContentSize);
            this.gbContent.Controls.Add(this.cmbContentFontName);
            this.gbContent.Controls.Add(this.lblContentFontName);
            this.gbContent.Location = new System.Drawing.Point(12, 12);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(300, 150);
            this.gbContent.TabIndex = 0;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "Content Settings";
            // 
            // lblContentSample
            // 
            this.lblContentSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContentSample.Location = new System.Drawing.Point(10, 110);
            this.lblContentSample.Name = "lblContentSample";
            this.lblContentSample.Size = new System.Drawing.Size(270, 30);
            this.lblContentSample.TabIndex = 6;
            this.lblContentSample.Text = "Sample Text";
            // 
            // cmbContentStyle
            // 
            this.cmbContentStyle.FormattingEnabled = true;
            this.cmbContentStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italic",
            "Bold Italic"});
            this.cmbContentStyle.Location = new System.Drawing.Point(100, 80);
            this.cmbContentStyle.Name = "cmbContentStyle";
            this.cmbContentStyle.Size = new System.Drawing.Size(180, 21);
            this.cmbContentStyle.TabIndex = 5;
            this.cmbContentStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // lblContentStyle
            // 
            this.lblContentStyle.AutoSize = true;
            this.lblContentStyle.Location = new System.Drawing.Point(10, 80);
            this.lblContentStyle.Name = "lblContentStyle";
            this.lblContentStyle.Size = new System.Drawing.Size(33, 13);
            this.lblContentStyle.TabIndex = 4;
            this.lblContentStyle.Text = "Style:";
            // 
            // nudContentSize
            // 
            this.nudContentSize.Location = new System.Drawing.Point(100, 50);
            this.nudContentSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nudContentSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContentSize.Name = "nudContentSize";
            this.nudContentSize.Size = new System.Drawing.Size(60, 20);
            this.nudContentSize.TabIndex = 3;
            this.nudContentSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContentSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblContentSize
            // 
            this.lblContentSize.AutoSize = true;
            this.lblContentSize.Location = new System.Drawing.Point(10, 50);
            this.lblContentSize.Name = "lblContentSize";
            this.lblContentSize.Size = new System.Drawing.Size(30, 13);
            this.lblContentSize.TabIndex = 2;
            this.lblContentSize.Text = "Size:";
            // 
            // cmbContentFontName
            // 
            this.cmbContentFontName.FormattingEnabled = true;
            this.cmbContentFontName.Location = new System.Drawing.Point(100, 20);
            this.cmbContentFontName.Name = "cmbContentFontName";
            this.cmbContentFontName.Size = new System.Drawing.Size(180, 21);
            this.cmbContentFontName.TabIndex = 1;
            this.cmbContentFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            // 
            // lblContentFontName
            // 
            this.lblContentFontName.AutoSize = true;
            this.lblContentFontName.Location = new System.Drawing.Point(10, 20);
            this.lblContentFontName.Name = "lblContentFontName";
            this.lblContentFontName.Size = new System.Drawing.Size(62, 13);
            this.lblContentFontName.TabIndex = 0;
            this.lblContentFontName.Text = "Font Name:";
            // 
            // gbContentHeader
            // 
            this.gbContentHeader.Controls.Add(this.lblContentHeaderSample);
            this.gbContentHeader.Controls.Add(this.cmbContentHeaderStyle);
            this.gbContentHeader.Controls.Add(this.lblContentHeaderStyle);
            this.gbContentHeader.Controls.Add(this.nudContentHeaderSize);
            this.gbContentHeader.Controls.Add(this.lblContentHeaderSize);
            this.gbContentHeader.Controls.Add(this.cmbContentHeaderFontName);
            this.gbContentHeader.Controls.Add(this.lblContentHeaderFontName);
            this.gbContentHeader.Location = new System.Drawing.Point(330, 12);
            this.gbContentHeader.Name = "gbContentHeader";
            this.gbContentHeader.Size = new System.Drawing.Size(300, 150);
            this.gbContentHeader.TabIndex = 1;
            this.gbContentHeader.TabStop = false;
            this.gbContentHeader.Text = "Content Header Settings";
            // 
            // lblContentHeaderSample
            // 
            this.lblContentHeaderSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContentHeaderSample.Location = new System.Drawing.Point(10, 110);
            this.lblContentHeaderSample.Name = "lblContentHeaderSample";
            this.lblContentHeaderSample.Size = new System.Drawing.Size(270, 30);
            this.lblContentHeaderSample.TabIndex = 6;
            this.lblContentHeaderSample.Text = "Sample Text";
            // 
            // cmbContentHeaderStyle
            // 
            this.cmbContentHeaderStyle.FormattingEnabled = true;
            this.cmbContentHeaderStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italic",
            "Bold Italic"});
            this.cmbContentHeaderStyle.Location = new System.Drawing.Point(100, 80);
            this.cmbContentHeaderStyle.Name = "cmbContentHeaderStyle";
            this.cmbContentHeaderStyle.Size = new System.Drawing.Size(180, 21);
            this.cmbContentHeaderStyle.TabIndex = 5;
            this.cmbContentHeaderStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // lblContentHeaderStyle
            // 
            this.lblContentHeaderStyle.AutoSize = true;
            this.lblContentHeaderStyle.Location = new System.Drawing.Point(10, 80);
            this.lblContentHeaderStyle.Name = "lblContentHeaderStyle";
            this.lblContentHeaderStyle.Size = new System.Drawing.Size(33, 13);
            this.lblContentHeaderStyle.TabIndex = 4;
            this.lblContentHeaderStyle.Text = "Style:";
            // 
            // nudContentHeaderSize
            // 
            this.nudContentHeaderSize.Location = new System.Drawing.Point(100, 50);
            this.nudContentHeaderSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nudContentHeaderSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContentHeaderSize.Name = "nudContentHeaderSize";
            this.nudContentHeaderSize.Size = new System.Drawing.Size(60, 20);
            this.nudContentHeaderSize.TabIndex = 3;
            this.nudContentHeaderSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudContentHeaderSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblContentHeaderSize
            // 
            this.lblContentHeaderSize.AutoSize = true;
            this.lblContentHeaderSize.Location = new System.Drawing.Point(10, 50);
            this.lblContentHeaderSize.Name = "lblContentHeaderSize";
            this.lblContentHeaderSize.Size = new System.Drawing.Size(30, 13);
            this.lblContentHeaderSize.TabIndex = 2;
            this.lblContentHeaderSize.Text = "Size:";
            // 
            // cmbContentHeaderFontName
            // 
            this.cmbContentHeaderFontName.FormattingEnabled = true;
            this.cmbContentHeaderFontName.Location = new System.Drawing.Point(100, 20);
            this.cmbContentHeaderFontName.Name = "cmbContentHeaderFontName";
            this.cmbContentHeaderFontName.Size = new System.Drawing.Size(180, 21);
            this.cmbContentHeaderFontName.TabIndex = 1;
            this.cmbContentHeaderFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            // 
            // lblContentHeaderFontName
            // 
            this.lblContentHeaderFontName.AutoSize = true;
            this.lblContentHeaderFontName.Location = new System.Drawing.Point(10, 20);
            this.lblContentHeaderFontName.Name = "lblContentHeaderFontName";
            this.lblContentHeaderFontName.Size = new System.Drawing.Size(62, 13);
            this.lblContentHeaderFontName.TabIndex = 0;
            this.lblContentHeaderFontName.Text = "Font Name:";
            // 
            // gbSubheader
            // 
            this.gbSubheader.Controls.Add(this.lblSubheaderSample);
            this.gbSubheader.Controls.Add(this.cmbSubheaderStyle);
            this.gbSubheader.Controls.Add(this.lblSubheaderStyle);
            this.gbSubheader.Controls.Add(this.nudSubheaderSize);
            this.gbSubheader.Controls.Add(this.lblSubheaderSize);
            this.gbSubheader.Controls.Add(this.cmbSubheaderFontName);
            this.gbSubheader.Controls.Add(this.lblSubheaderFontName);
            this.gbSubheader.Location = new System.Drawing.Point(12, 170);
            this.gbSubheader.Name = "gbSubheader";
            this.gbSubheader.Size = new System.Drawing.Size(300, 150);
            this.gbSubheader.TabIndex = 2;
            this.gbSubheader.TabStop = false;
            this.gbSubheader.Text = "Subheader Settings";
            // 
            // lblSubheaderSample
            // 
            this.lblSubheaderSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubheaderSample.Location = new System.Drawing.Point(10, 110);
            this.lblSubheaderSample.Name = "lblSubheaderSample";
            this.lblSubheaderSample.Size = new System.Drawing.Size(270, 30);
            this.lblSubheaderSample.TabIndex = 6;
            this.lblSubheaderSample.Text = "Sample Text";
            // 
            // cmbSubheaderStyle
            // 
            this.cmbSubheaderStyle.FormattingEnabled = true;
            this.cmbSubheaderStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italic",
            "Bold Italic"});
            this.cmbSubheaderStyle.Location = new System.Drawing.Point(100, 80);
            this.cmbSubheaderStyle.Name = "cmbSubheaderStyle";
            this.cmbSubheaderStyle.Size = new System.Drawing.Size(180, 21);
            this.cmbSubheaderStyle.TabIndex = 5;
            this.cmbSubheaderStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // lblSubheaderStyle
            // 
            this.lblSubheaderStyle.AutoSize = true;
            this.lblSubheaderStyle.Location = new System.Drawing.Point(10, 80);
            this.lblSubheaderStyle.Name = "lblSubheaderStyle";
            this.lblSubheaderStyle.Size = new System.Drawing.Size(33, 13);
            this.lblSubheaderStyle.TabIndex = 4;
            this.lblSubheaderStyle.Text = "Style:";
            // 
            // nudSubheaderSize
            // 
            this.nudSubheaderSize.Location = new System.Drawing.Point(100, 50);
            this.nudSubheaderSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nudSubheaderSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSubheaderSize.Name = "nudSubheaderSize";
            this.nudSubheaderSize.Size = new System.Drawing.Size(60, 20);
            this.nudSubheaderSize.TabIndex = 3;
            this.nudSubheaderSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSubheaderSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblSubheaderSize
            // 
            this.lblSubheaderSize.AutoSize = true;
            this.lblSubheaderSize.Location = new System.Drawing.Point(10, 50);
            this.lblSubheaderSize.Name = "lblSubheaderSize";
            this.lblSubheaderSize.Size = new System.Drawing.Size(30, 13);
            this.lblSubheaderSize.TabIndex = 2;
            this.lblSubheaderSize.Text = "Size:";
            // 
            // cmbSubheaderFontName
            // 
            this.cmbSubheaderFontName.FormattingEnabled = true;
            this.cmbSubheaderFontName.Location = new System.Drawing.Point(100, 20);
            this.cmbSubheaderFontName.Name = "cmbSubheaderFontName";
            this.cmbSubheaderFontName.Size = new System.Drawing.Size(180, 21);
            this.cmbSubheaderFontName.TabIndex = 1;
            this.cmbSubheaderFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            // 
            // lblSubheaderFontName
            // 
            this.lblSubheaderFontName.AutoSize = true;
            this.lblSubheaderFontName.Location = new System.Drawing.Point(10, 20);
            this.lblSubheaderFontName.Name = "lblSubheaderFontName";
            this.lblSubheaderFontName.Size = new System.Drawing.Size(62, 13);
            this.lblSubheaderFontName.TabIndex = 0;
            this.lblSubheaderFontName.Text = "Font Name:";
            // 
            // gbOrderContent
            // 
            this.gbOrderContent.Controls.Add(this.lblOrderContentSample);
            this.gbOrderContent.Controls.Add(this.cmbOrderContentStyle);
            this.gbOrderContent.Controls.Add(this.lblOrderContentStyle);
            this.gbOrderContent.Controls.Add(this.nudOrderContentSize);
            this.gbOrderContent.Controls.Add(this.lblOrderContentSize);
            this.gbOrderContent.Controls.Add(this.cmbOrderContentFontName);
            this.gbOrderContent.Controls.Add(this.lblOrderContentFontName);
            this.gbOrderContent.Location = new System.Drawing.Point(330, 170);
            this.gbOrderContent.Name = "gbOrderContent";
            this.gbOrderContent.Size = new System.Drawing.Size(300, 150);
            this.gbOrderContent.TabIndex = 3;
            this.gbOrderContent.TabStop = false;
            this.gbOrderContent.Text = "Order Content Settings";
            // 
            // lblOrderContentSample
            // 
            this.lblOrderContentSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderContentSample.Location = new System.Drawing.Point(10, 110);
            this.lblOrderContentSample.Name = "lblOrderContentSample";
            this.lblOrderContentSample.Size = new System.Drawing.Size(270, 30);
            this.lblOrderContentSample.TabIndex = 6;
            this.lblOrderContentSample.Text = "Sample Text";
            // 
            // cmbOrderContentStyle
            // 
            this.cmbOrderContentStyle.FormattingEnabled = true;
            this.cmbOrderContentStyle.Items.AddRange(new object[] {
            "Regular",
            "Bold",
            "Italic",
            "Bold Italic"});
            this.cmbOrderContentStyle.Location = new System.Drawing.Point(100, 80);
            this.cmbOrderContentStyle.Name = "cmbOrderContentStyle";
            this.cmbOrderContentStyle.Size = new System.Drawing.Size(180, 21);
            this.cmbOrderContentStyle.TabIndex = 5;
            this.cmbOrderContentStyle.SelectedIndexChanged += new System.EventHandler(this.cmbStyle_SelectedIndexChanged);
            // 
            // lblOrderContentStyle
            // 
            this.lblOrderContentStyle.AutoSize = true;
            this.lblOrderContentStyle.Location = new System.Drawing.Point(10, 80);
            this.lblOrderContentStyle.Name = "lblOrderContentStyle";
            this.lblOrderContentStyle.Size = new System.Drawing.Size(33, 13);
            this.lblOrderContentStyle.TabIndex = 4;
            this.lblOrderContentStyle.Text = "Style:";
            // 
            // nudOrderContentSize
            // 
            this.nudOrderContentSize.Location = new System.Drawing.Point(100, 50);
            this.nudOrderContentSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nudOrderContentSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrderContentSize.Name = "nudOrderContentSize";
            this.nudOrderContentSize.Size = new System.Drawing.Size(60, 20);
            this.nudOrderContentSize.TabIndex = 3;
            this.nudOrderContentSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrderContentSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // lblOrderContentSize
            // 
            this.lblOrderContentSize.AutoSize = true;
            this.lblOrderContentSize.Location = new System.Drawing.Point(10, 50);
            this.lblOrderContentSize.Name = "lblOrderContentSize";
            this.lblOrderContentSize.Size = new System.Drawing.Size(30, 13);
            this.lblOrderContentSize.TabIndex = 2;
            this.lblOrderContentSize.Text = "Size:";
            // 
            // cmbOrderContentFontName
            // 
            this.cmbOrderContentFontName.FormattingEnabled = true;
            this.cmbOrderContentFontName.Location = new System.Drawing.Point(100, 20);
            this.cmbOrderContentFontName.Name = "cmbOrderContentFontName";
            this.cmbOrderContentFontName.Size = new System.Drawing.Size(180, 21);
            this.cmbOrderContentFontName.TabIndex = 1;
            this.cmbOrderContentFontName.SelectedIndexChanged += new System.EventHandler(this.cmbFontName_SelectedIndexChanged);
            // 
            // lblOrderContentFontName
            // 
            this.lblOrderContentFontName.AutoSize = true;
            this.lblOrderContentFontName.Location = new System.Drawing.Point(10, 20);
            this.lblOrderContentFontName.Name = "lblOrderContentFontName";
            this.lblOrderContentFontName.Size = new System.Drawing.Size(62, 13);
            this.lblOrderContentFontName.TabIndex = 0;
            this.lblOrderContentFontName.Text = "Font Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(450, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(540, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frm_font_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 361);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbOrderContent);
            this.Controls.Add(this.gbSubheader);
            this.Controls.Add(this.gbContentHeader);
            this.Controls.Add(this.gbContent);
            this.MaximizeBox = false;
            this.Name = "frm_font_setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font Settings";
            this.Load += new System.EventHandler(this.frm_font_setting_Load_2);
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContentSize)).EndInit();
            this.gbContentHeader.ResumeLayout(false);
            this.gbContentHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudContentHeaderSize)).EndInit();
            this.gbSubheader.ResumeLayout(false);
            this.gbSubheader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubheaderSize)).EndInit();
            this.gbOrderContent.ResumeLayout(false);
            this.gbOrderContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrderContentSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.Label lblContentSample;
        private System.Windows.Forms.ComboBox cmbContentStyle;
        private System.Windows.Forms.Label lblContentStyle;
        private System.Windows.Forms.NumericUpDown nudContentSize;
        private System.Windows.Forms.Label lblContentSize;
        private System.Windows.Forms.ComboBox cmbContentFontName;
        private System.Windows.Forms.Label lblContentFontName;
        private System.Windows.Forms.GroupBox gbContentHeader;
        private System.Windows.Forms.Label lblContentHeaderSample;
        private System.Windows.Forms.ComboBox cmbContentHeaderStyle;
        private System.Windows.Forms.Label lblContentHeaderStyle;
        private System.Windows.Forms.NumericUpDown nudContentHeaderSize;
        private System.Windows.Forms.Label lblContentHeaderSize;
        private System.Windows.Forms.ComboBox cmbContentHeaderFontName;
        private System.Windows.Forms.Label lblContentHeaderFontName;
        private System.Windows.Forms.GroupBox gbSubheader;
        private System.Windows.Forms.Label lblSubheaderSample;
        private System.Windows.Forms.ComboBox cmbSubheaderStyle;
        private System.Windows.Forms.Label lblSubheaderStyle;
        private System.Windows.Forms.NumericUpDown nudSubheaderSize;
        private System.Windows.Forms.Label lblSubheaderSize;
        private System.Windows.Forms.ComboBox cmbSubheaderFontName;
        private System.Windows.Forms.Label lblSubheaderFontName;
        private System.Windows.Forms.GroupBox gbOrderContent;
        private System.Windows.Forms.Label lblOrderContentSample;
        private System.Windows.Forms.ComboBox cmbOrderContentStyle;
        private System.Windows.Forms.Label lblOrderContentStyle;
        private System.Windows.Forms.NumericUpDown nudOrderContentSize;
        private System.Windows.Forms.Label lblOrderContentSize;
        private System.Windows.Forms.ComboBox cmbOrderContentFontName;
        private System.Windows.Forms.Label lblOrderContentFontName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}