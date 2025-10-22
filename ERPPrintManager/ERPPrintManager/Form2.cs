using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using TextERPPrintLib.ReceiptLibrary;

namespace ERPPrintManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string txtPrintingPath;
        private string printedFilesPath;

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pathConfigFile = Path.Combine(documentsPath, "TxtPrintingPath.txt");
                printedFilesPath = Path.Combine(documentsPath, "PrintedFiles.txt");

                // Load saved path or set default
                if (File.Exists(pathConfigFile))
                    txtPrintingPath = File.ReadAllText(pathConfigFile).Trim();
                else
                    txtPrintingPath = Path.Combine(documentsPath, "TxtPrinting");

                // Ask user to select folder if it doesn't exist
                if (!Directory.Exists(txtPrintingPath))
                {
                    using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                    {
                        dialog.Description = "Select a directory for TxtPrinting files";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            txtPrintingPath = dialog.SelectedPath;
                            Directory.CreateDirectory(txtPrintingPath);
                            File.WriteAllText(pathConfigFile, txtPrintingPath);
                        }
                        else
                        {
                            MessageBox.Show("No directory selected. Printing aborted.");
                            return;
                        }
                    }
                }

                // Ensure PrintedFiles.txt exists
                if (!File.Exists(printedFilesPath))
                    File.WriteAllText(printedFilesPath, string.Empty);

                // Load printed file names into a set
                var printedFiles = new HashSet<string>(
                    File.ReadAllLines(printedFilesPath),
                    StringComparer.OrdinalIgnoreCase
                );

                // Get all .json and .txt files
                var allFiles = Directory.GetFiles(txtPrintingPath, "*.*", SearchOption.TopDirectoryOnly);
                var jsonFiles = new List<string>();

                foreach (var file in allFiles)
                {
                    if (file.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        jsonFiles.Add(file);
                    }
                }

                if (jsonFiles.Count == 0)
                {
                    MessageBox.Show("No JSON or TXT files found in the TxtPrinting directory.");
                    return;
                }

                bool printedSomething = false;
                foreach (var file in jsonFiles)
                {
                    string fileName = Path.GetFileName(file);

                    // Skip if already printed
                    if (printedFiles.Contains(fileName))
                        continue;

                    try
                    {
                        string jsonContent = File.ReadAllText(file, Encoding.UTF8);
                        JObject root = JObject.Parse(jsonContent);

                        // Extract key fields safely
                        string companyName = root.Value<string>("CompanyName") ?? "";
                        string cashier = root.Value<string>("CashierName") ?? "";
                        string customer = root.Value<string>("CustomerName") ?? "";
                        string invoiceNo = root.Value<string>("InvoiceNo") ?? "";
                        string dosageInstruction = root.Value<string>("DosageInstruction") ?? "";
                        string pharmacistName = root.Value<string>("PharmacistName") ?? "";
                        string patientName = root.Value<string>("PatientName") ?? customer;

                        // Extract item list
                        var items = new List<(string ProductName, string Qty, string Expiry)>();
                        var itemList = root["itemlist"] as JArray;
                        if (itemList != null)
                        {
                            foreach (var item in itemList)
                            {
                                string pname = item.Value<string>("ProductName") ?? "";
                                string qty = $"Qty: {item.Value<string>("Qty") ?? ""}";
                                string expiry = item.Value<string>("ExpiryDate") ?? "";
                                items.Add((pname, qty, expiry));
                            }
                        }

                        // Build summary text
                        StringBuilder summaryBuilder = new StringBuilder();
                       

                        foreach (var i in items)
                        {
                            summaryBuilder.AppendLine($"{i.ProductName}");
                            if (!string.IsNullOrEmpty(i.Expiry) || !string.IsNullOrEmpty(i.Qty))
                                summaryBuilder.AppendLine($"Expiry: {i.Expiry}  Qty: {i.Qty}");
                            summaryBuilder.AppendLine();
                        }
                        //summaryBuilder.AppendLine("Items:");
                        // summaryBuilder.AppendLine();
                        summaryBuilder.AppendLine($"Dosage: {dosageInstruction}");
                        summaryBuilder.AppendLine($"Pharmacist: {cashier}");
                        summaryBuilder.AppendLine($"Patient: {customer}");
                        summaryBuilder.AppendLine($"Shop: {companyName}");

                        //summaryBuilder.AppendLine($"Shop: {companyName}");
                        //summaryBuilder.AppendLine($"Invoice No: {invoiceNo}");
                        //summaryBuilder.AppendLine($"Cashier: {cashier}");

                        string summary = summaryBuilder.ToString();

                        // Print
                        var printer = new EncryptedTextPrinting();
                        var settings = AdvanceDataManager.GetAdvanceData();
                        printer.PrintReceipt(summary, 1, null, settings, "Prescription Order", "", "Microsoft Print to PDF", DateTime.Now.ToString());

                        // Mark as printed
                        File.AppendAllText(printedFilesPath, fileName + Environment.NewLine);
                        printedSomething = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing file {fileName}: {ex.Message}");
                    }
                }

              //  MessageBox.Show(printedSomething ? "Printing completed successfully." : "No new files to print.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
