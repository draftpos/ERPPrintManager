// AdvanceSettingsEditor.cs
// WinForms editor for Advance_settings_data
// Requires a reference to your AdvanceData.dll library.
// Adjust the AdvanceDataManager calls to match your library's API if needed.

using System;
using System.Drawing;
using System.Windows.Forms;

using TextERPPrintLib.ReceiptLibrary;

public class AdvanceSettingsEditorForm : Form
{
    // Controls
    private TableLayoutPanel table;
    private NumericUpDown nudContentFontSize;
    private ComboBox cbContentFontStyle;
    private NumericUpDown nudHeaderSize;
    private ComboBox cbHeaderStyle;
    private NumericUpDown nudSubheaderSize;
    private ComboBox cbSubheaderStyle;
    private NumericUpDown nudOrderContentSize;
    private ComboBox cbOrderContentStyle;
    private TextBox txtDMarkup;
    private TextBox txtLoyalPer;
    private CheckBox chkPhar, chkERP_P, chkDispatch, chkCusCharStat, chkOrderVisibility, chkAllowMultiPos, chkBatchesAdditional;
    private Button btnLoad, btnSave, btnResetDefaults;
    private Panel previewPanel;
    private Label previewLabel;

    // Current settings
    private Advance_settings_data settings;

    public AdvanceSettingsEditorForm()
    {
        Text = "Advance Settings Editor";
        Width = 600;
        Height = 500;
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9F, FontStyle.Regular);

        InitializeControls();
        WireEvents();

        // Load settings when form loads
        Load += (s, e) => LoadSettings();
    }

    private void InitializeControls()
    {
        table = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Height = 420,
            ColumnCount = 4,
            RowCount = 9,
            Padding = new Padding(12),
        };
        table.ColumnStyles.Clear();
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190)); // label
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // input
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        // Row labels and controls
        AddRow(0, "Content Font Size:", out nudContentFontSize, 6, 72);
        AddRowStyleCombo(0, 1, ref cbContentFontStyle);

        AddRow(1, "Content Header Size:", out nudHeaderSize, 6, 72);
        AddRowStyleCombo(1, 1, ref cbHeaderStyle);

        AddRow(2, "Subheader Size:", out nudSubheaderSize, 6, 72);
        AddRowStyleCombo(2, 1, ref cbSubheaderStyle);

        AddRow(3, "Order Content Size:", out nudOrderContentSize, 6, 72);
        AddRowStyleCombo(3, 1, ref cbOrderContentStyle);

        // Decimal inputs
        AddLabel(4, "Default Markup (%):");
        txtDMarkup = new TextBox { Dock = DockStyle.Fill };
        table.Controls.Add(txtDMarkup, 1, 4);

        AddLabel(4, "Loyalty Percent (%):", 2);
        txtLoyalPer = new TextBox { Dock = DockStyle.Fill };
        table.Controls.Add(txtLoyalPer, 3, 4);

        // Checkboxes row
        var chkPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
        chkPhar = new CheckBox { Text = "Pharmacy Mode", AutoSize = true };
        chkERP_P = new CheckBox { Text = "ERP_P", AutoSize = true };
        chkDispatch = new CheckBox { Text = "Dispatch", AutoSize = true };
        chkCusCharStat = new CheckBox { Text = "CusCharStat", AutoSize = true };
        chkOrderVisibility = new CheckBox { Text = "Order Visibility", AutoSize = true };
        chkAllowMultiPos = new CheckBox { Text = "Allow Multi POS", AutoSize = true };
        chkBatchesAdditional = new CheckBox { Text = "Batches Additional Column", AutoSize = true };
        chkPanel.Controls.AddRange(new Control[] { chkPhar, chkERP_P, chkDispatch, chkCusCharStat, chkOrderVisibility, chkAllowMultiPos, chkBatchesAdditional });

        AddLabel(5, "Flags / Options:");
        table.Controls.Add(chkPanel, 1, 5);
        table.SetColumnSpan(chkPanel, 3);

        // Buttons
        var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(0), AutoSize = true };
        btnLoad = new Button { Text = "Load", AutoSize = true, Padding = new Padding(8, 6, 8, 6) };
        btnSave = new Button { Text = "Save", AutoSize = true, Padding = new Padding(8, 6, 8, 6) };
        btnResetDefaults = new Button { Text = "Reset to Defaults", AutoSize = true, Padding = new Padding(8, 6, 8, 6) };
        btnPanel.Controls.AddRange(new Control[] { btnLoad, btnSave, btnResetDefaults });

        AddLabel(7, "Actions:");
        table.Controls.Add(btnPanel, 1, 7);
        table.SetColumnSpan(btnPanel, 3);

        // Preview area
        previewPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12) };
        previewLabel = new Label { Text = "Preview: The quick brown fox jumps over the lazy dog.", AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
        previewPanel.Controls.Add(previewLabel);

        // Add table and preview to form
        var main = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 460 };
        main.Panel1.Controls.Add(table);
        main.Panel2.Controls.Add(previewPanel);

        Controls.Add(main);
    }

    private void WireEvents()
    {
        btnLoad.Click += (s, e) => LoadSettings();
        btnSave.Click += (s, e) => SaveSettings();
        btnResetDefaults.Click += (s, e) => { LoadDefaultSettings(); ApplyToControls(); };

        // Update preview when styles change
        EventHandler previewUpdate = (s, e) => UpdatePreview();
        nudContentFontSize.ValueChanged += previewUpdate;
        cbContentFontStyle.SelectedIndexChanged += previewUpdate;
        nudHeaderSize.ValueChanged += previewUpdate;
        cbHeaderStyle.SelectedIndexChanged += previewUpdate;
        nudSubheaderSize.ValueChanged += previewUpdate;
        cbSubheaderStyle.SelectedIndexChanged += previewUpdate;
        nudOrderContentSize.ValueChanged += previewUpdate;
        cbOrderContentStyle.SelectedIndexChanged += previewUpdate;
    }

    #region Helpers to build UI rows
    private void AddLabel(int row, string text, int col = 0)
    {
        var lbl = new Label { Text = text, Anchor = AnchorStyles.Left | AnchorStyles.Right, AutoSize = false, Height = 28 };
        table.Controls.Add(lbl, col, row);
    }

    private void AddRow(int row, string labelText, out NumericUpDown nud, int min, int max)
    {
        AddLabel(row, labelText);
        nud = new NumericUpDown { Minimum = min, Maximum = max, Dock = DockStyle.Fill };
        table.Controls.Add(nud, 1, row);
    }

    private void AddRowStyleCombo(int row, int col, ref ComboBox combo)
    {
        combo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        combo.Items.AddRange(new object[] { "Regular", "Bold", "Italic", "Bold Italic" });
        table.Controls.Add(combo, 2, row);
    }
    #endregion
    private void LoadSettings()
    {
        try
        {
            settings = AdvanceDataManager.GetAdvanceData();
            IfNullThenDefault();
            ApplyToControls();
            UpdatePreview();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to load settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LoadDefaultSettings();
            ApplyToControls();
        }
    }

    private Advance_settings_data TryLoadFromLibrary()
    {
        Advance_settings_data s = null;

        // Try common static wrapper names - adjust to your actual API
        try
        {
            // Example: AdvanceData.Manager.GetAdvanceData()
            var type = Type.GetType("AdvanceData.AdvanceDataManager") ?? Type.GetType("AdvanceData.AdvanceManager");
            if (type != null)
            {
                var mi = type.GetMethod("GetAdvanceData") ?? type.GetMethod("Load") ?? type.GetMethod("getadvance_data");
                if (mi != null)
                {
                    var obj = mi.IsStatic ? mi.Invoke(null, null) : null;
                    s = obj as Advance_settings_data;
                }
            }
        }
        catch
        {
            // ignore, fallback to other attempts
        }

        // If still null, try to call a VB-style exported function that expects a connection string.
        if (s == null)
        {
            try
            {
                var vbType = Type.GetType("AdvanceData.AdvanceFunctions") ?? Type.GetType("AdvanceData.Module1");
                if (vbType != null)
                {
                    var mi2 = vbType.GetMethod("getadvance_data");
                    if (mi2 != null)
                    {
                        // Try call with null or empty string
                        var ret = mi2.Invoke(null, new object[] { String.Empty });
                        s = ret as Advance_settings_data;
                    }
                }
            }
            catch
            {
                // ignore
            }
        }

        return s;
    }

    private void IfNullThenDefault()
    {
        if (settings == null) LoadDefaultSettings();
    }

    private void LoadDefaultSettings()
    {
        settings = new Advance_settings_data
        {
            ContentFontSize = 11,
            ContentFontStyle = "Regular",
            ContentHeaderSize = 12,
            ContentHeaderStyle = "Bold",
            SubheaderSize = 10,
            SubheaderStyle = "Bold",
            orderContentFontSize = 20,
            orderContentFontStyle = "Bold",
            DMarkup = 0M,
            loyalper = 0M,
            Phar = false,
            ERP_P = false,
            Dispatch = false,
            CusCharStat = false,
            Ordervisibilty = false,
            allowmultipos = false,
            batches_additional_column = false
        };
    }

    private void ApplyToControls()
    {
        nudContentFontSize.Value = Clamp(settings.ContentFontSize, (int)nudContentFontSize.Minimum, (int)nudContentFontSize.Maximum);
        cbContentFontStyle.SelectedItem = settings.ContentFontStyle ?? "Regular";

        nudHeaderSize.Value = Clamp(settings.ContentHeaderSize, (int)nudHeaderSize.Minimum, (int)nudHeaderSize.Maximum);
        cbHeaderStyle.SelectedItem = settings.ContentHeaderStyle ?? "Bold";

        nudSubheaderSize.Value = Clamp(settings.SubheaderSize, (int)nudSubheaderSize.Minimum, (int)nudSubheaderSize.Maximum);
        cbSubheaderStyle.SelectedItem = settings.SubheaderStyle ?? "Regular";

        nudOrderContentSize.Value = Clamp(settings.orderContentFontSize, (int)nudOrderContentSize.Minimum, (int)nudOrderContentSize.Maximum);
        cbOrderContentStyle.SelectedItem = settings.orderContentFontStyle ?? "Bold";

        txtDMarkup.Text = settings.DMarkup.ToString();
        txtLoyalPer.Text = settings.loyalper.ToString();

        chkPhar.Checked = settings.Phar;
        chkERP_P.Checked = settings.ERP_P;
        chkDispatch.Checked = settings.Dispatch;
        chkCusCharStat.Checked = settings.CusCharStat;
        chkOrderVisibility.Checked = settings.Ordervisibilty;
        chkAllowMultiPos.Checked = settings.allowmultipos;
        chkBatchesAdditional.Checked = settings.batches_additional_column;
    }

    private void SaveSettings()
    {
        try
        {
            settings.ContentFontSize = (int)nudContentFontSize.Value;
            settings.ContentFontStyle = cbContentFontStyle.SelectedItem?.ToString() ?? "Regular";
            settings.ContentHeaderSize = (int)nudHeaderSize.Value;
            settings.ContentHeaderStyle = cbHeaderStyle.SelectedItem?.ToString() ?? "Bold";
            settings.SubheaderSize = (int)nudSubheaderSize.Value;
            settings.SubheaderStyle = cbSubheaderStyle.SelectedItem?.ToString() ?? "Regular";
            settings.orderContentFontSize = (int)nudOrderContentSize.Value;
            settings.orderContentFontStyle = cbOrderContentStyle.SelectedItem?.ToString() ?? "Bold";

            if (decimal.TryParse(txtDMarkup.Text, out decimal dm)) settings.DMarkup = dm;
            if (decimal.TryParse(txtLoyalPer.Text, out decimal lp)) settings.loyalper = lp;

            settings.Phar = chkPhar.Checked;
            settings.ERP_P = chkERP_P.Checked;
            settings.Dispatch = chkDispatch.Checked;
            settings.CusCharStat = chkCusCharStat.Checked;
            settings.Ordervisibilty = chkOrderVisibility.Checked;
            settings.allowmultipos = chkAllowMultiPos.Checked;
            settings.batches_additional_column = chkBatchesAdditional.Checked;

            AdvanceDataManager.SaveAdvanceData(settings);

            MessageBox.Show("Settings saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to save settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdatePreview()
    {
        // Build a combined preview font from selected content values
        var style = FontStyle.Regular;
        var styleStr = cbContentFontStyle.SelectedItem?.ToString() ?? "Regular";
        if (styleStr.IndexOf("Bold", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Bold;
        if (styleStr.IndexOf("Italic", StringComparison.OrdinalIgnoreCase) >= 0) style |= FontStyle.Italic;

        var font = new Font("Segoe UI", (float)nudContentFontSize.Value, style);
        previewLabel.Font = font;
        previewLabel.Text = "Preview: Header size " + nudHeaderSize.Value + ", Subheader " + nudSubheaderSize.Value + " — The quick brown fox jumps over the lazy dog.";
    }

    private int Clamp(int v, int min, int max) => Math.Max(min, Math.Min(max, v));

    //    [STAThread]
    //    public static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new AdvanceSettingsEditorForm());
    //    }
    //
}