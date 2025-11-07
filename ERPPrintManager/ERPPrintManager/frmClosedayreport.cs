using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPPrintManager
{
    public partial class frmClosedayreport : Form
    {
        public frmClosedayreport()
        {
            InitializeComponent();
        }

        private void btnSaveAPIData_Click(object sender, EventArgs e)
        {
            if  (txtAPI.Text.Trim() == "")
            {
                MessageBox.Show(
                    this, "Please enter API key", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSecret.Text.Trim() == "")
            {
                MessageBox.Show(
                    this, "Please enter Secret key", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtdeviceserialno.Text.Trim() == "")
            {
                MessageBox.Show(
                    this, "Please enter device serial number", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ERPPrintManager.Properties.Settings.Default.API = txtAPI.Text;
            ERPPrintManager.Properties.Settings.Default.Secret = txtSecret.Text;
            ERPPrintManager.Properties.Settings.Default.DeviceSerialNo = txtdeviceserialno.Text;
            ERPPrintManager.Properties.Settings.Default.ServerAddress = txtserver.Text;
            ERPPrintManager.Properties.Settings.Default.Save();
            MessageBox.Show(
                   this, "API Information successfully saved", "API Data Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmClosedayreport_Load(object sender, EventArgs e)
        {
            try
            {
                txtAPI.Text = ERPPrintManager.Properties.Settings.Default.API;
                txtSecret.Text = ERPPrintManager.Properties.Settings.Default.Secret;
                txtdeviceserialno.Text = ERPPrintManager.Properties.Settings.Default.DeviceSerialNo;
                txtserver.Text = ERPPrintManager.Properties.Settings.Default.ServerAddress;

                txtCompanyName.Text = ERPPrintManager.Properties.Settings.Default.CompanyName;
                txtAddress.Text = ERPPrintManager.Properties.Settings.Default.Address;
                txtEmail.Text = ERPPrintManager.Properties.Settings.Default.Email;
                txtPhoneNo.Text = ERPPrintManager.Properties.Settings.Default.PhoneNo;
                txtTIN.Text = ERPPrintManager.Properties.Settings.Default.TIN;
                txtVat.Text = ERPPrintManager.Properties.Settings.Default.VAT;

            }
            catch (Exception ex)
            {

            }
        
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtFiscalDay.Text.Trim() == "")
            {
                MessageBox.Show(
                    this, "Please enter Fiscal Day number (e.g 1)", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string input = txtFiscalDay.Text;

            if (!int.TryParse(input, out int value))
            {
                MessageBox.Show(
                   this, "The value is not a valid integer. Please enter valid number (e.g 1)", "No Data",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                Zimra zm = new Zimra();
                var json = "";
                json = await zm.SendZimraRequest(txtFiscalDay.Text);
                CloseDayData receipt = JsonConvert.DeserializeObject<CloseDayData>(json);
                ReceiptPrinter printer = new ReceiptPrinter(receipt, true);
                printer.PrintCloseDayReport(Properties.Settings.Default.DefaultPrinter);

                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                  this, ex.Message, "Error Retreiving Record",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnSaveCompanyInfo_Click(object sender, EventArgs e)
        {
           

            ERPPrintManager.Properties.Settings.Default.CompanyName = txtCompanyName.Text;
            ERPPrintManager.Properties.Settings.Default.Address = txtAddress.Text;
            ERPPrintManager.Properties.Settings.Default.Email = txtEmail.Text;
            ERPPrintManager.Properties.Settings.Default.PhoneNo = txtPhoneNo.Text;
            ERPPrintManager.Properties.Settings.Default.TIN = txtTIN.Text;
            ERPPrintManager.Properties.Settings.Default.VAT = txtVat.Text;
            ERPPrintManager.Properties.Settings.Default.Save();
            MessageBox.Show(
                   this, "Company Information successfully saved", "Data Saved",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
