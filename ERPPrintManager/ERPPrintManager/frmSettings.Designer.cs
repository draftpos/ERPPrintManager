namespace ERPPrintManager
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.OptSingle = new System.Windows.Forms.RadioButton();
            this.OptMultiple = new System.Windows.Forms.RadioButton();
            this.panel_single = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.panel_multi = new System.Windows.Forms.Panel();
            this.cmbSelectMultiple = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstprinter = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSetMultiplePrinter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel_single.SuspendLayout();
            this.panel_multi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.OptMultiple);
            this.panel1.Controls.Add(this.OptSingle);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 60);
            this.panel1.TabIndex = 0;
            // 
            // OptSingle
            // 
            this.OptSingle.AutoSize = true;
            this.OptSingle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.OptSingle.ForeColor = System.Drawing.Color.White;
            this.OptSingle.Location = new System.Drawing.Point(14, 20);
            this.OptSingle.Name = "OptSingle";
            this.OptSingle.Size = new System.Drawing.Size(135, 23);
            this.OptSingle.TabIndex = 0;
            this.OptSingle.TabStop = true;
            this.OptSingle.Text = "Use Single Printer";
            this.OptSingle.UseVisualStyleBackColor = true;
            this.OptSingle.CheckedChanged += new System.EventHandler(this.OptSingle_CheckedChanged);
            // 
            // OptMultiple
            // 
            this.OptMultiple.AutoSize = true;
            this.OptMultiple.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.OptMultiple.ForeColor = System.Drawing.Color.White;
            this.OptMultiple.Location = new System.Drawing.Point(233, 20);
            this.OptMultiple.Name = "OptMultiple";
            this.OptMultiple.Size = new System.Drawing.Size(149, 23);
            this.OptMultiple.TabIndex = 1;
            this.OptMultiple.TabStop = true;
            this.OptMultiple.Text = "Use Multiple Printer";
            this.OptMultiple.UseVisualStyleBackColor = true;
            this.OptMultiple.CheckedChanged += new System.EventHandler(this.OptMultiple_CheckedChanged);
            // 
            // panel_single
            // 
            this.panel_single.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_single.Controls.Add(this.button1);
            this.panel_single.Controls.Add(this.cmbPrinter);
            this.panel_single.Controls.Add(this.label1);
            this.panel_single.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.panel_single.Location = new System.Drawing.Point(12, 78);
            this.panel_single.Name = "panel_single";
            this.panel_single.Size = new System.Drawing.Size(431, 69);
            this.panel_single.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Printer :";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(14, 32);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(208, 25);
            this.cmbPrinter.TabIndex = 1;
            this.cmbPrinter.Text = "Select Printer";
            // 
            // panel_multi
            // 
            this.panel_multi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_multi.Controls.Add(this.btnAdd);
            this.panel_multi.Controls.Add(this.btnRemove);
            this.panel_multi.Controls.Add(this.lstprinter);
            this.panel_multi.Controls.Add(this.btnSetMultiplePrinter);
            this.panel_multi.Controls.Add(this.cmbSelectMultiple);
            this.panel_multi.Controls.Add(this.label2);
            this.panel_multi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.panel_multi.Location = new System.Drawing.Point(12, 80);
            this.panel_multi.Name = "panel_multi";
            this.panel_multi.Size = new System.Drawing.Size(431, 231);
            this.panel_multi.TabIndex = 2;
            // 
            // cmbSelectMultiple
            // 
            this.cmbSelectMultiple.FormattingEnabled = true;
            this.cmbSelectMultiple.Location = new System.Drawing.Point(14, 32);
            this.cmbSelectMultiple.Name = "cmbSelectMultiple";
            this.cmbSelectMultiple.Size = new System.Drawing.Size(208, 25);
            this.cmbSelectMultiple.TabIndex = 1;
            this.cmbSelectMultiple.Text = "Select Printer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Printer :";
            // 
            // lstprinter
            // 
            this.lstprinter.FormattingEnabled = true;
            this.lstprinter.ItemHeight = 17;
            this.lstprinter.Location = new System.Drawing.Point(14, 61);
            this.lstprinter.Name = "lstprinter";
            this.lstprinter.Size = new System.Drawing.Size(208, 123);
            this.lstprinter.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = global::ERPPrintManager.Properties.Resources.remove;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(14, 189);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(158, 30);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Printer";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSetMultiplePrinter
            // 
            this.btnSetMultiplePrinter.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSetMultiplePrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetMultiplePrinter.ForeColor = System.Drawing.Color.White;
            this.btnSetMultiplePrinter.Image = global::ERPPrintManager.Properties.Resources.my_set;
            this.btnSetMultiplePrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetMultiplePrinter.Location = new System.Drawing.Point(233, 67);
            this.btnSetMultiplePrinter.Name = "btnSetMultiplePrinter";
            this.btnSetMultiplePrinter.Size = new System.Drawing.Size(133, 33);
            this.btnSetMultiplePrinter.TabIndex = 2;
            this.btnSetMultiplePrinter.Text = "Set Printer";
            this.btnSetMultiplePrinter.UseVisualStyleBackColor = true;
            this.btnSetMultiplePrinter.Click += new System.EventHandler(this.btnSetMultiplePrinter_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::ERPPrintManager.Properties.Resources.my_set;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(233, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Printer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::ERPPrintManager.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(233, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Printer";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(455, 316);
            this.Controls.Add(this.panel_multi);
            this.Controls.Add(this.panel_single);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_single.ResumeLayout(false);
            this.panel_single.PerformLayout();
            this.panel_multi.ResumeLayout(false);
            this.panel_multi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton OptMultiple;
        private System.Windows.Forms.RadioButton OptSingle;
        private System.Windows.Forms.Panel panel_single;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_multi;
        private System.Windows.Forms.Button btnSetMultiplePrinter;
        private System.Windows.Forms.ComboBox cmbSelectMultiple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstprinter;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
    }
}