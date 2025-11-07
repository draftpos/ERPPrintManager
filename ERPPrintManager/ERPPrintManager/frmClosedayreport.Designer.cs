namespace ERPPrintManager
{
    partial class frmClosedayreport
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
            this.panel_multi = new System.Windows.Forms.Panel();
            this.txtAPI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdeviceserialno = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiscalDay = new System.Windows.Forms.TextBox();
            this.btnSaveAPIData = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.btnSaveCompanyInfo = new System.Windows.Forms.Button();
            this.panel_multi.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_multi
            // 
            this.panel_multi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_multi.Controls.Add(this.btnPrint);
            this.panel_multi.Controls.Add(this.label4);
            this.panel_multi.Controls.Add(this.txtFiscalDay);
            this.panel_multi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.panel_multi.Location = new System.Drawing.Point(6, 182);
            this.panel_multi.Name = "panel_multi";
            this.panel_multi.Size = new System.Drawing.Size(449, 58);
            this.panel_multi.TabIndex = 3;
            // 
            // txtAPI
            // 
            this.txtAPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPI.Location = new System.Drawing.Point(10, 43);
            this.txtAPI.Name = "txtAPI";
            this.txtAPI.Size = new System.Drawing.Size(208, 25);
            this.txtAPI.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "API Key :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(223, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Secret Key :";
            // 
            // txtSecret
            // 
            this.txtSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecret.Location = new System.Drawing.Point(227, 43);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.PasswordChar = '*';
            this.txtSecret.Size = new System.Drawing.Size(208, 25);
            this.txtSecret.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Device Serial Number :";
            // 
            // txtdeviceserialno
            // 
            this.txtdeviceserialno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdeviceserialno.Location = new System.Drawing.Point(10, 96);
            this.txtdeviceserialno.Name = "txtdeviceserialno";
            this.txtdeviceserialno.Size = new System.Drawing.Size(208, 25);
            this.txtdeviceserialno.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtserver);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSaveAPIData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAPI);
            this.groupBox1.Controls.Add(this.txtdeviceserialno);
            this.groupBox1.Controls.Add(this.txtSecret);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 170);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(5, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fiscal Day :";
            // 
            // txtFiscalDay
            // 
            this.txtFiscalDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiscalDay.Location = new System.Drawing.Point(86, 14);
            this.txtFiscalDay.Name = "txtFiscalDay";
            this.txtFiscalDay.Size = new System.Drawing.Size(131, 25);
            this.txtFiscalDay.TabIndex = 7;
            // 
            // btnSaveAPIData
            // 
            this.btnSaveAPIData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveAPIData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAPIData.ForeColor = System.Drawing.Color.White;
            this.btnSaveAPIData.Image = global::ERPPrintManager.Properties.Resources.save;
            this.btnSaveAPIData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveAPIData.Location = new System.Drawing.Point(10, 127);
            this.btnSaveAPIData.Name = "btnSaveAPIData";
            this.btnSaveAPIData.Size = new System.Drawing.Size(170, 33);
            this.btnSaveAPIData.TabIndex = 6;
            this.btnSaveAPIData.Text = "Save API Settings";
            this.btnSaveAPIData.UseVisualStyleBackColor = true;
            this.btnSaveAPIData.Click += new System.EventHandler(this.btnSaveAPIData_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::ERPPrintManager.Properties.Resources.print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(226, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(147, 33);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtserver
            // 
            this.txtserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtserver.Location = new System.Drawing.Point(226, 96);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(208, 25);
            this.txtserver.TabIndex = 7;
            this.txtserver.Text = "https://erpfiscal.havano.online";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(222, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Server Address :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 286);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Purple;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel_multi);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 256);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Close Day Report";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Purple;
            this.tabPage2.Controls.Add(this.btnSaveCompanyInfo);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtPhoneNo);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtEmail);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtVat);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtTIN);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtCompanyName);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Company Information";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(11, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Company Name :";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Location = new System.Drawing.Point(15, 29);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(490, 23);
            this.txtCompanyName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(11, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "TIN :";
            // 
            // txtTIN
            // 
            this.txtTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTIN.Location = new System.Drawing.Point(15, 181);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(208, 23);
            this.txtTIN.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(293, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "VAT :";
            // 
            // txtVat
            // 
            this.txtVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVat.Location = new System.Drawing.Point(297, 181);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(208, 23);
            this.txtVat.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Company Address :";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(15, 80);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(490, 23);
            this.txtAddress.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(11, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Company Email :";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(15, 131);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(293, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Company Phone No. :";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNo.Location = new System.Drawing.Point(297, 131);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(208, 23);
            this.txtPhoneNo.TabIndex = 12;
            // 
            // btnSaveCompanyInfo
            // 
            this.btnSaveCompanyInfo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveCompanyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCompanyInfo.ForeColor = System.Drawing.Color.White;
            this.btnSaveCompanyInfo.Image = global::ERPPrintManager.Properties.Resources.save;
            this.btnSaveCompanyInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveCompanyInfo.Location = new System.Drawing.Point(15, 217);
            this.btnSaveCompanyInfo.Name = "btnSaveCompanyInfo";
            this.btnSaveCompanyInfo.Size = new System.Drawing.Size(177, 33);
            this.btnSaveCompanyInfo.TabIndex = 14;
            this.btnSaveCompanyInfo.Text = "Save Company Info";
            this.btnSaveCompanyInfo.UseVisualStyleBackColor = true;
            this.btnSaveCompanyInfo.Click += new System.EventHandler(this.btnSaveCompanyInfo_Click);
            // 
            // frmClosedayreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(556, 311);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmClosedayreport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Close Day Report";
            this.Load += new System.EventHandler(this.frmClosedayreport_Load);
            this.panel_multi.ResumeLayout(false);
            this.panel_multi.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_multi;
        private System.Windows.Forms.TextBox txtAPI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdeviceserialno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveAPIData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiscalDay;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTIN;
        private System.Windows.Forms.Button btnSaveCompanyInfo;
    }
}