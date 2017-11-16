namespace Automation.DatabaseCore.Model
{
    public class Setting : TestSettingsContext
    {
        public int Id { get; set; }
        public string TargetBrowser { get; set; }
        public string OperatingSystem { get; set; }
        public string SeleniumHubUri { get; set; }
        public string ScreenshotFolder { get; set; }
        public sbyte IsActive { get; set; }

        public Setting(string connectionString) : base(connectionString)
        {
        }
    }
}
