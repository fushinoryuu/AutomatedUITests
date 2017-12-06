using System.Xml.Serialization;
using System.Collections.Generic;

namespace Automation.IoCore.Utils
{
    [XmlRoot("tests")]
    internal class TestsFromXml
    {
        [XmlElement("test")]
        public IList<Tests> ListOfTests { get; set; }

        internal class Tests
        {
            [XmlAttribute("testsuite")]
            public string TestSuite { get; set; }

            [XmlAttribute("testname")]
            public string TestName { get; set; }

            [XmlAttribute("testcasedescription")]
            public string TestCaseDescription { get; set; }
        }
    }
}