using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{
    public static class Printing80mm
    {
        private static PrintDocument pd = new PrintDocument();
        private static PrintDocument pd_waiters_tables = new PrintDocument();
        private static ReceiptData receiptData;
        public static string printing_title = "ORDER";
        public static string titlecontent = "";
        private static Font largerBoldFont = new Font("Arial", 12, FontStyle.Bold);

        public static FontStyle GetFontStyle(string fontStyleString)
        {
            FontStyle style = FontStyle.Regular; // Default
            if (!string.IsNullOrEmpty(fontStyleString))
            {
                string[] styles = fontStyleString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in styles)
                {
                    switch (s.Trim().ToLower())
                    {
                        case "bold":
                            style |= FontStyle.Bold;
                            break;
                        case "italic":
                            style |= FontStyle.Italic;
                            break;
                        case "underline":
                            style |= FontStyle.Underline;
                            break;
                        case "strikeout":
                            style |= FontStyle.Strikeout;
                            break;
                    }
                }
            }
            return style;
        }

        public static void SetReceiptData(ReceiptData data)
        {
            receiptData = data;
        }

        public static string ToTitleCase(string input)
        {
            string[] excludedWords = { "to", "of", "in", "and", "the", "for", "a", "an", "on" };
            string[] words = input.ToLower().Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    if (i == 0 || Array.IndexOf(excludedWords, words[i]) == -1)
                        result.Add(char.ToUpper(words[i][0]) + words[i].Substring(1));
                    else
                        result.Add(words[i]);
                }
            }
            return string.Join(" ", result);
        }

        public static void PrintReceipt(string TillID)
        {
            pd.PrinterSettings.PrinterName = Properties.Settings.Default.DefaultPrinter;
            pd.Print();
        }

        public static string SaveImageFromBytes(byte[] imageBytes, string filePath)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                image.Save(filePath);
            }
            return filePath;
        }

        public static string SaveLogoImage(byte[] logoBytes, string filePath)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(logoBytes))
                {
                    Image image = Image.FromStream(ms);
                    image.Save(filePath);
                }
                return filePath;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
