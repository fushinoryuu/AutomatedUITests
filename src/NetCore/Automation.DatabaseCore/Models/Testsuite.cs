using System.Collections.Generic;
using Automation.DatabaseCore.Interfaces;

namespace Automation.DatabaseCore.Models
{
    public class Testsuite : ITestData
    {
        public int TestsuiteId { get; set; }
        public string TestsuiteName { get; set; }
        public virtual HashSet<Testcase> Testcases { get; set; }
    }
}