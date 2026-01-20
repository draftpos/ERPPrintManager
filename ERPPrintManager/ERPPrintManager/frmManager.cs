using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            this.Show();
            this.WindowState = FormWindowState.Normal;
            MyNotifyIcon.Visible = false;
        }

        private void ExitApp(object sender, EventArgs e)
        {
            MyNotifyIcon.Visible = false;
            Application.Exit();
        }

        //private void DeleteAllTextFiles(string folderPath)
        //{
        //    try
        //    {
        //        if (Directory.Exists(folderPath))
        //        {
        //            string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

        //            foreach (string file in txtFiles)
        //            {
        //                File.Delete(file);
        //                Console.WriteLine($"Deleted: {Path.GetFileName(file)}");
        //            }

        //            Console.WriteLine("All .txt files deleted successfully.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Folder not found: " + folderPath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error deleting files: " + ex.Message);
        //    }
        //}

        private void frmManager_Load(object sender, EventArgs e)
        {
            //string invoice_Path = @"C:\InvoiceFolder";
            //if (!Directory.Exists(invoice_Path))
            //{
            //    Directory.CreateDirectory(invoice_Path);
            //}

            //DeleteAllTextFiles(invoice_Path);

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

            // Start background monitoring for label printing folder
            _ = Printout();
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

        public static string SaveQRCode(string data, string invoice_no)
        {
            string savePath = Path.Combine(@"C:\InvoiceFolder", "QRCode");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (string.IsNullOrEmpty(data))
            {
                return "";
            }
            if (data.StartsWith("data:image"))
            {
                int commaIndex = data.IndexOf(',');
                data = data.Substring(commaIndex + 1);
            }
            byte[] imageBytes = Convert.FromBase64String(data);
            string qrCodePath = Path.Combine(savePath, invoice_no + "_qrccode.png");
            File.WriteAllBytes(qrCodePath, imageBytes);
            return qrCodePath;
        }

        public static string GenerateQRCode(string data, string invoice_no)
        {
            string savePath = Path.Combine(@"C:\InvoiceFolder", "QRCode");
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (string.IsNullOrEmpty(data))
            {
                return "";
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





        //private void file_watcher_Created(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        Debug.WriteLine($"New JSON file detected: {e.FullPath}");

        //        // Wait until file is fully written and readable
        //        string json = string.Empty;
        //        while (true)
        //        {
        //            try
        //            {
        //                json = File.ReadAllText(e.FullPath);
        //                break;
        //            }
        //            catch (IOException)
        //            {
        //                Task.Delay(100).Wait();
        //            }
        //        }

        //        ReceiptData receipt = JsonConvert.DeserializeObject<ReceiptData>(json);

        //        this.Invoke((MethodInvoker)(() =>
        //        {
        //            lblnotify.Text = "New invoice found...";
        //            lblnotify.Text = "Processing invoice with invoice number " + receipt.InvoiceNo;
        //        }));

        //        if (receipt.doc_type == null)
        //        {
        //            SaveQRCode(receipt.QRCode, receipt.InvoiceNo);
        //        }

        //        if (receipt.doc_type == "kitchen")
        //        {
        //            KitchenData receipt1 = JsonConvert.DeserializeObject<KitchenData>(json);
        //            ReceiptPrinter printer = new ReceiptPrinter(receipt1);
        //            if (Properties.Settings.Default.IsSinglePrinter)
        //            {
        //                printer.PrintKitchenReceipt(Properties.Settings.Default.DefaultPrinter);
        //            }
        //            if (Properties.Settings.Default.IsMultiplePrinter)
        //            {
        //                foreach (string item in Properties.Settings.Default.MultiplePrinterList)
        //                {
        //                    printer.PrintKitchenReceipt(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ReceiptPrinter printer = new ReceiptPrinter(receipt);
        //            if (Properties.Settings.Default.IsSinglePrinter)
        //            {
        //                printer.PrintReceipt1(Properties.Settings.Default.DefaultPrinter);
        //            }
        //            if (Properties.Settings.Default.IsMultiplePrinter)
        //            {
        //                foreach (string item in Properties.Settings.Default.MultiplePrinterList)
        //                {
        //                    printer.PrintReceipt1(item);
        //                }
        //            }
        //        }

        //        // Clean up processed file
        //        File.Delete(e.FullPath);

        //        this.Invoke((MethodInvoker)(() =>
        //        {
        //            lblnotify.Text = "Waiting for invoice...";
        //        }));
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error parsing file {e.Name}: {ex.Message}");
        //        this.Invoke((MethodInvoker)(() =>
        //        {
        //            lblnotify.Text = "Waiting for invoice...";
        //        }));
        //    }
        //}

        private async Task Printout()
        {
            //MessageBox.Show("Execution started");
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathConfigFile = Path.Combine(documentsPath, "TxtPrintingPath.txt");
            string printedFilesPath = Path.Combine(documentsPath, "PrintedFiles.txt");
            string txtPrintingPath;

            while (true)
            {
                try
                {
                    if (File.Exists(pathConfigFile))
                        txtPrintingPath = File.ReadAllText(pathConfigFile).Trim();
                    else
                        txtPrintingPath = Path.Combine(documentsPath, "TxtPrinting");

                    const string defaultDir = @"C:\InvoiceFolder";

                    if (!Directory.Exists(txtPrintingPath))
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                            {

                                var result = MessageBox.Show(
           "Printing directory is not set.\n\n" +
           "Yes  → Use default directory (C:\\InvoiceFolder)\n" +
           "No   → Let me choose a directory",
           "Directory Not Set",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
       );
                                if (result == DialogResult.Yes)
                                {
                                    //now check if Dir Exist else create folder DIr
                                                                        Directory.CreateDirectory(defaultDir);
                                    txtPrintingPath = defaultDir;
                                    File.WriteAllText(pathConfigFile, txtPrintingPath);
                                }


                                else
                                {
                                
                               

                                    dialog.Description = "Select a directory for Label Printing Text files";
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {
                                    txtPrintingPath = dialog.SelectedPath;
                                    Directory.CreateDirectory(txtPrintingPath);
                                    File.WriteAllText(pathConfigFile, txtPrintingPath);
                                }
                                else
                                {
                                    MessageBox.Show("No directory selected. Printing aborted.");
                                    return; // Stop monitoring
                                }

                                }

                            }
                        }));
                    }



                    //MessageBox.Show("Execution started1");

                    if (!File.Exists(printedFilesPath))
                        File.WriteAllText(printedFilesPath, string.Empty);

                    var printedFiles = new HashSet<string>(
                        File.ReadAllLines(printedFilesPath),
                        StringComparer.OrdinalIgnoreCase
                    );

                    // Process only .json files (assuming they contain ReceiptData JSON)
                    //var allFiles = Directory.GetFiles(txtPrintingPath, "*.json", SearchOption.TopDirectoryOnly)
                    //                        .ToList();
                    // Get all .json and .txt files
                    var allFiles = Directory.GetFiles(txtPrintingPath, "*.*", SearchOption.TopDirectoryOnly)
                                            .Where(f => f.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ||
                                                        f.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                                            .ToList();


                    if (allFiles.Count == 0)
                    {
                      //  MessageBox.Show("No FIle Found");

                        await Task.Delay(30000);
                        continue;
                    }

                    else { 
                    //    MessageBox.Show(Convert.ToString(allFiles.Count) + " FIle Found");
                     }

                        foreach (var file in allFiles)
                        {
                            string fileName = Path.GetFileName(file);

                            if (printedFiles.Contains(fileName))
                                continue;

                            Debug.WriteLine($"Processing label file: {fileName}");

                            this.Invoke((MethodInvoker)(() =>
                            {
                                lblnotify.Text = $"Processing label {fileName}...";
                            }));

                        try
                        {
                            string json = File.ReadAllText(file, Encoding.UTF8);

                            string settingsFilePath = Path.Combine(documentsPath, "Labelprintingsttings.dll");

                            if (!File.Exists(settingsFilePath))
                            {
                                MessageBox.Show("Printer settings file not found, Set the Printer Settings ");
                                //return;
                            }

                            //Printing
                            else
                            {



                                string printerJson = File.ReadAllText(settingsFilePath, Encoding.UTF8);
                                JArray printersArray = JArray.Parse(printerJson);

                                foreach (var printerItem in printersArray)
                                {
                                    string printerName = printerItem["PrinterName"]?.ToString();
                                    bool isDefault = printerItem["IsDefault"]?.Value<bool>() ?? false;
                                    bool isKitchen = printerItem["IsKitchenPrinter"]?.Value<bool>() ?? false;
                                    bool IsBoth = printerItem["IsBoth"]?.Value<bool>() ?? false;
                                    
                                    if (string.IsNullOrEmpty(printerName) || !isDefault)
                                        continue;

                                    // Case 1: Send to BOTH Kitchen and Receipt
                                    if (IsBoth)
                                    {
                                        // ===== Receipt =====
                                        ReceiptData receipt = JsonConvert.DeserializeObject<ReceiptData>(json);
                                        if (receipt == null)
                                            throw new Exception("Receipt data deserialization failed");

                                        SaveQRCode(receipt.QRCode, receipt.InvoiceNo);

                                        ReceiptPrinter receiptPrinter = new ReceiptPrinter(receipt);
                                        receiptPrinter.PrintReceipt1(printerName);

                                        // ===== Kitchen =====
                                        KitchenData kitchen = JsonConvert.DeserializeObject<KitchenData>(json);
                                        if (kitchen == null)
                                            throw new Exception("Kitchen data deserialization failed");

                                        if (kitchen.itemlist != null && kitchen.itemlist.Any(i => i.IsKitchenItem))
                                        {
                                            kitchen.itemlist = kitchen.itemlist
                                                                        .Where(i => i.IsKitchenItem)
                                                                        .ToList();

                                            ReceiptPrinter kitchenPrinter = new ReceiptPrinter(kitchen);
                                            kitchenPrinter.PrintKitchenReceipt(printerName);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"No Kitchen Item on Invoice label file {fileName}");
                                        }
                                    }

                                    // Case 2: Receipt ONLY
                                    else if (!isKitchen)
                                    {
                                        ReceiptData receipt = JsonConvert.DeserializeObject<ReceiptData>(json);
                                        if (receipt == null)
                                            throw new Exception("Receipt data deserialization failed");

                                        SaveQRCode(receipt.QRCode, receipt.InvoiceNo);

                                        ReceiptPrinter printer = new ReceiptPrinter(receipt);
                                        printer.PrintReceipt1(printerName);
                                    }

                                    // Case 3: Kitchen ONLY
                                    else
                                    {
                                        KitchenData kitchen = JsonConvert.DeserializeObject<KitchenData>(json);
                                        if (kitchen == null)
                                            throw new Exception("Kitchen data deserialization failed");

                                        if (kitchen.itemlist == null || !kitchen.itemlist.Any(i => i.IsKitchenItem))
                                        {
                                            Console.WriteLine($"No Kitchen Item on Invoice label file {fileName}");
                                            return;
                                        }

                                        kitchen.itemlist = kitchen.itemlist
                                                                    .Where(i => i.IsKitchenItem)
                                                                    .ToList();

                                        ReceiptPrinter printer = new ReceiptPrinter(kitchen);
                                        printer.PrintKitchenReceipt(printerName);
                                    }




                                }

                                File.AppendAllText(printedFilesPath, fileName + Environment.NewLine);
                            }
                        
                        //end printing
                       
                        
                        
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error processing label file {fileName}: {ex.Message}");
                        }
                        }

                    await Task.Delay(3000);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in label monitoring loop: " + ex.Message);
                    await Task.Delay(3000);
                }
                finally
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblnotify.Text = "Waiting for invoice...";
                    }));
                }
            }
        }

        private void file_watcher_Renamed(object sender, RenamedEventArgs e)
        {
            // Removed unnecessary call to Printout() to prevent multiple background loops
        }

        private void file_watcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Not used
        }

        private void closeDayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClosedayreport frm = new frmClosedayreport();
            frm.ShowDialog();
        }

        private void labelPrintingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLabelPrinterSettings frm = new frmLabelPrinterSettings();
            frm.ShowDialog();
        }
    }
}