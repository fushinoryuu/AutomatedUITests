using System.Collections.Generic;

namespace Automation.DatabaseCore.Model
{
    public class Testsuite : TestSettingsContext
    {
        public int TestsuiteId { get; set; }
        public string TestsuiteName { get; set; }
        public virtual HashSet<Testcase> Testcases { get; set; }

        public Testsuite(string connectionString) : base(connectionString)
        {
        }
    }
}