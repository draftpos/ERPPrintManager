using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ERPPrintManager
{
    public partial class frmLabelPrinterSettings : Form
    {
        private string settingsFilePath;
        private List<PrinterSetting> printerSettings;

        public frmLabelPrinterSettings()
        {
            InitializeComponent();
        }

        private void frmLabelPrinterSettings_Load(object sender, EventArgs e)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            settingsFilePath = Path.Combine(documentsPath, "Labelprintingsttings.dll");
            LoadPrinterSettings();
        }

        private void LoadPrinterSettings()
        {
            try
            {
                if (!File.Exists(settingsFilePath))
                {
                    printerSettings = PrinterSettingsHelper.GetAllPrintersWithDefaultStatus();
                    SavePrinterSettings();
                }
                else
                {
                    string json = File.ReadAllText(settingsFilePath);
                    printerSettings = JsonConvert.DeserializeObject<List<PrinterSetting>>(json) ?? new List<PrinterSetting>();

                    var allPrinters = PrinterSettingsHelper.GetAllPrintersWithDefaultStatus();
                    foreach (var printer in allPrinters)
                    {
                        if (!printerSettings.Any(p => p.PrinterName.Equals(printer.PrinterName, StringComparison.OrdinalIgnoreCase)))
                        {
                            printerSettings.Add(printer);
                        }
                    }

                    SavePrinterSettings();
                }

                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printer settings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView()
        {
            // Add columns only once
            if (dataGridView1.Columns.Count == 0)
            {
                var colPrinter = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Available Printer",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };

                var colStatus = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Status",
                    Width = 100
                };

                var colKitchen = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Is Kitchen",
                    Width = 120
                };

                dataGridView1.Columns.Add(colPrinter);
                dataGridView1.Columns.Add(colStatus);
                dataGridView1.Columns.Add(colKitchen);
            }

            // Clear rows only
            dataGridView1.Rows.Clear();

            // Fill rows using column indices
            foreach (var printer in printerSettings)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = printer.PrinterName;
                dataGridView1.Rows[rowIndex].Cells[1].Value = printer.IsDefault;
                dataGridView1.Rows[rowIndex].Cells[2].Value = printer.IsKitchenPrinter;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        private void SavePrinterSettings()
        {
            try
            {
                string json = JsonConvert.SerializeObject(printerSettings, Formatting.Indented);
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[0].Value == null) continue;

                string printerName = row.Cells[0].Value.ToString();

                bool isDefault = row.Cells[1].Value is bool b1 && b1;
                bool isKitchen = row.Cells[2].Value is bool b2 && b2;

                var printer = printerSettings.FirstOrDefault(p => p.PrinterName.Equals(printerName, StringComparison.OrdinalIgnoreCase));
                if (printer != null)
                {
                    printer.IsDefault = isDefault;
                    printer.IsKitchenPrinter = isKitchen;
                }
            }

            SavePrinterSettings();
            MessageBox.Show("Printer settings saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Data model
    public class PrinterSetting
    {
        public string PrinterName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsKitchenPrinter { get; set; }
    }

    // Helper to get system printers
    public static class PrinterSettingsHelper
    {
        public static List<PrinterSetting> GetAllPrintersWithDefaultStatus()
        {
            var printers = new List<PrinterSetting>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printers.Add(new PrinterSetting
                {
                    PrinterName = printer,
                    IsDefault = false,
                    IsKitchenPrinter = false
                });
            }
            return printers;
        }
    }
}