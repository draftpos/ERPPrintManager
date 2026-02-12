using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPPrintManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static string appGuid = "c0b85b5a-32ab-45c5-b9d9-d693faa6e7b9";
        public static string SettingsFilePath =
           Path.Combine(Application.StartupPath, "font_settings.json");
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmManager());

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("ERPPrint Manager Instance already running","ERPPrint Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Application.Run(new frmManager());
            }
        }
    }
}
