﻿using System.IO;
using Automation.XmlSerializer.MappingData;

namespace Automation.XmlSerializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteXml();
        }

        private static void WriteXml()
        {
            var config = new configuration();
            const string path = "../../../Automation.Tests/bin/Debug/App.config";
            //File.Create(path);
            var text = FileText(config);

            File.WriteAllText(path, text);
        }

        private static string FileText(configuration config)
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