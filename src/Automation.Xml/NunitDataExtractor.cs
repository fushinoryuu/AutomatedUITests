using System;
using System.Xml;
using Automation.Database.Model;

namespace Automation.Xml
{
    public class NunitDataExtractor
    {
        private XmlDocument _document = new XmlDocument();
        private testrun _result;

        public bool SaveResultsToDb()
        {
            LoadXml();

            if (_document == null)
                return false;

            GetDataFromXml();
            SaveResults();

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
            _result = new testrun
            {
                guid = Guid.NewGuid().ToString(),
                // ReSharper disable once PossibleNullReferenceException
                testcasecount = int.Parse(_document.DocumentElement.Attributes["testcasecount"].Value),
                result = _document.DocumentElement.Attributes["result"].Value,
                passed = int.Parse(_document.DocumentElement.Attributes["passed"].Value),
                failed = int.Parse(_document.DocumentElement.Attributes["failed"].Value),
                inconclusive = int.Parse(_document.DocumentElement.Attributes["inconclusive"].Value),
                skipped = int.Parse(_document.DocumentElement.Attributes["skipped"].Value),
                starttime = DateTime.Parse(_document.DocumentElement.Attributes["start-time"].Value),
                endtime = DateTime.Parse(_document.DocumentElement.Attributes["end-time"].Value),
                duration = double.Parse(_document.DocumentElement.Attributes["duration"].Value)
            };
        }

        private void SaveResults()
        {
            var db = new testsettingsEntities();

            db.testruns.Add(_result);
            db.SaveChanges();
            db.Dispose();
        }
    }
}