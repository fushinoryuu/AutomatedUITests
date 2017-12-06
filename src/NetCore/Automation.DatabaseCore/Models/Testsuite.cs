using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Automation.DatabaseCore.Interfaces;

namespace Automation.DatabaseCore.Models
{
    public class Testsuite : ITestData
    {
        public int TestsuiteId { get; set; }

        [MaxLength(100)]
        public string TestsuiteName { get; set; }

        public virtual HashSet<Testcase> Testcases { get; set; }
    }
}