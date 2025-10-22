using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPPrintManager
{
    internal static class Program
    {
        private static readonly string appGuid = "c0b85b5a-32ab-45c5-b9d9-d693faa6e7b9";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show(
                        "ERPPrint Manager instance already running",
                        "ERPPrint Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // ✅ Start background printing safely
                Thread printThread = new Thread(async () =>
{
    try
    {
        var labelPrinter = new LabelPrintingClass();
        await labelPrinter.Printout();
    }
    catch (Exception ex)
    {
        string logPath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "LabelPrinting_ErrorLog.txt"
        );
        System.IO.File.AppendAllText(logPath, $"{DateTime.Now}: {ex}\n");
    }
});

// ✅ Mark this thread as STA for OLE/COM operations
printThread.SetApartmentState(ApartmentState.STA);
printThread.IsBackground = true;
printThread.Start();


                          Application.Run(new frmManager());
            }
        }
    }
}
