namespace ERPPrintManager
{
    partial class frmManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblnotify = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPrintingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDayReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.file_watcher = new System.IO.FileSystemWatcher();
            this.timer_start = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file_watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblnotify);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lblnotify
            // 
            this.lblnotify.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblnotify.Location = new System.Drawing.Point(84, 24);
            this.lblnotify.Name = "lblnotify";
            this.lblnotify.Size = new System.Drawing.Size(369, 65);
            this.lblnotify.TabIndex = 1;
            this.lblnotify.Text = "Waiting for print request...";
            this.lblnotify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERPPrintManager.Properties.Resources.printer_img;
            this.pictureBox1.Location = new System.Drawing.Point(10, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDefaultPrinterToolStripMenuItem,
            this.labelPrintingSettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Purple;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setDefaultPrinterToolStripMenuItem
            // 
            this.setDefaultPrinterToolStripMenuItem.BackColor = System.Drawing.Color.Purple;
            this.setDefaultPrinterToolStripMenuItem.Enabled = false;
            this.setDefaultPrinterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.setDefaultPrinterToolStripMenuItem.Image = global::ERPPrintManager.Properties.Resources.settings_small;
            this.setDefaultPrinterToolStripMenuItem.Name = "setDefaultPrinterToolStripMenuItem";
            this.setDefaultPrinterToolStripMenuItem.Size = new System.Drawing.Size(237, 24);
            this.setDefaultPrinterToolStripMenuItem.Text = "Set Default Printer";
            this.setDefaultPrinterToolStripMenuItem.Click += new System.EventHandler(this.setDefaultPrinterToolStripMenuItem_Click);
            // 
            // labelPrintingSettingsToolStripMenuItem
            // 
            this.labelPrintingSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelPrintingSettingsToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrintingSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelPrintingSettingsToolStripMenuItem.Name = "labelPrintingSettingsToolStripMenuItem";
            this.labelPrintingSettingsToolStripMenuItem.Size = new System.Drawing.Size(237, 24);
            this.labelPrintingSettingsToolStripMenuItem.Text = "Label Printing Settings";
            this.labelPrintingSettingsToolStripMenuItem.Click += new System.EventHandler(this.labelPrintingSettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Purple;
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Image = global::ERPPrintManager.Properties.Resources.close_small;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(237, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeDayReportToolStripMenuItem});
            this.reportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.reportToolStripMenuItem.ForeColor = System.Drawing.Color.Purple;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // closeDayReportToolStripMenuItem
            // 
            this.closeDayReportToolStripMenuItem.BackColor = System.Drawing.Color.Purple;
            this.closeDayReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closeDayReportToolStripMenuItem.Image = global::ERPPrintManager.Properties.Resources.report;
            this.closeDayReportToolStripMenuItem.Name = "closeDayReportToolStripMenuItem";
            this.closeDayReportToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.closeDayReportToolStripMenuItem.Text = "Close Day Report";
            this.closeDayReportToolStripMenuItem.Click += new System.EventHandler(this.closeDayReportToolStripMenuItem_Click);
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MyNotifyIcon.BalloonTipText = "ERPPrint Manger Running...";
            this.MyNotifyIcon.BalloonTipTitle = "Havano Print Manager";
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Text = "ERP Print Manager";
            this.MyNotifyIcon.Visible = true;
            this.MyNotifyIcon.DoubleClick += new System.EventHandler(this.MyNotifyIcon_DoubleClick);
            // 
            // file_watcher
            // 
            this.file_watcher.EnableRaisingEvents = true;
            this.file_watcher.SynchronizingObject = this;
            this.file_watcher.Changed += new System.IO.FileSystemEventHandler(this.file_watcher_Changed);
            //this.file_watcher.Created += new System.IO.FileSystemEventHandler(this.file_watcher_Created);
            this.file_watcher.Renamed += new System.IO.RenamedEventHandler(this.file_watcher_Renamed);
            // 
            // timer_start
            // 
            this.timer_start.Enabled = true;
            this.timer_start.Tick += new System.EventHandler(this.timer_start_Tick);
            // 
            // frmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(485, 146);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERPPrint Manager";
            this.Load += new System.EventHandler(this.frmManager_Load);
            this.Resize += new System.EventHandler(this.frmManager_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file_watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDefaultPrinterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblnotify;
        private System.IO.FileSystemWatcher file_watcher;
        private System.Windows.Forms.Timer timer_start;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDayReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelPrintingSettingsToolStripMenuItem;
    }
}

