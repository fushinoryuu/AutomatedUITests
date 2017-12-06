using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using Automation.DatabaseCore;
using Automation.DatabaseCore.Models;
using Automation.IoCore.Utils;
using Microsoft.Extensions.Configuration;

namespace Automation.IoCore
{
    public class XmlTestCaseImporter
    {
        private TestsFromXml _testsFromXml;

        public bool ImportXmlFile(IConfiguration configuration, string path)
        {
            DesirializeXml(path);

            if (_testsFromXml == null)
                return false;

            SaveSuites(configuration);
            SaveTests(configuration);

            return true;
        }

        private void DesirializeXml(string path)
        {
            try
            {
                var reader = new StreamReader(path);
                var serializer = new XmlSerializer(typeof(TestsFromXml));

                _testsFromXml = (TestsFromXml)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                _testsFromXml = null;
            }
        }

        private void SaveSuites(IConfiguration configuration)
        {
            var suiteNames = _testsFromXml.ListOfTests.Select(i => i.TestSuite).ToList();
            var suiteNameSet = new HashSet<string>(suiteNames);
            var db = DbHelpers.OpenDbConnection(configuration);

            foreach (var name in suiteNameSet)
            {
                var inDb = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == name);

                // Suite already in db
                if (inDb != null)
                    continue;

                // Suite not in db
                db.Testsuites.Add(new Testsuite { TestsuiteName = name });
                db.SaveChanges();
            }

            db.Dispose();
        }

        private void SaveTests(IConfiguration configuration)
        {
            var db = DbHelpers.OpenDbConnection(configuration);

            foreach (var item in _testsFromXml.ListOfTests)
            {
                var inDb = db.Testcases.FirstOrDefault(i => i.TestcaseName == item.TestName);

                // Item already in db
                if (inDb != null)
                    continue;

                // Item not in db
                var suite = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == item.TestSuite);

                if (suite == null)
                    throw new Exception("TestSuite not found");

                var newTest = new Testcase
                {
                    TestcaseName = item.TestName,
                    BelongsToSuite = suite.TestsuiteId,
                    TestcaseDescription = item.TestCaseDescription,
                    TestSuite = suite
                };

                db.Testcases.Add(newTest);
                db.SaveChanges();
            }

            db.Dispose();
        }
    }
}