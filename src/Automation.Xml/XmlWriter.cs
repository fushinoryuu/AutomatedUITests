using System.IO;

namespace Automation.Xml
{
    public class XmlWriter
    {
        public void OutputXml()
        {
            var config = new Configuration();
            const string srcPath = @"C:\AutomatedUiTests\src\Automation.Tests\App.config";
            const string binPath = @"C:\AutomatedUiTests\src\Automation.Tests\bin\Debug\App.config";
            var text = FileText(config);

            File.WriteAllText(srcPath, text);
            File.WriteAllText(binPath, text);
        }

        private static string FileText(Configuration config)
        {
            var text = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                "\n<configuration>" +
                "\n\t<appSettings >" +
                $"\n\t\t<add key=\"targetBrowser\" value=\"{config.Browser}\"/>" +
                $"\n\t\t<add key=\"operatingSystem\" value=\"{config.Os}\"/>" +
                $"\n\t\t<add key=\"seleniumHubUri\" value=\"{config.Hub}\"/>" +
                $"\n\t\t<add key=\"screenshotFolder\" value=\"{config.Screenshots}\"/>" +
                "\n\t</appSettings>" +
                "\n</configuration>";

            return text;
        }
    }
}