using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using Automation.Xml.Utils;
using Automation.Database.Model;

namespace Automation.Xml
{
    public class TestCaseImporter
    {
        private TestsFromXml _testsFromXml;

        public bool ImportXmlFile(string path)
        {
            DesirializeXml(path);

            if (_testsFromXml == null)
                return false;

            SaveSuites();
            SaveTests();

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

        private void SaveSuites()
        {
            var suiteNameSet = new HashSet<string>();

            foreach (var item in _testsFromXml.ListOfTests)
                suiteNameSet.Add(item.TestSuite);

            var db = new testsettingsEntities();

            foreach (var name in suiteNameSet)
            {
                var inDb = db.testsuites.FirstOrDefault(i => i.testsuitename == name);

                // Item already in db
                if (inDb != null)
                    continue;

                // Item not in db
                db.testsuites.Add(new testsuite { testsuitename = name });
                db.SaveChanges();
            }
        }

        private void SaveTests()
        {
            var db = new testsettingsEntities();

            foreach (var item in _testsFromXml.ListOfTests)
            {
                var inDb = db.testcases.FirstOrDefault(i => i.testcasename == item.TestName);

                // Item alrady in db
                if (inDb != null)
                    continue;

                // Item not in db
                var newTest = new testcase();
                var suite = db.testsuites.FirstOrDefault(i => i.testsuitename == item.TestSuite);

                if (suite == null)
                    throw new Exception("TestSuite not found");

                newTest.testcasename = item.TestName;
                newTest.belongstosuite = suite.testsuiteid;
                newTest.testsuite = suite;
                db.testcases.Add(newTest);
                db.SaveChanges();
            }
        }
    }
}