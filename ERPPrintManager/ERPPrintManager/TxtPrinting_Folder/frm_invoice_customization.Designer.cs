namespace ERPPrintManager.TxtPrinting_Folder
{
    partial class frm_invoice_customization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_invoice_customization));
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.chkShowPaymentsLabel = new System.Windows.Forms.CheckBox();
            this.chkShowProductNameLabel = new System.Windows.Forms.CheckBox();
            this.chkShowDescriptionLabel = new System.Windows.Forms.CheckBox();
            this.chkInclusive = new System.Windows.Forms.CheckBox();
            this.chkSubtotalExcl = new System.Windows.Forms.CheckBox();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.lblFooter = new System.Windows.Forms.Label();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBoxLogo = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBrowseLogo = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnResetToDefault = new System.Windows.Forms.Button();
            this.btnFetchCurrent = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialogLogo = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtkicthenheader = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.txtkicthenheader);
            this.groupBoxSettings.Controls.Add(this.chkShowPaymentsLabel);
            this.groupBoxSettings.Controls.Add(this.chkShowProductNameLabel);
            this.groupBoxSettings.Controls.Add(this.chkShowDescriptionLabel);
            this.groupBoxSettings.Controls.Add(this.chkInclusive);
            this.groupBoxSettings.Controls.Add(this.chkSubtotalExcl);
            this.groupBoxSettings.Controls.Add(this.txtFooter);
            this.groupBoxSettings.Controls.Add(this.lblFooter);
            this.groupBoxSettings.Controls.Add(this.chkVat);
            this.groupBoxSettings.Controls.Add(this.txtType);
            this.groupBoxSettings.Controls.Add(this.lblType);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(380, 380);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Invoice Customization Settings";
            this.groupBoxSettings.Enter += new System.EventHandler(this.groupBoxSettings_Enter);
            // 
            // chkShowPaymentsLabel
            // 
            this.chkShowPaymentsLabel.AutoSize = true;
            this.chkShowPaymentsLabel.Location = new System.Drawing.Point(19, 358);
            this.chkShowPaymentsLabel.Name = "chkShowPaymentsLabel";
            this.chkShowPaymentsLabel.Size = new System.Drawing.Size(131, 17);
            this.chkShowPaymentsLabel.TabIndex = 9;
            this.chkShowPaymentsLabel.Text = "Show Payments Label";
            this.chkShowPaymentsLabel.UseVisualStyleBackColor = true;
            // 
            // chkShowProductNameLabel
            // 
            this.chkShowProductNameLabel.AutoSize = true;
            this.chkShowProductNameLabel.Location = new System.Drawing.Point(19, 328);
            this.chkShowProductNameLabel.Name = "chkShowProductNameLabel";
            this.chkShowProductNameLabel.Size = new System.Drawing.Size(153, 17);
            this.chkShowProductNameLabel.TabIndex = 8;
            this.chkShowProductNameLabel.Text = "Show Product Name Label";
            this.chkShowProductNameLabel.UseVisualStyleBackColor = true;
            // 
            // chkShowDescriptionLabel
            // 
            this.chkShowDescriptionLabel.AutoSize = true;
            this.chkShowDescriptionLabel.Location = new System.Drawing.Point(19, 298);
            this.chkShowDescriptionLabel.Name = "chkShowDescriptionLabel";
            this.chkShowDescriptionLabel.Size = new System.Drawing.Size(138, 17);
            this.chkShowDescriptionLabel.TabIndex = 7;
            this.chkShowDescriptionLabel.Text = "Show Description Label";
            this.chkShowDescriptionLabel.UseVisualStyleBackColor = true;
            // 
            // chkInclusive
            // 
            this.chkInclusive.AutoSize = true;
            this.chkInclusive.Location = new System.Drawing.Point(19, 268);
            this.chkInclusive.Name = "chkInclusive";
            this.chkInclusive.Size = new System.Drawing.Size(98, 17);
            this.chkInclusive.TabIndex = 6;
            this.chkInclusive.Text = "Show Inclusive";
            this.chkInclusive.UseVisualStyleBackColor = true;
            // 
            // chkSubtotalExcl
            // 
            this.chkSubtotalExcl.AutoSize = true;
            this.chkSubtotalExcl.Location = new System.Drawing.Point(19, 238);
            this.chkSubtotalExcl.Name = "chkSubtotalExcl";
            this.chkSubtotalExcl.Size = new System.Drawing.Size(143, 17);
            this.chkSubtotalExcl.TabIndex = 5;
            this.chkSubtotalExcl.Text = "Show Subtotal Exclusive";
            this.chkSubtotalExcl.UseVisualStyleBackColor = true;
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(100, 138);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(260, 80);
            this.txtFooter.TabIndex = 4;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(16, 141);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(40, 13);
            this.lblFooter.TabIndex = 3;
            this.lblFooter.Text = "Footer:";
            // 
            // chkVat
            // 
            this.chkVat.AutoSize = true;
            this.chkVat.Location = new System.Drawing.Point(19, 108);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(77, 17);
            this.chkVat.TabIndex = 2;
            this.chkVat.Text = "Show VAT";
            this.chkVat.UseVisualStyleBackColor = true;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(100, 28);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(260, 20);
            this.txtType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 31);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Invoice Header";
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            // 
            // groupBoxLogo
            // 
            this.groupBoxLogo.Controls.Add(this.button1);
            this.groupBoxLogo.Controls.Add(this.btnBrowseLogo);
            this.groupBoxLogo.Controls.Add(this.pictureBoxLogo);
            this.groupBoxLogo.Location = new System.Drawing.Point(398, 12);
            this.groupBoxLogo.Name = "groupBoxLogo";
            this.groupBoxLogo.Size = new System.Drawing.Size(380, 247);
            this.groupBoxLogo.TabIndex = 1;
            this.groupBoxLogo.TabStop = false;
            this.groupBoxLogo.Text = "Logo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Filter Blank Space";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBrowseLogo
            // 
            this.btnBrowseLogo.Location = new System.Drawing.Point(134, 172);
            this.btnBrowseLogo.Name = "btnBrowseLogo";
            this.btnBrowseLogo.Size = new System.Drawing.Size(146, 23);
            this.btnBrowseLogo.TabIndex = 1;
            this.btnBrowseLogo.Text = "Browse Logo";
            this.btnBrowseLogo.UseVisualStyleBackColor = true;
            this.btnBrowseLogo.Click += new System.EventHandler(this.btnBrowseLogo_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLogo.Location = new System.Drawing.Point(100, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(180, 134);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(258, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 52);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(544, 330);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 35);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnResetToDefault
            // 
            this.btnResetToDefault.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetToDefault.Location = new System.Drawing.Point(409, 435);
            this.btnResetToDefault.Name = "btnResetToDefault";
            this.btnResetToDefault.Size = new System.Drawing.Size(142, 52);
            this.btnResetToDefault.TabIndex = 4;
            this.btnResetToDefault.Text = "Reset to Default";
            this.btnResetToDefault.UseVisualStyleBackColor = true;
            this.btnResetToDefault.Click += new System.EventHandler(this.btnResetToDefault_Click);
            // 
            // btnFetchCurrent
            // 
            this.btnFetchCurrent.Location = new System.Drawing.Point(438, 330);
            this.btnFetchCurrent.Name = "btnFetchCurrent";
            this.btnFetchCurrent.Size = new System.Drawing.Size(100, 35);
            this.btnFetchCurrent.TabIndex = 5;
            this.btnFetchCurrent.Text = "Fetch Current";
            this.btnFetchCurrent.UseVisualStyleBackColor = true;
            this.btnFetchCurrent.Visible = false;
            this.btnFetchCurrent.Click += new System.EventHandler(this.btnFetchCurrent_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(642, 340);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialogLogo
            // 
            this.openFileDialogLogo.FileName = "openFileDialog1";
            this.openFileDialogLogo.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(395, 281);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 3);
            this.panel1.TabIndex = 7;
            // 
            // txtkicthenheader
            // 
            this.txtkicthenheader.Location = new System.Drawing.Point(100, 64);
            this.txtkicthenheader.Name = "txtkicthenheader";
            this.txtkicthenheader.Size = new System.Drawing.Size(260, 20);
            this.txtkicthenheader.TabIndex = 10;
            this.txtkicthenheader.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Order Header";
            // 
            // frm_invoice_customization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 495);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFetchCurrent);
            this.Controls.Add(this.btnResetToDefault);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxLogo);
            this.Controls.Add(this.groupBoxSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_invoice_customization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Customization";
            this.Load += new System.EventHandler(this.frm_invoice_customization_Load);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.groupBoxLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox chkShowPaymentsLabel;
        private System.Windows.Forms.CheckBox chkShowProductNameLabel;
        private System.Windows.Forms.CheckBox chkShowDescriptionLabel;
        private System.Windows.Forms.CheckBox chkInclusive;
        private System.Windows.Forms.CheckBox chkSubtotalExcl;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox groupBoxLogo;
        private System.Windows.Forms.Button btnBrowseLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnResetToDefault;
        private System.Windows.Forms.Button btnFetchCurrent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialogLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtkicthenheader;
        private System.Windows.Forms.Label label1;
    }
}