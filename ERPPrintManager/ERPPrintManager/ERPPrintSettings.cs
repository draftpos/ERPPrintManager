using System;
using System.Collections.Generic;
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
        public int ContentFontSize { get; set; }
        public string ContentFontStyle { get; set; }
        public int ContentHeaderSize { get; set; }
        public string ContentHeaderStyle { get; set; }
        public int SubheaderSize { get; set; }
        public string SubheaderStyle { get; set; }
        public int orderContentFontSize { get; set; }
        public string orderContentFontStyle { get; set; }
        public Advance_settings GetAdvanceData()
        {
            Advance_settings settings = new Advance_settings();

            // Default values
            int defaultHeaderSize = 11;
            string defaultHeaderStyle = "Bold";
            int defaultContentSize = 10;
            int defaultSubheaderSize = 10;
            int orderDefaultContentSize = 10;
            string orderDefaultContentStyle = "Bold";

            // Initialize settings with default values
            settings.ContentFontSize = defaultContentSize;
            settings.ContentFontStyle = "Regular";
            settings.ContentHeaderSize = defaultHeaderSize;
            settings.ContentHeaderStyle = defaultHeaderStyle;
            settings.SubheaderSize = defaultSubheaderSize;
            settings.SubheaderStyle = "Bold";
            settings.orderContentFontSize = orderDefaultContentSize;
            settings.orderContentFontStyle = orderDefaultContentStyle;
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
