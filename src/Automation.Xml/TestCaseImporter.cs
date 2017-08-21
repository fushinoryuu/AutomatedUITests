using System.IO;
using Automation.Xml.Utils;
using System.Xml.Serialization;
using Automation.Xml.Data;

namespace Automation.Xml
{
    public class TestCaseImporter
    {
        public TestCaseImporter()
        {
            var serializer = new XmlSerializer(typeof(TestsFromXml));
            var reader = new StreamReader(@"C:\AutomatedUiTests\resources\sample.xml");
            var tests = (TestsFromXml) serializer.Deserialize(reader);
            reader.Close();
        }
    }
}