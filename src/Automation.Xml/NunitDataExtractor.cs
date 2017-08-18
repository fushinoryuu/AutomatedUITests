using System;
using System.IO;
using System.Xml;
using Automation.Xml.Data;

namespace Automation.Xml
{
    public class NunitDataExtractor
    {
        private readonly XmlDocument _document = new XmlDocument();
        private Guid _guid;
        private int _testCaseCount;
        private string _result;
        private int _passed;
        private int _failed;
        private int _inconclusive;
        private int _skipped;
        private DateTime _starttime;
        private DateTime _endtime;
        private double _duration;

        public void SaveResultsToDb()
        {
            LoadXml();

            if (_document.DocumentElement == null)
                return;

            GetDataFromXml();
            SaveResults();
        }

        private void LoadXml()
        {
            try
            {
                _document.Load(@"C:\AutomatedUiTests\NunitWork\TestResult.xml");
            }
            catch (FileNotFoundException)
            {
                // ignored
            }
        }

        private void GetDataFromXml()
        {
            _guid = Guid.NewGuid();
            _testCaseCount = int.Parse(_document.DocumentElement.Attributes["testcasecount"].Value);
            _result = _document.DocumentElement.Attributes["result"].Value;
            _passed = int.Parse(_document.DocumentElement.Attributes["passed"].Value);
            _failed = int.Parse(_document.DocumentElement.Attributes["failed"].Value);
            _inconclusive = int.Parse(_document.DocumentElement.Attributes["inconclusive"].Value);
            _skipped = int.Parse(_document.DocumentElement.Attributes["skipped"].Value);
            _starttime = DateTime.Parse(_document.DocumentElement.Attributes["start-time"].Value);
            _endtime = DateTime.Parse(_document.DocumentElement.Attributes["end-time"].Value);
            _duration = double.Parse(_document.DocumentElement.Attributes["duration"].Value);
        }

        private void SaveResults()
        {
            var db = new xmlTestSettingsEntities();

            db.testruns.Add(new testrun
            {
                guid = _guid,
                testcasecount = _testCaseCount,
                result = _result,
                passed = _passed,
                failed = _failed,
                inconclusive = _inconclusive,
                skipped = _skipped,
                starttime = _starttime,
                endtime = _endtime,
                duration = _duration
            });

            db.SaveChanges();
        }
    }
}