using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json; // Assuming Json.NET for serialization/deserialization

namespace ERPPrintManager.TxtPrinting_Folder
{
    public partial class frm_invoice_customization : Form
    {
        private InvoiceCustomization currentConfig;
        //private const string ConfigFilePath = "invoice_customization.json";
        private static readonly string ConfigFilePath =
    Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "invoice_customization.json"
    );
        private const string LogoDir = @"C:\logo";
        private const string LogoPath = @"C:\logo\logo.png";

        public frm_invoice_customization()
        {
            InitializeComponent();
        }

        private void frm_invoice_customization_Load(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
            LoadLogo();
        }

        private void LoadCurrentConfiguration()
        {
            if (File.Exists(ConfigFilePath))
            {
                string json = File.ReadAllText(ConfigFilePath);
                currentConfig = JsonConvert.DeserializeObject<InvoiceCustomization>(json);
                PopulateFormFromConfig(currentConfig);
            }
            else
            {
                ResetToDefault();
            }
        }

        private void PopulateFormFromConfig(InvoiceCustomization config)
        {
            txtType.Text = config.Type;
            chkVat.Checked = config.Vat;
            txtFooter.Text = config.Footer.Replace("\r\n", Environment.NewLine);
            chkSubtotalExcl.Checked = config.SubtotalExcl;
            chkInclusive.Checked = config.Inclusive;
            chkShowDescriptionLabel.Checked = config.ShowDescriptionLabel;
            chkShowProductNameLabel.Checked = config.ShowProductNameLabel;
            chkShowPaymentsLabel.Checked = config.ShowPaymentsLabel;
        }

        private InvoiceCustomization GetConfigFromForm()
        {
            return new InvoiceCustomization
            {
                Type = txtType.Text,
                Vat = chkVat.Checked,
                Footer = txtFooter.Text.Replace(Environment.NewLine, "\r\n"),
                SubtotalExcl = chkSubtotalExcl.Checked,
                Inclusive = chkInclusive.Checked,
                ShowDescriptionLabel = chkShowDescriptionLabel.Checked,
                ShowProductNameLabel = chkShowProductNameLabel.Checked,
                ShowPaymentsLabel = chkShowPaymentsLabel.Checked
            };
        }

        private void SaveConfiguration()
        {
            currentConfig = GetConfigFromForm();
            string json = JsonConvert.SerializeObject(currentConfig, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
            MessageBox.Show("Configuration saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetToDefault()
        {
            // Default values based on the provided JSON
            currentConfig = new InvoiceCustomization
            {
                Type = " invoice",
                Vat = false,
                Footer = "Havano Point of Sale v11\r\nThank you for your patronage\r\nPower by Havano",
                SubtotalExcl = false,
                Inclusive = false,
                ShowDescriptionLabel = false,
                ShowProductNameLabel = false,
                ShowPaymentsLabel = false
            };
            PopulateFormFromConfig(currentConfig);
        }

        private void LoadLogo()
        {
            if (File.Exists(LogoPath))
            {
                // Dispose old image first
                if (pictureBoxLogo.Image != null)
                {
                    pictureBoxLogo.Image.Dispose();
                    pictureBoxLogo.Image = null;
                }

                // Load without locking file
                using (var stream = new FileStream(LogoPath, FileMode.Open, FileAccess.Read))
                {
                    pictureBoxLogo.Image = Image.FromStream(stream);
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialogLogo.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialogLogo.FileName;

                if (!Directory.Exists(LogoDir))
                    Directory.CreateDirectory(LogoDir);

                // Release file lock before overwrite
                if (pictureBoxLogo.Image != null)
                {
                    pictureBoxLogo.Image.Dispose();
                    pictureBoxLogo.Image = null;
                }

                File.Copy(selectedFile, LogoPath, true);

                LoadLogo();

                MessageBox.Show("Logo uploaded successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }





        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void btnResetToDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset to default settings?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetToDefault();
            }
        }

        private void btnFetchCurrent_Click(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Assuming this class based on the JSON structure
    public class InvoiceCustomization
    {
        public string Type { get; set; }
        public bool Vat { get; set; }
        public string Footer { get; set; }
        public bool SubtotalExcl { get; set; }
        public bool Inclusive { get; set; }
        public bool ShowDescriptionLabel { get; set; }
        public bool ShowProductNameLabel { get; set; }
        public bool ShowPaymentsLabel { get; set; }
    }
}