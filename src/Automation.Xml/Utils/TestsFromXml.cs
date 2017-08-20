using System.Xml.Serialization;
using System.Collections.Generic;

namespace Automation.Xml.Utils
{
    [XmlRoot("tests")]
    public class TestsFromXml
    {
        [XmlElement("test-suite")]
        public List<TestSuite> Suites { get; set; }
    }

    public class TestSuite
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("test-case")]
        public List<TestCase> TestCases { get; set; }
    }

    public class TestCase
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("step")]
        public List<string> TestSteps { get; set; }
    }
}