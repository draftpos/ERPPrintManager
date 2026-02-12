using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{
    public class PrintManagerAdvanceSettings
    {

    }




    public class Advance_settings
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
        public string OrderContentStyle { get; set; }


        public Advance_settings GetAdvanceData(string filePath)
        {
            Advance_settings settings = new Advance_settings();

            // ===== DEFAULT VALUES =====
            settings.ContentFontName = "Arial";
            settings.ContentFontSize = 10;
            settings.ContentFontStyle = "Regular";

            settings.ContentHeaderFontName = "Arial";
            settings.ContentHeaderSize = 11;
            settings.ContentHeaderStyle = "Bold";

            settings.SubheaderFontName = "Times New Roman";
            settings.SubheaderSize = 10;
            settings.SubheaderStyle = "Bold";

            settings.OrderContentFontName = "Arial";
            settings.OrderContentFontSize = 10;
            settings.OrderContentStyle = "Bold";
         

            if (!File.Exists(filePath))
                return settings;

            try
            {
                string json = File.ReadAllText(filePath);

                var fileSettings = JsonConvert.DeserializeObject<Advance_settings>(json);

                if (fileSettings != null)
                {
                    // Only overwrite if values exist
                    settings.ContentFontName = fileSettings.ContentFontName ?? settings.ContentFontName;
                    settings.ContentFontStyle = fileSettings.ContentFontStyle ?? settings.ContentFontStyle;
                    settings.ContentHeaderFontName = fileSettings.ContentHeaderFontName ?? settings.ContentHeaderFontName;
                    settings.ContentHeaderStyle = fileSettings.ContentHeaderStyle ?? settings.ContentHeaderStyle;
                    settings.SubheaderFontName = fileSettings.SubheaderFontName ?? settings.SubheaderFontName;
                    settings.SubheaderStyle = fileSettings.SubheaderStyle ?? settings.SubheaderStyle;
                    settings.OrderContentFontName = fileSettings.OrderContentFontName ?? settings.OrderContentFontName;
                    settings.OrderContentStyle = fileSettings.OrderContentStyle ?? settings.OrderContentStyle;

                    if (fileSettings.ContentFontSize > 0)
                        settings.ContentFontSize = fileSettings.ContentFontSize;

                    if (fileSettings.ContentHeaderSize > 0)
                        settings.ContentHeaderSize = fileSettings.ContentHeaderSize;

                    if (fileSettings.SubheaderSize > 0)
                        settings.SubheaderSize = fileSettings.SubheaderSize;

                    if (fileSettings.OrderContentFontSize > 0)
                        settings.OrderContentFontSize = fileSettings.OrderContentFontSize;
                }
            }
            catch
            {
                // If JSON is corrupt → return defaults silently
            }

            return settings;
        }
    }


    public class Company
    {
        public string CompanyName { get; set; }
        public string MailingName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string TIN { get; set; }
        public string InvoiceHeader { get; set; }

    }

    public class Item
    {
        public string ProductName { get; set; }
        public string productid { get; set; }
        public double Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal tax_amount { get; set; }
    }

    public class MultiCurrencyDetail
    {
        public string Key { get; set; }
        public double Value { get; set; }
    }

    public class ReceiptData
    {
        public string doc_type { get; set; } = null;//
        public string ReceiptType { get; set; } = null;
        public string CompanyLogoPath { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyAddressLine1 { get; set; }
        public string CompanyAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string postcode { get; set; }
        public string Cashier { get; set; }
        public string contact { get; set; }
        public string CompanyEmail { get; set; }
        public string TIN { get; set; }
        public string VATNo { get; set; }
        public string Tel { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string CashierName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerTradeName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTIN { get; set; }
        public string CustomerVAT { get; set; }
        public string Customeraddress { get; set; }
        public List<Item> itemlist { get; set; }
        public string AmountTendered { get; set; }
        public string Change { get; set; }
        public string QRCodePath { get; set; }
        public string QRCodePath2 { get; set; }
        public string Currency { get; set; }
        public string Footer { get; set; }
        public List<MultiCurrencyDetail> MultiCurrencyDetails { get; set; }
        public string DeviceID { get; set; }
        public string FiscalDay { get; set; }
        public string DeviceSerial { get; set; }
        public string ReceiptNo { get; set; }
        public string CustomerRef { get; set; }
        public string VCode { get; set; }
        public string QRCode { get; set; }
        public double DiscAmt { get; set; }
        public double GrandTotal { get; set; }
        public double Subtotal { get; set; }
        public double TotalVat { get; set; }
        public string TaxType { get; set; }
        public string PaymentMode { get; set; }
    }
}
