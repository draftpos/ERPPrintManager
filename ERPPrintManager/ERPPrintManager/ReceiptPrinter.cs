using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{
    public class ReceiptPrinter
    {
        private ReceiptData receiptData;
        private int currentPage = 1; // Track the current page
         Advance_settings advancedata = new Advance_settings();
        
        public ReceiptPrinter(ReceiptData data)
        {
            receiptData = data;
        }

        public void PrintReceipt1(string TillID)
        {
            PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
                printDoc.PrinterSettings.PrinterName = Properties.Settings.Default.DefaultPrinter;
                printDoc.Print();
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            advancedata =  advancedata.GetAdvanceData();
            Font fontRegular = new Font("Arial", advancedata.ContentFontSize, GetFontStyle(advancedata.ContentFontStyle));
            Font fontBold = new Font("Arial", advancedata.SubheaderSize, GetFontStyle(advancedata.SubheaderStyle));
            Font contentFont = new Font("Arial", advancedata.ContentFontSize, GetFontStyle(advancedata.ContentFontStyle));
            Font ordercontentFont = new Font("Arial", advancedata.orderContentFontSize, GetFontStyle(advancedata.orderContentFontStyle));
            Font contentsubHeaderFont = new Font("Arial", advancedata.SubheaderSize, GetFontStyle(advancedata.SubheaderStyle));
            Font contentHeaderFont = new Font("Arial", advancedata.ContentHeaderSize, GetFontStyle(advancedata.ContentHeaderStyle));

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen grayPen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen blueBrush2 = new Pen(Color.Blue, 1);

            int paperWidth = 215; // 80mm paper width in pixels
            int startX = 10;
            int startY = 10;
            int offset = 20;
            int pageHeight = e.PageBounds.Height;
            int maxOffset = pageHeight - 50;
            int itemsPrinted = 0;
            bool headerPrinted = false;

            Company companyinfo = new Company();
            companyinfo.InvoiceHeader = "TAX INVOICE";
            if (!headerPrinted)
            {
                // === LOGO ===
                string logo_path  = @"C:\InvoiceFolder\logo.png";
                if (File.Exists(logo_path))
                {
                    Image logo = Image.FromFile(logo_path);
                    int logoWidth = 140;
                    int logoHeight = 100;
                    int logoX = (paperWidth - logoWidth) / 2;
                    graphics.DrawImage(logo, logoX, startY, logoWidth, logoHeight);
                    offset += 80;
                }

                SizeF textsize;

                // === INVOICE HEADER ===
                if (!string.IsNullOrEmpty(companyinfo.InvoiceHeader))
                {
                    textsize = graphics.MeasureString(companyinfo.InvoiceHeader, contentHeaderFont, paperWidth);
                    int textX = (int)((paperWidth - textsize.Width) / 2);
                    RectangleF layoutRectangle = new RectangleF(textX, startY + offset, paperWidth, textsize.Height);
                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        FormatFlags = StringFormatFlags.LineLimit
                    };
                    graphics.DrawString(companyinfo.InvoiceHeader, contentHeaderFont, blackBrush, layoutRectangle, stringFormat);
                    offset += (int)textsize.Height + 5;
                }

                // === COMPANY NAME ===
                if (!string.IsNullOrEmpty(receiptData.CompanyName))
                {
                    textsize = graphics.MeasureString(receiptData.CompanyName, contentHeaderFont, paperWidth);
                    RectangleF layoutRectangle1 = new RectangleF(0, startY + offset, paperWidth, textsize.Height);
                    StringFormat stringFormat1 = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.LineLimit
                    };
                    graphics.DrawString(receiptData.CompanyName, contentHeaderFont, blackBrush, layoutRectangle1, stringFormat1);
                    offset += (int)textsize.Height + 5;
                }

                // === COMPANY HEADER INFO ===
                StringBuilder header = new StringBuilder();
                if (!string.IsNullOrEmpty(receiptData.CompanyAddress)) header.AppendLine(receiptData.CompanyAddress);
                if (!string.IsNullOrEmpty(receiptData.City)) header.AppendLine(receiptData.City);
                if (!string.IsNullOrEmpty(receiptData.postcode)) header.AppendLine(receiptData.postcode);
                if (!string.IsNullOrEmpty(receiptData.contact)) header.AppendLine(receiptData.contact);
                if (!string.IsNullOrEmpty(receiptData.CompanyEmail)) header.AppendLine(receiptData.CompanyEmail);
                if (!string.IsNullOrEmpty(receiptData.VATNo)) header.AppendLine("VAT: " + receiptData.VATNo);
                if (!string.IsNullOrEmpty(receiptData.TIN)) header.AppendLine("TIN: " + receiptData.TIN);

                string headerString = header.ToString();
                RectangleF layoutRectangle2 = new RectangleF(
                    0, startY + offset, paperWidth,
                    graphics.MeasureString(headerString, contentsubHeaderFont, paperWidth).Height);

                StringFormat stringFormat2 = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.LineLimit
                };

                graphics.DrawString(headerString, contentsubHeaderFont, blackBrush, layoutRectangle2, stringFormat2);
                offset += (int)layoutRectangle2.Height + 5;
                graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                offset += 10;

                // === SUBHEADER INFO ===
                StringBuilder subHeader = new StringBuilder();
                subHeader.AppendLine("Invoice No: " + receiptData.InvoiceNo);
                subHeader.AppendLine("Date: " + receiptData.InvoiceDate.ToString("dd/MM/yyyy HH:mm:ss"));
                subHeader.AppendLine("Cashier: " + receiptData.CashierName);
                subHeader.AppendLine("Customer: " + receiptData.CustomerName);

                RectangleF layoutRectangle3 = new RectangleF(5, startY + offset, paperWidth, graphics.MeasureString(subHeader.ToString(), contentsubHeaderFont, paperWidth).Height);
                StringFormat stringFormat3 = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    FormatFlags = StringFormatFlags.LineLimit
                };

                graphics.DrawString(subHeader.ToString(), contentsubHeaderFont, blackBrush, layoutRectangle3, stringFormat3);
                offset += (int)layoutRectangle3.Height + 10;

                graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                offset += 10;

                headerPrinted = true;
            }

            // === ITEMS LOOP ===
            while (itemsPrinted < receiptData.itemlist.Count)
            {
                var item = receiptData.itemlist[itemsPrinted];
                if (!string.IsNullOrEmpty(item.ProductName))
                    { 
                    string line = $"{item.ProductName}  {item.Qty} x {item.Price:C} = {item.Amount:C}";
                    SizeF textsize = graphics.MeasureString(line, ordercontentFont);
                    if (offset + textsize.Height > maxOffset)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                
                    graphics.DrawString(line, ordercontentFont, blackBrush, startX-5, (startY + offset));
                    offset += (int)textsize.Height + 5;
                    itemsPrinted++;
                }
            }

            // === TOTALS ===
            graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
            offset += 10;
            graphics.DrawString("Subtotal: " + receiptData.Subtotal.ToString("C"), contentFont, blackBrush, startX-5, startY + offset);
            offset += 20;
            graphics.DrawString("VAT: " + receiptData.TotalVat.ToString("C"), contentFont, blackBrush, startX - 5, startY + offset);
            offset += 20;
            graphics.DrawString("Total: " + receiptData.GrandTotal.ToString("C"), contentHeaderFont, blackBrush, startX - 5, startY + offset);
            offset += 30;

            // === QR CODE ===
            string qr_path = Path.Combine(@"C:\InvoiceFolder\QRCode", receiptData.InvoiceNo + "_qrccode.png");
            if (!string.IsNullOrEmpty(receiptData.QRCode) && File.Exists(qr_path))
            {
                Image qr = Image.FromFile(qr_path);
                int qrX = (paperWidth - 100) / 2;
                graphics.DrawImage(qr, qrX, startY + offset, 100, 100);
                offset += 110;
            }

            // === VERIFICATION CODE ===
            if (!string.IsNullOrEmpty(receiptData.VCode))
            {
                graphics.DrawString("Verification Code: " , contentsubHeaderFont, blackBrush, startX + 40, startY + offset);
                offset += 20;
                graphics.DrawString( receiptData.VCode, contentsubHeaderFont, blackBrush, startX + 30, startY + offset);
                offset += 20;
            }

            // === FOOTER ===
            if (!string.IsNullOrEmpty(receiptData.Footer))
            {
                SizeF textsize = graphics.MeasureString(receiptData.Footer, contentsubHeaderFont, paperWidth);
                RectangleF layoutRectangle4 = new RectangleF(0, startY + offset, paperWidth, textsize.Height);
                StringFormat stringFormat4 = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.LineLimit
                };
                graphics.DrawString(receiptData.Footer, contentsubHeaderFont, blackBrush, layoutRectangle4, stringFormat4);
                offset += (int)textsize.Height + 5;
            }

            // === RESET ===
            itemsPrinted = 0;
            headerPrinted = false;
            e.HasMorePages = false;
        }


        private int AdjustSpacing(string text)
        {
            int maxLength = 6;
            if (text.Length > maxLength)
                return -5 * (text.Length - maxLength);
            return 0;
        }

        // Stub: Replace with your font style converter
        private FontStyle GetFontStyle(string style)
        {
            return style.ToLower() switch
            {
                "bold" => FontStyle.Bold,
                "italic" => FontStyle.Italic,
                _ => FontStyle.Regular,
            };
        }
    }

}
