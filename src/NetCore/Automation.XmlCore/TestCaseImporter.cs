using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using Automation.DatabaseCore;
using Automation.DatabaseCore.Models;
using Automation.XmlCore.Utils;
using Microsoft.Extensions.Configuration;

namespace Automation.XmlCore
{
    public class TestCaseImporter
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
            var suiteNameSet = new HashSet<string>();

            foreach (var item in _testsFromXml.ListOfTests)
                suiteNameSet.Add(item.TestSuite);

            var db = DbHelpers.OpenDbConnection(configuration);

            foreach (var name in suiteNameSet)
            {
                var inDb = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == name);

                // Item already in db
                if (inDb != null)
                    continue;

                // Item not in db
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
                var newTest = new Testcase();
                var suite = db.Testsuites.FirstOrDefault(i => i.TestsuiteName == item.TestSuite);

                if (suite == null)
                    throw new Exception("TestSuite not found");

                newTest.TestcaseName = item.TestName;
                newTest.BelongsToSuite = suite.TestsuiteId;
                newTest.TestcaseDescription = item.TestCaseDescription;
                newTest.TestSuite = suite;

                db.Testcases.Add(newTest);
                db.SaveChanges();
            }

            db.Dispose();
        }
    }
}