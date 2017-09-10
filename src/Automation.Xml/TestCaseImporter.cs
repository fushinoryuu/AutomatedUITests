using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Automation.Xml.Utils;
using Automation.Database.Model;

namespace Automation.Xml
{
    public class TestCaseImporter
    {
        private TestsFromXml _testsFromXml;
        private List<testcase> _cases;
        private List<testsuite> _suites;

        public bool SaveTestsToDb(string path)
        {
            DesirializeXml(path);

            if (_testsFromXml == null)
                return false;

            SaveSuites();

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
                suiteNameSet.Add(item.Suite);

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
        }
    }
}