using MySql.Data.MySqlClient;

namespace Automation.DatabaseCore.Model
{
    public class Setting
    {
        public int Id { get; set; }
        public string TargetBrowser { get; set; }
        public string OperatingSystem { get; set; }
        public string SeleniumHubUri { get; set; }
        public string ScreenshotFolder { get; set; }
        public sbyte IsActive { get; set; }

        public Setting()
        {
        }

        public Setting(MySqlDataReader reader)
        {
            Id = reader.GetInt32("id");
            TargetBrowser = reader.GetString("targetBrowser");
            OperatingSystem = reader.GetString("operatingSystem");
            SeleniumHubUri = reader.GetString("seleniumHubUri");
            ScreenshotFolder = reader.GetString("screenshotFolder");
            IsActive = reader.GetSByte("isActive");
        }
    }
}