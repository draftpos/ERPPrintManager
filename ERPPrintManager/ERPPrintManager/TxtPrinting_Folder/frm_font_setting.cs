using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Interop;
//using Newtonsoft.Json;


namespace ERPPrintManager.TxtPrinting_Folder
{
    public partial class frm_font_setting : Form
    {
        //private string settingsFilePath;

        // Direct fields instead of a separate class
        private string ContentFontName = "Arial";
        private int ContentFontSize = 10;
        private string ContentFontStyle = "Regular";

        private string ContentHeaderFontName = "Arial";
        private int ContentHeaderSize = 11;
        private string ContentHeaderStyle = "Bold";

        private string SubheaderFontName = "Arial";
        private int SubheaderSize = 10;
        private string SubheaderStyle = "Bold";

        private string OrderContentFontName = "Arial";
        private int OrderContentFontSize = 10;
        private string OrderContentFontStyle = "Bold";

        public frm_font_setting()
        {
            InitializeComponent();
            if (this.DesignMode) return;

            string appDataFolder = Path.Combine(Application.StartupPath, "ERPPrintManager");
            //settingsFilePath = Path.Combine(appDataFolder, "font_settings.json");

            //SetDefaults();
            LoadSettingsFromFile();
        }

        //private void SetDefaults()
        //{
        //    ContentFontName = "Arial";
        //    ContentFontSize = 10;
        //    ContentFontStyle = "Regular";

        //    ContentHeaderFontName = "Arial";
        //    ContentHeaderSize = 11;
        //    ContentHeaderStyle = "Bold";

        //    SubheaderFontName = "Arial";
        //    SubheaderSize = 10;
        //    SubheaderStyle = "Bold";

        //    OrderContentFontName = "Arial";
        //    OrderContentFontSize = 10;
        //    OrderContentFontStyle = "Bold";
        //}



        private void frm_font_setting_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            try
            {
                // Populate font names
                InstalledFontCollection installedFonts = new InstalledFontCollection();
                foreach (FontFamily font in installedFonts.Families)
                {
                    cmbContentFontName.Items.Add(font.Name);
                    cmbContentHeaderFontName.Items.Add(font.Name);
                    cmbSubheaderFontName.Items.Add(font.Name);
                    cmbOrderContentFontName.Items.Add(font.Name);
                }

                // Load current values into controls
                cmbContentFontName.SelectedItem = ContentFontName;
                nudContentSize.Value = ContentFontSize;
                cmbContentStyle.SelectedItem = ContentFontStyle;

                cmbContentHeaderFontName.SelectedItem = ContentHeaderFontName;
                nudContentHeaderSize.Value = ContentHeaderSize;
                cmbContentHeaderStyle.SelectedItem = ContentHeaderStyle;

                cmbSubheaderFontName.SelectedItem = SubheaderFontName;
                nudSubheaderSize.Value = SubheaderSize;
                cmbSubheaderStyle.SelectedItem = SubheaderStyle;

                cmbOrderContentFontName.SelectedItem = OrderContentFontName;
                nudOrderContentSize.Value = OrderContentFontSize;
                cmbOrderContentStyle.SelectedItem = OrderContentFontStyle;

                UpdateSampleLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message);
            }
        }

        private void LoadFonts()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();

            foreach (FontFamily font in installedFonts.Families)
            {
                cmbContentFontName.Items.Add(font.Name);
                cmbContentHeaderFontName.Items.Add(font.Name);
                cmbSubheaderFontName.Items.Add(font.Name);
                cmbOrderContentFontName.Items.Add(font.Name);
            }
        }

        private void cmbFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            UpdateSettingsFromControls();
            UpdateSampleLabels();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            UpdateSettingsFromControls();
            UpdateSampleLabels();
        }

        private void cmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            UpdateSettingsFromControls();
            UpdateSampleLabels();
        }

        private void UpdateSettingsFromControls()
        {
            ContentFontName = cmbContentFontName.SelectedItem?.ToString() ?? "Arial";
            ContentFontSize = (int)nudContentSize.Value;
            ContentFontStyle = cmbContentStyle.SelectedItem?.ToString() ?? "Regular";

            ContentHeaderFontName = cmbContentHeaderFontName.SelectedItem?.ToString() ?? "Arial";
            ContentHeaderSize = (int)nudContentHeaderSize.Value;
            ContentHeaderStyle = cmbContentHeaderStyle.SelectedItem?.ToString() ?? "Bold";

            SubheaderFontName = cmbSubheaderFontName.SelectedItem?.ToString() ?? "Arial";
            SubheaderSize = (int)nudSubheaderSize.Value;
            SubheaderStyle = cmbSubheaderStyle.SelectedItem?.ToString() ?? "Bold";

            OrderContentFontName = cmbOrderContentFontName.SelectedItem?.ToString() ?? "Arial";
            OrderContentFontSize = (int)nudOrderContentSize.Value;
            OrderContentFontStyle = cmbOrderContentStyle.SelectedItem?.ToString() ?? "Bold";
        }

        private void UpdateSampleLabels()
        {
            lblContentSample.Font = CreateFont(ContentFontName, ContentFontSize, ContentFontStyle);
            lblContentHeaderSample.Font = CreateFont(ContentHeaderFontName, ContentHeaderSize, ContentHeaderStyle);
            lblSubheaderSample.Font = CreateFont(SubheaderFontName, SubheaderSize, SubheaderStyle);
            lblOrderContentSample.Font = CreateFont(OrderContentFontName, OrderContentFontSize, OrderContentFontStyle);
        }

        private Font CreateFont(string fontName, int size, string styleStr)
        {
            FontStyle style = FontStyle.Regular;
            if (styleStr == "Bold") style = FontStyle.Bold;
            else if (styleStr == "Italic") style = FontStyle.Italic;
            else if (styleStr == "Bold Italic") style = FontStyle.Bold | FontStyle.Italic;

            try
            {
                return new Font(fontName, size, style);
            }
            catch
            {
                return new Font("Arial", size, style);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            UpdateSettingsFromControls();
            SaveSettingsToFile();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.Close();
        }

        private string JsonEscape(string input)
        {
            if (input == null) return "null";
            return input.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        private void SaveSettingsToFile()
        {
            try
            {
                string directory = Path.GetDirectoryName(Program.SettingsFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var lines = new List<string>
                {
                    $"\"ContentFontName\": \"{JsonEscape(ContentFontName)}\"",
                    $"\"ContentFontSize\": {ContentFontSize}",
                    $"\"ContentFontStyle\": \"{JsonEscape(ContentFontStyle)}\"",
                    $"\"ContentHeaderFontName\": \"{JsonEscape(ContentHeaderFontName)}\"",
                    $"\"ContentHeaderSize\": {ContentHeaderSize}",
                    $"\"ContentHeaderStyle\": \"{JsonEscape(ContentHeaderStyle)}\"",
                    $"\"SubheaderFontName\": \"{JsonEscape(SubheaderFontName)}\"",
                    $"\"SubheaderSize\": {SubheaderSize}",
                    $"\"SubheaderStyle\": \"{JsonEscape(SubheaderStyle)}\"",
                    $"\"OrderContentFontName\": \"{JsonEscape(OrderContentFontName)}\"",
                    $"\"OrderContentFontSize\": {OrderContentFontSize}",
                    $"\"OrderContentStyle\": \"{JsonEscape(OrderContentFontStyle)}\""
                };

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("{");
                sb.AppendLine("  " + string.Join(",\n  ", lines));
                sb.AppendLine("}");

                File.WriteAllText(Program.SettingsFilePath, sb.ToString());

                MessageBox.Show("Settings saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message);
            }
        }




            
        public Icon CreateIconFromFont(string fontName, string text, float size)
        {
            Bitmap bmp = new Bitmap(64, 64);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Font font = new Font(fontName, size, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.DrawString(text, font, Brushes.Black, new PointF(0, 0));
                }
            }

            IntPtr hIcon = bmp.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            return icon;
        }

        //private void frm_font_setting_Load_1(object sender, EventArgs e)
        //{
        //    this.Icon = CreateIconFromFont("Font Awesome 6 Free", "\uf007", 48);
        //    LoadFonts();
        //}

        private void frm_font_setting_Load_2(object sender, EventArgs e)
        {
            this.Icon = CreateIconFromFont("Font Awesome 6 Free", "\uf007", 48);
                        LoadFonts();
            LoadSettingsFromFile();
        }


        private void LoadSettingsFromFile()
        {
            //MessageBox.Show("Loading");

            if (!File.Exists(Program.SettingsFilePath))
            {
                //MessageBox.Show("No Exist");
                return;
            }

            try
            {
                //string json = File.ReadAllText(settingsFilePath);

                //var settings = JsonSerializer.Deserialize<FontSettings>(json);
                string json = File.ReadAllText(Program.SettingsFilePath);
                var settings = JsonConvert.DeserializeObject<FontSettings>(json);

                if (settings == null) return;

                ContentFontName = settings.ContentFontName;
                cmbContentFontName.Text = settings.ContentFontName;
                ContentFontSize = settings.ContentFontSize;
               
                nudContentSize.Text = (settings.ContentFontSize).ToString();
                ContentFontStyle = settings.ContentFontStyle;
                cmbContentStyle.Text = settings.ContentFontStyle;

                ContentHeaderFontName = settings.ContentHeaderFontName;
                ContentHeaderSize = settings.ContentHeaderSize;
                ContentHeaderStyle = settings.ContentHeaderStyle;
                
                cmbContentHeaderFontName.Text = settings.ContentHeaderFontName;
                nudContentHeaderSize.Text = (settings.ContentHeaderSize).ToString();
                cmbContentHeaderStyle.Text= settings.ContentHeaderStyle;




                SubheaderFontName = settings.SubheaderFontName;
                SubheaderSize = settings.SubheaderSize;
                SubheaderStyle = settings.SubheaderStyle;

                cmbSubheaderFontName.Text = settings.SubheaderFontName;
                nudSubheaderSize.Text = (settings.SubheaderSize).ToString();
                cmbSubheaderStyle.Text = settings.SubheaderStyle;



                OrderContentFontName = settings.OrderContentFontName;
                OrderContentFontSize = settings.OrderContentFontSize;
                OrderContentFontStyle = settings.OrderContentFontStyle;


                cmbOrderContentFontName.Text = settings.OrderContentFontName;
                nudOrderContentSize.Text = (settings.OrderContentFontSize).ToString();
               cmbOrderContentStyle.Text = settings.OrderContentFontStyle;

                //MessageBox.Show("Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public class FontSettings
        {
            public string ContentFontName { get; set; }
            public int ContentFontSize { get; set; }
            public string ContentFontStyle { get; set; }

            public string ContentHeaderFontName { get; set; }
            public int ContentHeaderSize { get; set; }
            public string ContentHeaderStyle { get; set; }

            public string SubheaderFontName { get; set; }
            public int SubheaderSize { get; set; }
            public string SubheaderStyle { get; set; }

            public string OrderContentFontName { get; set; }
            public int OrderContentFontSize { get; set; }
            public string OrderContentFontStyle { get; set; }
        }


    }
}