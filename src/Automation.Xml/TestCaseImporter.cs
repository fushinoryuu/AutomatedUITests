using System.IO;
using System.Xml.Serialization;
using Automation.Xml.Utils;
using Automation.Database.Model;

namespace Automation.Xml
{
    public class TestCaseImporter
    {
        private XmlSerializer _serializer;
        private TestsFromXml _testsFromXml;
        private testsettingsEntities _db;

        public bool SaveTestsToDb(string path)
        {
            DesirializeXml(path);

            if (_serializer == null)
                return false;

            return true;
        }

        private void DesirializeXml(string path)
        {
            try
            {
                var reader = new StreamReader(path);

                _serializer = new XmlSerializer(typeof(TestsFromXml));
                _testsFromXml = (TestsFromXml)_serializer.Deserialize(reader);
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                _serializer = null;
            }
        }
    }
}