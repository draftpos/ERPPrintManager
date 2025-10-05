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
            OptMultiple = new RadioButton();
            OptSingle = new RadioButton();
            btnSet = new Button();
            cmbPrinter = new ComboBox();
            label1 = new Label();
            panel_single = new Panel();
            panel_multi = new Panel();
            btnRemove = new Button();
            btnAdd = new Button();
            lstprinter = new ListBox();
            cmbSelectMultiple = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            panel_single.SuspendLayout();
            panel_multi.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(OptMultiple);
            panel1.Controls.Add(OptSingle);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 51);
            panel1.TabIndex = 0;
            // 
            // OptMultiple
            // 
            OptMultiple.AutoSize = true;
            OptMultiple.Font = new Font("Segoe UI", 10F);
            OptMultiple.ForeColor = Color.White;
            OptMultiple.Location = new Point(260, 14);
            OptMultiple.Name = "OptMultiple";
            OptMultiple.Size = new Size(149, 23);
            OptMultiple.TabIndex = 4;
            OptMultiple.TabStop = true;
            OptMultiple.Text = "Use Multiple Printer";
            OptMultiple.UseVisualStyleBackColor = true;
            OptMultiple.CheckedChanged += OptMultiple_CheckedChanged;
            // 
            // OptSingle
            // 
            OptSingle.AutoSize = true;
            OptSingle.Font = new Font("Segoe UI", 10F);
            OptSingle.ForeColor = Color.White;
            OptSingle.Location = new Point(15, 14);
            OptSingle.Name = "OptSingle";
            OptSingle.Size = new Size(135, 23);
            OptSingle.TabIndex = 3;
            OptSingle.TabStop = true;
            OptSingle.Text = "Use Single Printer";
            OptSingle.UseVisualStyleBackColor = true;
            OptSingle.CheckedChanged += OptSingle_CheckedChanged;
            // 
            // btnSet
            // 
            btnSet.FlatAppearance.BorderColor = Color.MistyRose;
            btnSet.FlatStyle = FlatStyle.Flat;
            btnSet.Font = new Font("Segoe UI", 10F);
            btnSet.ForeColor = Color.White;
            btnSet.Image = Properties.Resources.my_set;
            btnSet.ImageAlign = ContentAlignment.MiddleLeft;
            btnSet.Location = new Point(260, 30);
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
            cmbPrinter.Location = new Point(15, 33);
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
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(96, 19);
            label1.TabIndex = 0;
            label1.Text = "Select Printer :";
            // 
            // panel_single
            // 
            panel_single.BorderStyle = BorderStyle.FixedSingle;
            panel_single.Controls.Add(cmbPrinter);
            panel_single.Controls.Add(label1);
            panel_single.Controls.Add(btnSet);
            panel_single.Location = new Point(12, 66);
            panel_single.Name = "panel_single";
            panel_single.Size = new Size(430, 75);
            panel_single.TabIndex = 1;
            // 
            // panel_multi
            // 
            panel_multi.BorderStyle = BorderStyle.FixedSingle;
            panel_multi.Controls.Add(btnRemove);
            panel_multi.Controls.Add(btnAdd);
            panel_multi.Controls.Add(lstprinter);
            panel_multi.Controls.Add(cmbSelectMultiple);
            panel_multi.Controls.Add(label2);
            panel_multi.Controls.Add(button1);
            panel_multi.Location = new Point(12, 70);
            panel_multi.Name = "panel_multi";
            panel_multi.Size = new Size(430, 208);
            panel_multi.TabIndex = 2;
            // 
            // btnRemove
            // 
            btnRemove.FlatAppearance.BorderColor = Color.MistyRose;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Image = Properties.Resources.remove;
            btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemove.Location = new Point(15, 171);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(173, 31);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove Printer";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.FlatAppearance.BorderColor = Color.MistyRose;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = Properties.Resources.add;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(260, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 31);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Printer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstprinter
            // 
            lstprinter.FormattingEnabled = true;
            lstprinter.ItemHeight = 15;
            lstprinter.Location = new Point(15, 60);
            lstprinter.Name = "lstprinter";
            lstprinter.Size = new Size(234, 109);
            lstprinter.TabIndex = 3;
            // 
            // cmbSelectMultiple
            // 
            cmbSelectMultiple.Font = new Font("Segoe UI", 10F);
            cmbSelectMultiple.FormattingEnabled = true;
            cmbSelectMultiple.Location = new Point(15, 29);
            cmbSelectMultiple.Name = "cmbSelectMultiple";
            cmbSelectMultiple.Size = new Size(234, 25);
            cmbSelectMultiple.TabIndex = 1;
            cmbSelectMultiple.Text = "Select Printer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 7);
            label2.Name = "label2";
            label2.Size = new Size(96, 19);
            label2.TabIndex = 0;
            label2.Text = "Select Printer :";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.MistyRose;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.my_set;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(260, 63);
            button1.Name = "button1";
            button1.Size = new Size(136, 31);
            button1.TabIndex = 2;
            button1.Text = "Set Printers";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(455, 293);
            Controls.Add(panel_multi);
            Controls.Add(panel_single);
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
            panel_single.ResumeLayout(false);
            panel_single.PerformLayout();
            panel_multi.ResumeLayout(false);
            panel_multi.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSet;
        private ComboBox cmbPrinter;
        private Label label1;
        private RadioButton OptMultiple;
        private RadioButton OptSingle;
        private Panel panel_single;
        private Panel panel_multi;
        private ComboBox cmbSelectMultiple;
        private Label label2;
        private Button button1;
        private Button btnRemove;
        private Button btnAdd;
        private ListBox lstprinter;
    }
}