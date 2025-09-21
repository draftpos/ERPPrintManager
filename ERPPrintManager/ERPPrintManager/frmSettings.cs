using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPPrintManager
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (cmbPrinter.Text == "")
            {
                MessageBox.Show(
                    this,
                    "Please select Printer",
                    "No Printer selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            ERPPrintManager.Properties.Settings.Default.DefaultPrinter = cmbPrinter.Text;
            ERPPrintManager.Properties.Settings.Default.Save();
            MessageBox.Show(
                    this,
                    "Default Printer Saved",
                    "Invoice Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        public void PopulateInstalledPrinters()
        {
            try
            {
                // Clear existing items
                cmbPrinter.Items.Clear();

                // Add list of installed printers found to the combo box
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cmbPrinter.Items.Add(printer);
                }
                cmbPrinter.Text = "Select Printer";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void frmSettings_Load(object sender, EventArgs e)
        {
            PopulateInstalledPrinters();
            cmbPrinter.Text = ERPPrintManager.Properties.Settings.Default.DefaultPrinter;
        }
    }
}
