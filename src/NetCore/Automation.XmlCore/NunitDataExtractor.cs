using System;
using System.Xml;
using Automation.DatabaseCore;
using Automation.DatabaseCore.Models;
using Microsoft.Extensions.Configuration;

namespace Automation.XmlCore
{
    public class NunitDataExtractor
    {
        private XmlDocument _document = new XmlDocument();
        private Testrun _result;

        public bool SaveResultsToDb(IConfigurationRoot configuration)
        {
            LoadXml();

            if (_document == null)
                return false;

            GetDataFromXml();
            SaveResults(configuration);

            return true;
        }

        private void LoadXml()
        {
            try
            {
                _document.Load(@"C:\AutomationToolboox\NunitWork\TestResult.xml");
            }
            catch (Exception)
            {
                _document = null;
            }
        }

        private void GetDataFromXml()
        {
            _result = new Testrun()
            {
                Guid = Guid.NewGuid().ToString(),
                // ReSharper disable once PossibleNullReferenceException
                TestcaseCount = int.Parse(_document.DocumentElement.Attributes["testcasecount"].Value),
                Result = _document.DocumentElement.Attributes["result"].Value,
                Passed = int.Parse(_document.DocumentElement.Attributes["passed"].Value),
                Failed = int.Parse(_document.DocumentElement.Attributes["failed"].Value),
                Inconclusive = int.Parse(_document.DocumentElement.Attributes["inconclusive"].Value),
                Skipped = int.Parse(_document.DocumentElement.Attributes["skipped"].Value),
                Starttime = DateTime.Parse(_document.DocumentElement.Attributes["start-time"].Value),
                Endtime = DateTime.Parse(_document.DocumentElement.Attributes["end-time"].Value),
                Duration = double.Parse(_document.DocumentElement.Attributes["duration"].Value)
            };
        }

        private void SaveResults(IConfiguration configuration)
        {
            var db = DbHelpers.OpenDbConnection(configuration);

            db.Testruns.Add(_result);
            db.SaveChanges();
            db.Dispose();
        }
    }
}