using System.Xml.Serialization;
using System.Collections.Generic;

namespace Automation.Xml.Utils
{
    [XmlRoot("tests")]
    public class TestsFromXml
    {
        [XmlElement("test")]
        public List<Tests> Suites { get; set; }

        public class Tests
        {
            [XmlAttribute("suite")]
            public string Suite { get; set; }

            [XmlElement("name")]
            public string Name { get; set; }

            public int Id { get; set; }
        }
    }
}