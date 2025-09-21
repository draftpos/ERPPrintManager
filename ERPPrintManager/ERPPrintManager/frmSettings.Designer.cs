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
            panel1 = new Panel();
            btnSet = new Button();
            cmbPrinter = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSet);
            panel1.Controls.Add(cmbPrinter);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 74);
            panel1.TabIndex = 0;
            // 
            // btnSet
            // 
            btnSet.FlatAppearance.BorderColor = Color.MistyRose;
            btnSet.FlatStyle = FlatStyle.Flat;
            btnSet.Font = new Font("Segoe UI", 10F);
            btnSet.ForeColor = Color.White;
            btnSet.Image = Properties.Resources.my_set;
            btnSet.ImageAlign = ContentAlignment.MiddleLeft;
            btnSet.Location = new Point(273, 28);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(136, 31);
            btnSet.TabIndex = 2;
            btnSet.Text = "Set Printer";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // cmbPrinter
            // 
            cmbPrinter.Font = new Font("Segoe UI", 10F);
            cmbPrinter.FormattingEnabled = true;
            cmbPrinter.Location = new Point(18, 33);
            cmbPrinter.Name = "cmbPrinter";
            cmbPrinter.Size = new Size(234, 25);
            cmbPrinter.TabIndex = 1;
            cmbPrinter.Text = "Select Printer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 11);
            label1.Name = "label1";
            label1.Size = new Size(96, 19);
            label1.TabIndex = 0;
            label1.Text = "Select Printer :";
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(455, 100);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += frmSettings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSet;
        private ComboBox cmbPrinter;
        private Label label1;
    }
}