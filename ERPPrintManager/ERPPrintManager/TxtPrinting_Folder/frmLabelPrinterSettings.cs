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
            settingsFilePath = Path.Combine(documentsPath, "LabelPrinterSettings.json");
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
                    printerSettings = JsonConvert.DeserializeObject<List<PrinterSetting>>(json)
                                      ?? new List<PrinterSetting>();

                    var allPrinters = PrinterSettingsHelper.GetAllPrintersWithDefaultStatus();
                    foreach (var printer in allPrinters)
                    {
                        if (!printerSettings.Any(p => p.PrinterName.Equals(printer.PrinterName, StringComparison.OrdinalIgnoreCase)))
                        {
                            printerSettings.Add(printer);
                        }
                    }

                    // Sort for consistent display order
                    printerSettings = printerSettings.OrderBy(p => p.PrinterName).ToList();

                    SavePrinterSettings();
                }

                PopulateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printer settings:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDataGridView()
        {
            // Columns are now defined in the Designer (Available Printer + 14 checkbox columns)
            // We no longer add them here to avoid conflicts with the designer

            dataGridView1.Rows.Clear();

            foreach (var printer in printerSettings)
            {
                int rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];

                row.Cells[0].Value = printer.PrinterName;            // Available Printer (text)
                row.Cells[1].Value = printer.IsDefault;              // Status
                row.Cells[2].Value = printer.IsKitchenPrinter;       // IsKitchen Printer
                row.Cells[3].Value = printer.IsAll;                  // All
                row.Cells[4].Value = printer.IsMain;                 // MAIN
                row.Cells[5].Value = printer.IsOrder1;               // ORDER1
                row.Cells[6].Value = printer.IsOrder2;               // ORDER2
                row.Cells[7].Value = printer.IsOrder3;               // ORDER3
                row.Cells[8].Value = printer.IsOrder4;               // ORDER4
                row.Cells[9].Value = printer.IsOrder5;               // ORDER5
                row.Cells[10].Value = printer.IsOrder6;              // ORDER6
                row.Cells[11].Value = printer.IsOrder7;              // ORDER7
                row.Cells[12].Value = printer.IsOrder8;              // ORDER8
                row.Cells[13].Value = printer.IsOrder9;              // ORDER9
                row.Cells[14].Value = printer.IsOrder10;             // ORDER10
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
                MessageBox.Show("Error saving settings:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bool isAll = row.Cells[3].Value is bool b3 && b3;
                bool isMain = row.Cells[4].Value is bool b4 && b4;
                bool isOrder1 = row.Cells[5].Value is bool o1 && o1;
                bool isOrder2 = row.Cells[6].Value is bool o2 && o2;
                bool isOrder3 = row.Cells[7].Value is bool o3 && o3;
                bool isOrder4 = row.Cells[8].Value is bool o4 && o4;
                bool isOrder5 = row.Cells[9].Value is bool o5 && o5;
                bool isOrder6 = row.Cells[10].Value is bool o6 && o6;
                bool isOrder7 = row.Cells[11].Value is bool o7 && o7;
                bool isOrder8 = row.Cells[12].Value is bool o8 && o8;
                bool isOrder9 = row.Cells[13].Value is bool o9 && o9;
                bool isOrder10 = row.Cells[14].Value is bool o10 && o10;

                var printer = printerSettings.FirstOrDefault(p =>
                    p.PrinterName.Equals(printerName, StringComparison.OrdinalIgnoreCase));

                if (printer != null)
                {
                    printer.IsDefault = isDefault;
                    printer.IsKitchenPrinter = isKitchen;
                    printer.IsAll = isAll;
                    printer.IsMain = isMain;
                    printer.IsOrder1 = isOrder1;
                    printer.IsOrder2 = isOrder2;
                    printer.IsOrder3 = isOrder3;
                    printer.IsOrder4 = isOrder4;
                    printer.IsOrder5 = isOrder5;
                    printer.IsOrder6 = isOrder6;
                    printer.IsOrder7 = isOrder7;
                    printer.IsOrder8 = isOrder8;
                    printer.IsOrder9 = isOrder9;
                    printer.IsOrder10 = isOrder10;
                }
            }

            SavePrinterSettings();
            MessageBox.Show("Printer settings saved successfully!",
                            "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Data model - expanded with All, MAIN, and ORDER1–ORDER10
    public class PrinterSetting
    {
        public string PrinterName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsKitchenPrinter { get; set; }
        public bool IsAll { get; set; }
        public bool IsMain { get; set; }
        public bool IsOrder1 { get; set; }
        public bool IsOrder2 { get; set; }
        public bool IsOrder3 { get; set; }
        public bool IsOrder4 { get; set; }
        public bool IsOrder5 { get; set; }
        public bool IsOrder6 { get; set; }
        public bool IsOrder7 { get; set; }
        public bool IsOrder8 { get; set; }
        public bool IsOrder9 { get; set; }
        public bool IsOrder10 { get; set; }
    }

    // Helper to get system printers
    public static class PrinterSettingsHelper
    {
        public static List<PrinterSetting> GetAllPrintersWithDefaultStatus()
        {
            var printers = new List<PrinterSetting>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                // All bool properties default to false automatically
                printers.Add(new PrinterSetting { PrinterName = printer });
            }
            return printers;
        }
    }
}