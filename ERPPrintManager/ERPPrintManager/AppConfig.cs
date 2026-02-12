using System.IO;
using System.Windows.Forms;

namespace ERPPrintManager
{
    public static class AppConfig
    {
        public static string SettingsFilePath =
            Path.Combine(Application.StartupPath, "font_settings.json");
        //Path.Combine(appDataFolder, "font_settings.json");
    }
}
