using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPPrintManager
{
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setDefaultPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }
        private void RestoreApp(object sender, EventArgs e)
        {
            // Restore the application
            this.Show();
            this.WindowState = FormWindowState.Normal;
            MyNotifyIcon.Visible = false;
        }

        private void ExitApp(object sender, EventArgs e)
        {
            // Exit the application
            MyNotifyIcon.Visible = false;
            Application.Exit();
        }

        private void DeleteAllTextFiles(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

                    foreach (string file in txtFiles)
                    {
                        File.Delete(file);
                        Console.WriteLine($"Deleted: {Path.GetFileName(file)}");
                    }

                    Console.WriteLine("All .txt files deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Folder not found: " + folderPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting files: " + ex.Message);
            }
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            string invoice_Path = @"C:\InvoiceFolder";

            // Ensure directory exists
            if (!Directory.Exists(invoice_Path))
            {
                Directory.CreateDirectory(invoice_Path);
            }

            DeleteAllTextFiles(invoice_Path);

            MyNotifyIcon.Visible = false;
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Restore", null, RestoreApp);
            contextMenu.Items.Add("Exit", null, ExitApp);
            MyNotifyIcon.ContextMenuStrip = contextMenu;

            this.WindowState = FormWindowState.Minimized;
            MyNotifyIcon.ShowBalloonTip(1000);
            lblnotify.Text = "Waiting for invoice...";
            timer_start.Enabled = true;
            timer_start.Start();

        }

        private void MyNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreApp(sender, e);
        }

        private void frmManager_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                MyNotifyIcon.Visible = true;
                this.Hide();
            }
        }
        public static string GenerateQRCode(string data, string invoice_no)
        {
            string savePath = Path.Combine(@"C:\InvoiceFolder", "QRCode");
            // Ensure directory exists
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        string qrCodePath = Path.Combine(savePath, invoice_no + "_qrccode.png");
                        qrCodeImage.Save(qrCodePath, System.Drawing.Imaging.ImageFormat.Png);
                        return qrCodePath;
                    }
                }
            }
        }

        private void timer_start_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Monitor started");
            string folderPath = @"C:\InvoiceFolder";

            file_watcher.Path = folderPath;
            file_watcher.Filter = "*.txt";
            file_watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.LastWrite;
            file_watcher.EnableRaisingEvents = true;
            timer_start.Enabled = false;
        }

        private void file_watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                Debug.WriteLine($"New JSON file detected: {e.FullPath}");
                lblnotify.Text = "New invoice found...";
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                string json = File.ReadAllText(e.FullPath);
                ReceiptData receipt = JsonConvert.DeserializeObject<ReceiptData>(json);
                lblnotify.Text = "Processing invoice with invoice number " + receipt.InvoiceNo;
                Application.DoEvents();
                GenerateQRCode(receipt.QRCode, receipt.InvoiceNo);
                ReceiptPrinter printer = new ReceiptPrinter(receipt);

                if (Properties.Settings.Default.IsSinglePrinter)
                {
                    printer.PrintReceipt1(Properties.Settings.Default.DefaultPrinter);
                }
                if (Properties.Settings.Default.IsMultiplePrinter)
                {
                    foreach (string item in Properties.Settings.Default.MultiplePrinterList)
                    {
                        printer.PrintReceipt1(item);

                    }
                }

                lblnotify.Text = "Waiting for new invoice...";

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error parsing file {e.Name}: {ex.Message}");
            }
        }

        private void file_watcher_Renamed(object sender, RenamedEventArgs e)
        {
            try
            {
                Debug.WriteLine($"New JSON file detected: {e.FullPath}");
                lblnotify.Text = "New invoice found...";
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                string json = File.ReadAllText(e.FullPath);
                ReceiptData receipt = JsonConvert.DeserializeObject<ReceiptData>(json);
                lblnotify.Text = "Processing invoice with invoice number " + receipt.InvoiceNo;
                Application.DoEvents();
                GenerateQRCode(receipt.QRCode, receipt.InvoiceNo);
                ReceiptPrinter printer = new ReceiptPrinter(receipt);
                printer.PrintReceipt1(System.Net.Dns.GetHostName());

                lblnotify.Text = "Waiting for new invoice...";

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error parsing file {e.Name}: {ex.Message}", "Error Processing Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error parsing file {e.Name}: {ex.Message}");
            }
        }
    }
}
