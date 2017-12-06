using System.IO;
using System.Linq;
using Automation.Database.Model;

namespace Automation.Xml
{
    public class AppConfigWriter
    {
        private readonly string _browser;
        private readonly string _os;
        private readonly string _hub;
        private readonly string _screenshots;
        private readonly string _srcPath;
        private readonly string _binPath;

        public AppConfigWriter()
        {
            var settings = GetDataFromDb();

            if (settings == null)
                return;

            _browser = settings.targetBrowser;
            _os = settings.operatingSystem;
            _hub = settings.seleniumHubUri;
            _screenshots = settings.screenshotFolder;

            _srcPath = @"C:\AutomationToolboox\src\Automation.Tests\App.config";
            _binPath = @"C:\AutomationToolboox\src\Automation.Tests\bin\Debug\App.config";
        }

        private static setting GetDataFromDb()
        {
            var db = new testsettingsEntities();

            var config = (from item in db.settings
                          where item.isActive == 1
                          select item).ToList().FirstOrDefault();

            db.Dispose();

            return config;
        }

        public void OutputXml()
        {
            var text = FileText();

            File.WriteAllText(_srcPath, text);
            File.WriteAllText(_binPath, text);
        }

        private string FileText()
        {
            var text = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                       "\n<configuration>" +
                       "\n\t<configSections>" +
                       "\n\t\t<section name=\"entityFramework\" type=\"System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" requirePermission=\"false\" />" +
                       "\n\t</configSections>" +
                       "\n\t<entityFramework>" +
                       "\n\t\t<defaultConnectionFactory type=\"System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework\">" +
                       "\n\t\t\t<parameters>" +
                       "\n\t\t\t\t<parameter value=\"mssqllocaldb\" />" +
                       "\n\t\t\t</parameters>" +
                       "\n\t\t</defaultConnectionFactory>" +
                       "\n\t\t<providers>" +
                       "\n\t\t\t<provider invariantName=\"System.Data.SqlClient\" type=\"System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer\" />" +
                       "\n\t\t\t<provider invariantName=\"MySql.Data.MySqlClient\" type=\"MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.9.10.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d\" />" +
                       "\n\t\t</providers>" +
                       "\n\t</entityFramework>" +
                       "\n\t<system.data>" +
                       "\n\t\t<DbProviderFactories>" +
                       "\n\t\t\t<remove invariant=\"MySql.Data.MySqlClient\" />" +
                       "\n\t\t\t<add name=\"MySQL Data Provider\" invariant=\"MySql.Data.MySqlClient\" description=\".Net Framework Data Provider for MySQL\" type=\"MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.10.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d\" />" +
                       "\n\t\t</DbProviderFactories>" +
                       "\n\t</system.data>" +
                       "\n\t<connectionStrings>" +
                       "\n\t\t<add name=\"testsettingsEntities\" connectionString=\"metadata=res://*/Model.AutomationModel.csdl|res://*/Model.AutomationModel.ssdl|res://*/Model.AutomationModel.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;user id=root;password=root;persistsecurityinfo=True;server=localhost;database=testsettings&quot;\" providerName=\"System.Data.EntityClient\" />" +
                       "\n\t</connectionStrings>" +
                       "\n\t<appSettings >" +
                       $"\n\t\t<add key=\"targetBrowser\" value=\"{_browser}\"/>" +
                       $"\n\t\t<add key=\"operatingSystem\" value=\"{_os}\"/>" +
                       $"\n\t\t<add key=\"seleniumHubUri\" value=\"{_hub}\"/>" +
                       $"\n\t\t<add key=\"screenshotFolder\" value=\"{_screenshots}\"/>" +
                       "\n\t</appSettings>" +
                       "</configuration>";

            return text;
        }
    }
}