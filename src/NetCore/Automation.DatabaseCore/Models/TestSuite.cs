using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Automation.DatabaseCore.Models
{
    public class TestSuite
    {
        public int SuiteId { get; set; }

        [MaxLength(100)]
        public string SuiteName { get; set; }

        public virtual HashSet<TestCase> CasesInSuite { get; set; }
    }
}