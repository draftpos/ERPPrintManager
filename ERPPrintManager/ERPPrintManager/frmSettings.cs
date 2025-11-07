using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    cmbSelectMultiple.Items.Add(printer);
                }
                cmbPrinter.Text = "Select Printer";
                cmbSelectMultiple.Text = "Select Printer";

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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstprinter.SelectedItem != null)
            {
                lstprinter.Items.Remove(lstprinter.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select printer to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((cmbSelectMultiple.Text == "Select Printer") || (cmbSelectMultiple.Text == ""))
            {
                MessageBox.Show(
                    this, "Please select Printer", "No Printer selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!lstprinter.Items.Contains(cmbSelectMultiple.Text))
            {
                lstprinter.Items.Add(cmbSelectMultiple.Text);
            }
        }

        private void btnSetMultiplePrinter_Click(object sender, EventArgs e)
        {
            if (lstprinter.Items.Count == 0)
            {
                MessageBox.Show("Please Add printer to the list.", "No Printer Added",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (OptMultiple.Checked)
            {
                SavePrinterList();
                MessageBox.Show(
                       this, "All Seleted Printer Saved", "ERPPrint Manager",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OptMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (OptMultiple.Checked)
            {
                this.Size = new Size(471, 355);
                panel_single.Visible = false;
                panel_multi.Visible = true;

            }
        }

        private void OptSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (OptSingle.Checked)
            {
                this.Size = new Size(471, 203);
                panel_single.Visible = true;
                panel_multi.Visible = false;
            }
        }
        private void SavePrinterList()
        {

            StringCollection collection = new StringCollection();

            foreach (var item in lstprinter.Items)
            {
                collection.Add(item.ToString());
            }

            Properties.Settings.Default.MultiplePrinterList = collection;
            Properties.Settings.Default.IsMultiplePrinter = true;
            Properties.Settings.Default.IsSinglePrinter = false;
            Properties.Settings.Default.DefaultPrinter = "";
            Properties.Settings.Default.Save(); // persist to user.config
        }

        // Load listBox items from Properties.Settings
        private void LoadPrinterList()
        {
            if (Properties.Settings.Default.MultiplePrinterList != null)
            {
                lstprinter.Items.Clear();

                foreach (string item in Properties.Settings.Default.MultiplePrinterList)
                {
                    lstprinter.Items.Add(item);
                }
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            PopulateInstalledPrinters();
            if (ERPPrintManager.Properties.Settings.Default.IsSinglePrinter)
            {
                cmbPrinter.Text = ERPPrintManager.Properties.Settings.Default.DefaultPrinter;
            }
            if (ERPPrintManager.Properties.Settings.Default.IsMultiplePrinter)
            {
                OptMultiple.Checked = true;
                LoadPrinterList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((cmbPrinter.Text == "Select Printer") || (cmbPrinter.Text == ""))
            {
                MessageBox.Show(
                    this, "Please select Printer", "No Printer selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (OptSingle.Checked)
            {
                ERPPrintManager.Properties.Settings.Default.DefaultPrinter = cmbPrinter.Text;
                ERPPrintManager.Properties.Settings.Default.IsSinglePrinter = true;
                Properties.Settings.Default.IsMultiplePrinter = false;
                try
                {
                    if (ERPPrintManager.Properties.Settings.Default.MultiplePrinterList != null)
                        Properties.Settings.Default.MultiplePrinterList.Clear();
                }
                catch (Exception ex)
                {
                }

                ERPPrintManager.Properties.Settings.Default.Save();
                MessageBox.Show(
                        this, "Default Printer Saved", "ERPPrint Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
