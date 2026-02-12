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
using Newtonsoft.Json;
using System.Drawing.Imaging; // Assuming Json.NET for serialization/deserialization

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBoxLogo.Image == null)
            {
                MessageBox.Show("Please load a logo image first.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Store the original format for saving later (preserves PNG/JPEG/etc.)
            ImageFormat originalFormat = pictureBoxLogo.Image.RawFormat;

            // Work on a copy of the current image
            Bitmap bmp = new Bitmap(pictureBoxLogo.Image);

            // Detect background color from top-left corner (common for padded logos)
            Color bgColor = bmp.GetPixel(0, 0);

            // Decide if the background appears transparent
            bool transparentBg = bgColor.A < 50;

            // Threshold for considering a pixel "blank" when background is transparent
            int alphaThreshold = 20;

            // Find the bounding box of non-blank pixels
            int left = bmp.Width;
            int top = bmp.Height;
            int right = -1;
            int bottom = -1;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    bool isBlank = false;

                    if (transparentBg)
                    {
                        // Transparent background: blank if low alpha
                        if (pixel.A <= alphaThreshold)
                            isBlank = true;
                    }
                    else
                    {
                        // Opaque background (e.g., white): blank if exact match to corner color
                        if (pixel == bgColor)
                            isBlank = true;
                    }

                    if (!isBlank)
                    {
                        if (x < left) left = x;
                        if (x > right) right = x;
                        if (y < top) top = y;
                        if (y > bottom) bottom = y;
                    }
                }
            }

            bmp.Dispose();

            // No content found
            if (right < left)
            {
                MessageBox.Show("No content detected in the image.", "Blank Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int croppedWidth = right - left + 1;
            int croppedHeight = bottom - top + 1;

            // No blank borders detected
            if (croppedWidth >= pictureBoxLogo.Image.Width && croppedHeight >= pictureBoxLogo.Image.Height)
            {
                MessageBox.Show("No blank space detected to remove. The image is already tightly cropped or has non-uniform borders.", "No Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create the cropped bitmap
            Rectangle cropRect = new Rectangle(left, top, croppedWidth, croppedHeight);
            Bitmap croppedBitmap = new Bitmap(pictureBoxLogo.Image); // full copy first
            croppedBitmap = croppedBitmap.Clone(cropRect, croppedBitmap.PixelFormat);

            // Preview: replace the image in the PictureBox
            if (pictureBoxLogo.Image != null)
            {
                pictureBoxLogo.Image.Dispose();
                pictureBoxLogo.Image = null;
            }
            pictureBoxLogo.Image = croppedBitmap;
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom; // adjust if you use a different mode

            // Ask user to confirm
            DialogResult result = MessageBox.Show(
                "Preview: Blank space (transparent or uniform background) has been removed.\n\nDo you want to save this cropped version as the new logo?",
                "Confirm Edit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Save the cropped version over the original file
                croppedBitmap.Save(LogoPath, originalFormat);
                MessageBox.Show("Logo successfully cropped and saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cancel: discard cropped image and reload original
                croppedBitmap.Dispose();
                LoadLogo();
                MessageBox.Show("Edit cancelled. Original logo restored.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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