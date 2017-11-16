using System;
using System.IO;
using System.Xml.Serialization;
using Automation.XmlCore.Utils;

namespace Automation.XmlCore
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

                _testsFromXml = (TestsFromXml) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                _testsFromXml = null;
            }
        }

        private void SaveSuites()
        {
            throw new NotImplementedException();
        }

        private void SaveTests()
        {
            throw new NotImplementedException();
        }
    }
}