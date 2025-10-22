using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextERPPrintLib.ReceiptLibrary;

namespace ERPPrintManager
{
    public class LabelPrintingClass
    {
        private string txtPrintingPath;
        private string printedFilesPath;

        public async Task Printout()
        {
            while (true)
            {
                try
                {
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string pathConfigFile = Path.Combine(documentsPath, "TxtPrintingPath.txt");
                    printedFilesPath = Path.Combine(documentsPath, "PrintedFiles.txt");
                    if (File.Exists(pathConfigFile))
                        txtPrintingPath = File.ReadAllText(pathConfigFile).Trim();
                    else
                        txtPrintingPath = Path.Combine(documentsPath, "TxtPrinting");
                    if (!Directory.Exists(txtPrintingPath))
                    {
                        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                        {
                            dialog.Description = "Select a directory for  Label Printing Text files";
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

                    // Load printed file names
                    var printedFiles = new HashSet<string>(
                        File.ReadAllLines(printedFilesPath),
                        StringComparer.OrdinalIgnoreCase
                    );

                    // Get all .json and .txt files
                    var allFiles = Directory.GetFiles(txtPrintingPath, "*.*", SearchOption.TopDirectoryOnly)
                                            .Where(f => f.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ||
                                                        f.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                                            .ToList();

                    if (allFiles.Count == 0)
                    {
                        // No need to alert every 30 seconds
                        await Task.Delay(30000);
                        continue;
                    }

                    bool printedSomething = false;
                    foreach (var file in allFiles)
                    {
                        string fileName = Path.GetFileName(file);

                        // Skip if already printed
                        if (printedFiles.Contains(fileName))
                            continue;

                        try
                        {
                            string jsonContent = File.ReadAllText(file, Encoding.UTF8);
                            JObject root = JObject.Parse(jsonContent);

                            string companyName = root.Value<string>("CompanyName") ?? "";
                            string cashier = root.Value<string>("CashierName") ?? "";
                            string customer = root.Value<string>("CustomerName") ?? "";
                            string invoiceNo = root.Value<string>("InvoiceNo") ?? "";
                            string dosageInstruction = root.Value<string>("DosageInstruction") ?? "";
                            string pharmacistName = root.Value<string>("PharmacistName") ?? "";
                            string patientName = root.Value<string>("PatientName") ?? customer;

                            var items = new List<(string ProductName, string Qty, string Expiry)>();
                            var itemList = root["itemlist"] as JArray;

                            if (itemList != null)
                            {
                                foreach (var item in itemList)
                                {
                                    string pname = item.Value<string>("ProductName") ?? "";
                                    string qty = item.Value<string>("Qty") ?? "";
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

                            summaryBuilder.AppendLine($"Dosage: {dosageInstruction}");
                            summaryBuilder.AppendLine($"Pharmacist: {cashier}");
                            summaryBuilder.AppendLine($"Patient: {customer}");
                            summaryBuilder.AppendLine($"Shop: {companyName}");

                            string summary = summaryBuilder.ToString();

                            // Print
                            var printer = new EncryptedTextPrinting();
                            var settings = AdvanceDataManager.GetAdvanceData();
                            string settingsFilePath = Path.Combine(documentsPath, "Labelprintingsttings.dll");
                            // printer.PrintReceipt(summary, 1, null, settings, "Prescription Order", "", "Microsoft Print to PDF", DateTime.Now.ToString());

                              string selectedPrinter;//= "Microsoft Print to PDF"; // fallback default
                            string printerJson = File.ReadAllText(settingsFilePath, Encoding.UTF8);
                            JArray printersArray = JArray.Parse(printerJson);
                            try
                            {

                           
                            foreach (var printer1 in printersArray)
                            {
                                string printerName = printer1.Value<string>("PrinterName") ?? "(Unknown)";
                                bool isDefault = printer1.Value<bool?>("IsDefault") ?? false;
                                selectedPrinter = printerName;
                                if (isDefault)
                                {
                                    printer.PrintReceipt(
                                             summary,
                                             1,
                                             null,
                                             settings,
                                             "Prescription Order",
                                             "",
                                             selectedPrinter,
                                             DateTime.Now.ToString()
                                         );

                                }
                                }
                            }
                                                        catch (Exception ex)
                            {
                               // MessageBox.Show("Error: " + ex.Message);
                            }
                            MessageBox.Show(printedFilesPath + fileName);
                    File.AppendAllText(printedFilesPath, fileName + Environment.NewLine);
                            printedSomething = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error processing file {fileName}: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
              //  MessageBox.Show($"Succeded processing file");

                // Wait 30 seconds before next check
                await Task.Delay(15000);
            }
        }



    }
}