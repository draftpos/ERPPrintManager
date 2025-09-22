using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
        private bool headerPrinted = false;
        private int itemsPrinted = -1;
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
            advancedata = advancedata.GetAdvanceData();
            Graphics graphics = e.Graphics;
            Font fontRegular = new Font("Arial", advancedata.ContentFontSize, GetFontStyle(advancedata.ContentFontStyle));
            Font fontBold = new Font("Arial", advancedata.SubheaderSize, GetFontStyle(advancedata.SubheaderStyle));
            Font contentFont = new Font("Arial", advancedata.ContentFontSize, GetFontStyle(advancedata.ContentFontStyle));
            Font ordercontentFont = new Font("Arial", advancedata.orderContentFontSize, GetFontStyle(advancedata.orderContentFontStyle));
            Font contentsubHeaderFont = new Font("Arial", advancedata.SubheaderSize, GetFontStyle(advancedata.SubheaderStyle));
            Font contentHeaderFont = new Font("Arial", advancedata.ContentHeaderSize, GetFontStyle(advancedata.ContentHeaderStyle));
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush brownBrush = new SolidBrush(Color.OrangeRed);
            Pen grayPen = new Pen(Color.Gray, 1);
            grayPen.DashStyle = DashStyle.Dot;
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen blueBrush2 = new Pen(Color.Blue, 1);
            int paperWidth = 215; // 80mm paper width in pixels
            int startX = 10;
            int startY = 10;
            int offset = 20;
            int pageHeight = e.PageBounds.Height; // Available height on the page
            int maxOffset = pageHeight - 5; // Adjust to leave space for margins
             int itemsPrinted = 0;
             bool headerPrinted = false;

            if (!headerPrinted)
            {
                SizeF textsize;
                int currentY = startY;

                // Draw "COPIED" first if receipt is printed
                //if (receiptData.isprinted)
                //{
                //    textsize = graphics.MeasureString("COPY", contentHeaderFont, paperWidth);
                //    int textX = (int)((paperWidth - textsize.Width) / 2);
                //    RectangleF layoutRectangle = new RectangleF(textX, currentY, paperWidth, textsize.Height);
                //    StringFormat stringFormat = new StringFormat();
                //    stringFormat.Alignment = StringAlignment.Center;
                //    stringFormat.FormatFlags = StringFormatFlags.LineLimit;
                //    graphics.DrawString("COPY", contentHeaderFont, blackBrush, layoutRectangle, stringFormat);
                //    currentY += (int)textsize.Height - 5;
                //}

                // Draw logo below "COPIED"
                string logo_path = @"C:\InvoiceFolder\logo.png";
                if ( File.Exists(logo_path))
                {
                    Image logo = Image.FromFile(logo_path);
                    int logoWidth = 140;
                    int logoHeight = 100;
                    int logoX = (paperWidth - logoWidth) / 2;
                    graphics.DrawImage(logo, logoX, currentY, logoWidth, logoHeight);
                    currentY += logoHeight;
                }

                offset = currentY;
                // Invoice Header
                Company companyinfo = new Company();
                companyinfo.InvoiceHeader = "TAX INVOICE";
                if (!string.IsNullOrEmpty(companyinfo.InvoiceHeader))
                {
                    textsize = graphics.MeasureString(companyinfo.InvoiceHeader, contentHeaderFont, paperWidth);
                    int textX = (int)((paperWidth - textsize.Width) / 2);
                    RectangleF layoutRectangle = new RectangleF(textX, startY + offset, paperWidth, textsize.Height);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.FormatFlags = StringFormatFlags.LineLimit;
                    graphics.DrawString(companyinfo.InvoiceHeader, contentHeaderFont, blackBrush, layoutRectangle, stringFormat);
                    offset += (int)textsize.Height + 5;
                }

                StringBuilder header = new StringBuilder();
                if (!string.IsNullOrEmpty(receiptData.CompanyName))
                {
                    textsize = graphics.MeasureString(receiptData.CompanyName, contentHeaderFont, paperWidth);
                    RectangleF layoutRectangle1 = new RectangleF(0, startY + offset, paperWidth, textsize.Height);
                    StringFormat stringFormat1 = new StringFormat();
                    stringFormat1.Alignment = StringAlignment.Center;
                    stringFormat1.FormatFlags = StringFormatFlags.LineLimit;
                    graphics.DrawString(receiptData.CompanyName, contentHeaderFont, blackBrush, layoutRectangle1, stringFormat1);
                    offset += (int)textsize.Height + 5;
                }

                // Build the header string
                if (!string.IsNullOrEmpty(receiptData.CompanyAddress))
                    header.AppendLine(receiptData.CompanyAddress);
                if (!string.IsNullOrEmpty(receiptData.City))
                    header.AppendLine(receiptData.City);
                if (!string.IsNullOrEmpty(receiptData.State))
                    header.AppendLine(receiptData.State);
                if (!string.IsNullOrEmpty(receiptData.postcode))
                    header.AppendLine(receiptData.postcode);
                if (!string.IsNullOrEmpty(receiptData.contact))
                    header.AppendLine(receiptData.contact);
                if (!string.IsNullOrEmpty(receiptData.CompanyEmail))
                    header.AppendLine(receiptData.CompanyEmail);
                if (!string.IsNullOrEmpty(receiptData.VATNo))
                    header.AppendLine($"VAT: {receiptData.VATNo}");
                if (!string.IsNullOrEmpty(receiptData.TIN))
                    header.AppendLine($"TIN: {receiptData.TIN}");

                string headerString = header.ToString();
                RectangleF layoutRectangle2 = new RectangleF(0, startY + offset, paperWidth, graphics.MeasureString(headerString, contentsubHeaderFont, paperWidth).Height);
                StringFormat stringFormat2 = new StringFormat();
                stringFormat2.Alignment = StringAlignment.Center;
                stringFormat2.FormatFlags = StringFormatFlags.LineLimit;
                graphics.DrawString(headerString, contentsubHeaderFont, blackBrush, layoutRectangle2, stringFormat2);
                offset += (int)layoutRectangle2.Height + 5;
                graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                offset += 10;

                StringBuilder subHeader = new StringBuilder();
                int irow = 1;
                if (receiptData != null)
                {
                    if (!string.IsNullOrEmpty(receiptData.InvoiceNo))
                    {
                        subHeader.AppendLine($"Invoice No.: \t{receiptData.InvoiceNo}");
                        irow += 1;
                    }

                    //// ORDER NO
                    //if (!string.IsNullOrEmpty(receiptData.SalesOpenNo) && !advancedata.Ordervisibilty)
                    //{
                    //    graphics.DrawString($"Order No. {receiptData.SalesOpenNo}", ordercontentFont, blackBrush, startX, startY + offset);
                    //    offset += (int)ordercontentFont.GetHeight(graphics) + 5;
                    //}

                    if (!string.IsNullOrEmpty(receiptData.InvoiceDate))
                    {
                        subHeader.AppendLine($"DateTime:\t{receiptData.InvoiceDate}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerRef))
                    {
                        subHeader.AppendLine($"Customer Ref:\t{receiptData.CustomerRef}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CashierName))
                    {
                        subHeader.AppendLine($"Cashier:\t\t{receiptData.CashierName}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.Currency))
                    {
                        subHeader.AppendLine($"Currency Code:\t{receiptData.Currency}");
                        irow += 1;
                    }

                }

                if (receiptData.DeviceID != null)
                {
                    if (!string.IsNullOrEmpty(receiptData.DeviceID))
                    {
                        subHeader.AppendLine($"Device ID:\t{receiptData.DeviceID}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.DeviceSerial))
                    {
                        subHeader.AppendLine($"Device Serial No: {receiptData.DeviceSerial} ");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.FiscalDay))
                    {
                        subHeader.AppendLine($"Fiscal Day:\t{receiptData.FiscalDay}");
                        irow += 1;
                    }
                
                    string subHeaderString1 = subHeader.ToString();
                    graphics.DrawString(subHeaderString1, fontRegular, blackBrush, startX, startY + offset);
                    offset += (int)(fontRegular.GetHeight(graphics) * (irow - 1));
                    irow = 1;
                    graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                    offset += 3;
                }
                subHeader = new StringBuilder();
                if (receiptData.CustomerTradeName != null)
                {
                    if (!string.IsNullOrEmpty(receiptData.CustomerName))
                    {
                        subHeader.AppendLine($"Customer Name: {receiptData.CustomerName}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerTradeName))
                    {
                        subHeader.AppendLine($"TradeName: {receiptData.CustomerTradeName}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.Customeraddress))
                    {
                        subHeader.AppendLine($"Address: {receiptData.Customeraddress}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerContact))
                    {
                        subHeader.AppendLine($"Customer Contact: {receiptData.CustomerContact}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerEmail))
                    {
                        subHeader.AppendLine($"Customer Mail: {receiptData.CustomerEmail}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerVAT))
                    {
                        subHeader.AppendLine($"Customer Vat: {receiptData.CustomerVAT}");
                        irow += 1;
                    }

                    if (!string.IsNullOrEmpty(receiptData.CustomerTIN))
                    {
                        subHeader.AppendLine($"Customer TIN: {receiptData.CustomerTIN}");
                        irow += 1;
                    }

                    irow = irow - 2;
                

                    string subHeaderString = subHeader.ToString();
                    graphics.DrawString(subHeaderString, fontRegular, blackBrush, startX, startY + offset);
                    if (receiptData.CustomerTradeName != null)
                    {
                        offset += (int)(fontRegular.GetHeight(graphics) * (irow + 1));
                    }
                    graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                    offset += 10;
                }
                string itemHeader = "Item Description" + Environment.NewLine + "ProductName" + Environment.NewLine + "Qty" + "\t" + "Price(Inc)  " +  "VAT" + "\t"  + "  Total(Inc)";
                graphics.DrawString(itemHeader, fontBold, blueBrush, startX, startY + offset);
                offset += (int)(fontBold.GetHeight(graphics) * 3);
                headerPrinted = true;
            }

            // Print item description header
            if (itemsPrinted == 0)
            {
                graphics.DrawLine(Pens.Black, startX, startY + offset, startX + 250, startY + offset);
                offset += 7;
            }
            int box_from = offset;

            // Print details with pagination support
            for (int i = itemsPrinted; i < receiptData.itemlist.Count; i++)
            {
                Item detail = receiptData.itemlist[i];
                itemsPrinted = i + 1;

                if (offset >= maxOffset)
                {
                    e.HasMorePages = true;
                    return;
                }

                // Print product details
                graphics.DrawString(detail.ProductName, fontRegular, blackBrush, startX, startY + offset);
                offset += (int)fontRegular.GetHeight(graphics) + 2;
               
                int qtyWidth = 40;
                int priceWidth = 80;
                int vatWidth = 60;
                int totalWidth = 100;

                string qtyText = $"{detail.Qty}";
                string priceText = $"{detail.Price:F2}";
                string vatText = $"{detail.vat:F2}";
                //string vatText = companyInfo.vat_display ? $"{detail.vat:F2}" : "";
                string amountText = $"{detail.Amount:F2}";

                int priceXPosition = startX + qtyWidth + AdjustSpacing(qtyText);
                int vatXPosition = priceXPosition + priceWidth + AdjustSpacing(priceText);
                int totalXPosition = vatXPosition + vatWidth + AdjustSpacing(vatText);
                graphics.DrawString(qtyText, fontRegular, blackBrush, startX, startY + offset);
                graphics.DrawString(priceText, fontRegular, blackBrush, priceXPosition+20, startY + offset);

                graphics.DrawString(vatText, fontRegular, blackBrush, vatXPosition+15, startY + offset);
               
                graphics.DrawString(amountText, fontRegular, blackBrush, totalXPosition, startY + offset);
                offset += (int)fontRegular.GetHeight(graphics);

                //RectangleF layoutRectangle3 = new RectangleF(0, startY + offset, paperWidth, graphics.MeasureString(detail.RemarkText, contentsubHeaderFont, paperWidth).Height);
                StringFormat stringFormat3 = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.LineLimit
                };


                graphics.DrawLine(grayPen, startX, startY + offset, startX + 250, startY + offset);
                offset += 10;
            }
            int box_to = offset;
            // Boxed In Item
            graphics.DrawLine(grayPen, startX, box_from+3, startX, box_to);
            graphics.DrawLine(grayPen, startX+250, box_from+3, startX+250, box_to);
            //======END =====
            decimal sumvat = 0;
            sumvat = receiptData.itemlist.Sum(d => d.vat);
            
            int spaceNeededForTotals = (int)(fontRegular.GetHeight(graphics) * 6);
            if ((startY + offset + spaceNeededForTotals) > maxOffset)
            {
                e.HasMorePages = true;
                return;
            }

            bool totalsPrinted = false;
            if (!totalsPrinted)
            {
                //graphics.DrawLine(blueBrush2, startX, startY + offset, startX + 250, startY + offset);
                //offset += 5;
                graphics.DrawLine(blueBrush2, startX, startY + offset, startX + 250, startY + offset);
                offset += 10;

                decimal totalamt_exclusive = (Convert.ToDecimal(receiptData.Subtotal) );
                int labelWidth = 250;
                int valueXPosition = startX + labelWidth;

                // Sub Total Exc.
                graphics.DrawString("Sub Total Exc.", fontRegular, brownBrush, startX, startY + offset);
                graphics.DrawString(totalamt_exclusive.ToString("F2"), fontRegular, blackBrush, valueXPosition, startY + offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                offset += (int)fontRegular.GetHeight(graphics);

                // Total Tax
                graphics.DrawString("Total Tax:", fontRegular, brownBrush, startX, startY + offset);
                graphics.DrawString(sumvat.ToString("F2"), fontRegular, blackBrush, valueXPosition, startY + offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                offset += (int)fontRegular.GetHeight(graphics);

                // Invoice Amount Inc.
                graphics.DrawString("Invoice Amount Inc.:", fontRegular, brownBrush, startX, startY + offset);
                graphics.DrawString(Convert.ToDecimal(receiptData.GrandTotal).ToString("F2"), fontRegular, blackBrush, valueXPosition, startY + offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                offset += (int)fontRegular.GetHeight(graphics);

                // Amount Tendered
                graphics.DrawString("Amount Tendered:", fontRegular, brownBrush, startX, startY + offset);
                graphics.DrawString(Convert.ToDecimal(receiptData.AmountTendered).ToString("F2"), fontRegular, blackBrush, valueXPosition, startY + offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                offset += (int)fontRegular.GetHeight(graphics);

                // Change
                graphics.DrawString("Change:", fontRegular, brownBrush, startX, startY + offset);
                graphics.DrawString(Convert.ToDecimal(receiptData.Change).ToString("F2"), fontRegular, blackBrush, valueXPosition, startY + offset, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                offset += (int)fontRegular.GetHeight(graphics);

                totalsPrinted = true;
            }

            int spaceNeededForCurrency = (int)(fontRegular.GetHeight(graphics) * (receiptData.MultiCurrencyDetails.Count + 2));
            if ((startY + offset + spaceNeededForCurrency) > maxOffset)
            {
                e.HasMorePages = true;
                return;
            }

            bool curencyHeader = false;
            if (!curencyHeader)
            {
                if (!string.IsNullOrEmpty(receiptData.Currency))
                {
                    graphics.DrawString($"Currency: {receiptData.Currency}", fontRegular, blueBrush, startX, startY + offset+5);
                    offset += (int)fontRegular.GetHeight(graphics) * 2;
                }

                if (receiptData.MultiCurrencyDetails != null && receiptData.MultiCurrencyDetails.Count > 0)
                {
                    graphics.DrawString("Multi Currency Details", fontBold, blackBrush, startX, startY + offset);
                    offset += (int)fontBold.GetHeight(graphics);
                    graphics.DrawString("CURRENCY    AMOUNT", fontRegular, blackBrush, startX, startY + offset);
                    offset += (int)fontRegular.GetHeight(graphics);

                    foreach (var mc in receiptData.MultiCurrencyDetails)
                    {
                        if (mc.Value == 0) continue;
                        graphics.DrawString($"{mc.Key}       {mc.Value:F2}", fontRegular, blackBrush, startX, startY + offset);
                        offset += (int)fontRegular.GetHeight(graphics);
                    }
                    offset += (int)fontRegular.GetHeight(graphics);
                }
                curencyHeader = true;
            }

            int spaceNeededForQRCode = 100;
            if ((startY + offset + spaceNeededForQRCode) > maxOffset)
            {
                e.HasMorePages = true;
                return;
            }

            bool printedqrcode = false;
            if (!printedqrcode)
            {
                if (!string.IsNullOrEmpty(receiptData.QRCodePath) && File.Exists(receiptData.QRCodePath))
                {
                    Image qrCode = Image.FromFile(receiptData.QRCodePath);
                    int qrCodeWidth = 90;
                    int qrCodeHeight = 90;
                    int qrCodeX = (paperWidth - qrCodeWidth) / 2;
                    graphics.DrawImage(qrCode, qrCodeX, startY + offset, qrCodeWidth, qrCodeHeight);
                    offset += 90;
                }

                string qr_path = Path.Combine(@"C:\InvoiceFolder\QRCode", receiptData.InvoiceNo + "_qrccode.png");
                if (File.Exists(qr_path))
                {
                    Image qrCode2 = Image.FromFile(qr_path);
                    int qrCodeWidth2 = 80;
                    int qrCodeHeight2 = 80;
                    int qrCodeX2 = (paperWidth - qrCodeWidth2) / 2;
                    graphics.DrawImage(qrCode2, qrCodeX2+15, startY + offset, qrCodeWidth2, qrCodeHeight2);
                    offset += 80;
                }
                printedqrcode = true;
            }

            int spaceNeededForVerificationCode;
            if (!string.IsNullOrEmpty(receiptData.VCode))
            {
                spaceNeededForVerificationCode = (int)(fontRegular.GetHeight(graphics) * 3);
            }
            else
            {
                spaceNeededForVerificationCode = (int)(fontRegular.GetHeight(graphics) * 2);
            }

            if ((startY + offset + spaceNeededForVerificationCode) > maxOffset)
            {
                e.HasMorePages = true;
                return;
            }

             bool vcodeprinted = false;
            if (!vcodeprinted)
            {
                // === VERIFICATION CODE ===
                if (!string.IsNullOrEmpty(receiptData.VCode))
                {
                    graphics.DrawString("Verification Code: ", fontRegular, blackBrush, startX + 50, startY + offset);
                    offset += 20;
                    graphics.DrawString(receiptData.VCode, fontRegular, blackBrush, startX + 40, startY + offset);
                    offset += 20;
                    graphics.DrawString("You can verify this receipt manually at", fontRegular, blackBrush, startX, startY + offset);
                    offset += 20;
                    graphics.DrawString("https://fdms.zimra.co.zw", fontRegular, blackBrush, startX + 40, startY + offset);
                    offset += 20;

                }

                string footer = $"Havano Point of Sale v11{Environment.NewLine}   Thanks....Visit Again!";
                graphics.DrawString(footer, fontRegular, blackBrush, startX+40, startY + offset+5);
                vcodeprinted = true;
            }

            if (offset < maxOffset)
            {
                e.HasMorePages = false;
                currentPage = 1;
            }
            else
            {
                e.HasMorePages = true;
            }

            // After printing all details, reset the pagination
            itemsPrinted = 0;
            headerPrinted = false;
            e.HasMorePages = false;
        }

        private int AdjustSpacing(string text)
        {
            int maxLength = 6;
            Debug.WriteLine(text.Length);
            if (text.Length > maxLength)
            {
                Debug.WriteLine($" Space Returned for {text} :{-5 * (text.Length - maxLength)}");
                //return -5 * (text.Length - maxLength);
                return 0;
            }
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
