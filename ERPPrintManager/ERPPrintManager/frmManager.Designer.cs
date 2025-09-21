namespace ERPPrintManager
{
    partial class frmManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            groupBox1 = new GroupBox();
            lblnotify = new Label();
            pictureBox1 = new PictureBox();
            hpm_menu = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            setDefaultPrinterToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            MyNotifyIcon = new NotifyIcon(components);
            file_watcher = new FileSystemWatcher();
            timer_start = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            hpm_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)file_watcher).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblnotify);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(9, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(516, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // lblnotify
            // 
            lblnotify.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblnotify.Location = new Point(93, 32);
            lblnotify.Name = "lblnotify";
            lblnotify.Size = new Size(405, 52);
            lblnotify.TabIndex = 1;
            lblnotify.Text = "Waiting for print request...";
            lblnotify.TextAlign = ContentAlignment.MiddleLeft;
            lblnotify.Click += lblnotify_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.printer_img;
            pictureBox1.Location = new Point(10, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hpm_menu
            // 
            hpm_menu.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            hpm_menu.Location = new Point(0, 0);
            hpm_menu.Name = "hpm_menu";
            hpm_menu.RenderMode = ToolStripRenderMode.Professional;
            hpm_menu.Size = new Size(535, 24);
            hpm_menu.TabIndex = 1;
            hpm_menu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setDefaultPrinterToolStripMenuItem, exitToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // setDefaultPrinterToolStripMenuItem
            // 
            setDefaultPrinterToolStripMenuItem.BackColor = Color.Purple;
            setDefaultPrinterToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            setDefaultPrinterToolStripMenuItem.ForeColor = Color.White;
            setDefaultPrinterToolStripMenuItem.Image = Properties.Resources.settings_small;
            setDefaultPrinterToolStripMenuItem.Name = "setDefaultPrinterToolStripMenuItem";
            setDefaultPrinterToolStripMenuItem.Size = new Size(188, 24);
            setDefaultPrinterToolStripMenuItem.Text = "Set Default Printer";
            setDefaultPrinterToolStripMenuItem.Click += setDefaultPrinterToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor = Color.Purple;
            exitToolStripMenuItem.Font = new Font("Segoe UI", 10F);
            exitToolStripMenuItem.ForeColor = Color.White;
            exitToolStripMenuItem.Image = Properties.Resources.close_small;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(188, 24);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // MyNotifyIcon
            // 
            MyNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            MyNotifyIcon.BalloonTipText = "ERPPrint Manger Running...";
            MyNotifyIcon.BalloonTipTitle = "Havano Print Manager";
            MyNotifyIcon.Icon = (Icon)resources.GetObject("MyNotifyIcon.Icon");
            MyNotifyIcon.Text = "ERP Print Manager";
            MyNotifyIcon.Visible = true;
            MyNotifyIcon.DoubleClick += MyNotifyIcon_DoubleClick;
            // 
            // file_watcher
            // 
            file_watcher.EnableRaisingEvents = true;
            file_watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            file_watcher.Path = "C:\\InvoiceFolder";
            file_watcher.SynchronizingObject = lblnotify;
            file_watcher.Created += file_watcher_Created;
            // 
            // timer_start
            // 
            timer_start.Enabled = true;
            timer_start.Interval = 50;
            timer_start.Tick += timer_start_Tick;
            // 
            // frmManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Purple;
            ClientSize = new Size(535, 152);
            Controls.Add(groupBox1);
            Controls.Add(hpm_menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = hpm_menu;
            MaximizeBox = false;
            Name = "frmManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Print Manager";
            Load += frmManager_Load;
            Resize += frmManager_Resize;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            hpm_menu.ResumeLayout(false);
            hpm_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)file_watcher).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MenuStrip hpm_menu;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem setDefaultPrinterToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label lblnotify;
        private NotifyIcon MyNotifyIcon;
        private FileSystemWatcher file_watcher;
        private System.Windows.Forms.Timer timer_start;
    }
}
