using System;
using System.IO;
using ERPPrintManager;
using Newtonsoft.Json;

public static class InvoiceCustomizationService
{
    private static readonly string FilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "invoice_customization.json");

    public static InvoiceCustomization GetCustomization()
    {
        var defaultData = new InvoiceCustomization
        {
            Type = "Tax invoice",
            Vat = true,
            Footer = string.Join(Environment.NewLine,
                "Havano Point of Sale v11",
                "Thank you for your patronage","Power by Havano"),
                        SubtotalExcl = true,
            Inclusive = true,

            // Defaults for receipt headers
            ShowDescriptionLabel = true,
            ShowProductNameLabel = true,
            ShowPaymentsLabel = true
        };

        // Create file if missing
        if (!File.Exists(FilePath))
        {
            Save(defaultData);
            return defaultData;
        }

        // Read existing file
        var json = File.ReadAllText(FilePath);
        var data = JsonConvert.DeserializeObject<InvoiceCustomization>(json);

        // 🔒 Auto-upgrade missing fields (important)
        bool updated = false;

        if (data.ShowDescriptionLabel == false && !json.Contains("ShowDescriptionLabel"))
        {
            data.ShowDescriptionLabel = true;
            updated = true;
        }

        if (data.ShowProductNameLabel == false && !json.Contains("ShowProductNameLabel"))
        {
            data.ShowProductNameLabel = true;
            updated = true;
        }

        if (data.ShowPaymentsLabel == false && !json.Contains("ShowPaymentsLabel"))
        {
            data.ShowPaymentsLabel = true;
            updated = true;
        }

        if (updated)
            Save(data);

        return data;
    }

    private static void Save(InvoiceCustomization data)
    {
        File.WriteAllText(
            FilePath,
            JsonConvert.SerializeObject(data, Formatting.Indented)
        );
    }
}
