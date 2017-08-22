using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Automation.Selenium.Utils;

namespace Automation.Selenium
{
    public static class EnvironmentVariables
    {
        public static DesiredCapabilities TargetBrowserEnv = null;
        public static Platform OperatingSystemEnv = null;
        public static Uri SeleniumHubUriEnv = null;
        public static string ScreenshotFolderEnv = null;

        public static void SetVariables(string browser, string os, string uri, string path)
        {
            SetBrowser(browser);
            SetOs(os);
            SetHub(uri);
            SetFolder(path);
        }

        private static void SetBrowser(string browser)
        {
            if (TargetBrowserEnv != null)
                return;

            BrowserType targetBrowser;
            Enum.TryParse(browser, out targetBrowser);

            switch (targetBrowser)
            {
                case BrowserType.Chrome:
                    TargetBrowserEnv = DesiredCapabilities.Chrome();
                    return;
                case BrowserType.Ie:
                    TargetBrowserEnv = DesiredCapabilities.InternetExplorer();
                    return;
                case BrowserType.Firefox:
                    TargetBrowserEnv = DesiredCapabilities.Firefox();
                    return;
                case BrowserType.Safari:
                    TargetBrowserEnv = DesiredCapabilities.Safari();
                    return;
                default:
                    TargetBrowserEnv = DesiredCapabilities.Chrome();
                    return;
            }
        }

        private static void SetOs(string os)
        {
            if (OperatingSystemEnv != null)
                return;

            OperatingSystemType operatingSystem;
            Enum.TryParse(os, out operatingSystem);

            switch (operatingSystem)
            {
                case OperatingSystemType.Any:
                    OperatingSystemEnv = new Platform(PlatformType.Any);
                    return;
                case OperatingSystemType.Linux:
                    OperatingSystemEnv = new Platform(PlatformType.Linux);
                    return;
                case OperatingSystemType.Mac:
                    OperatingSystemEnv = new Platform(PlatformType.Mac);
                    return;
                case OperatingSystemType.Windows:
                    OperatingSystemEnv = new Platform(PlatformType.Windows);
                    return;
                default:
                    OperatingSystemEnv = new Platform(PlatformType.Windows);
                    return;
            }
        }

        private static void SetHub(string uri)
        {
            if (SeleniumHubUriEnv != null)
                return;

            SeleniumHubUriEnv = string.IsNullOrWhiteSpace(uri)
                ? new Uri("http://localhost:4444/wd/hub") : new Uri(uri);
        }

        private static void SetFolder(string path)
        {
            if (ScreenshotFolderEnv != null)
                return;

            ScreenshotFolderEnv = string.IsNullOrWhiteSpace(path)
                ? "C:\\UI_Test_Screenshots\\" : path;
        }
    }
}