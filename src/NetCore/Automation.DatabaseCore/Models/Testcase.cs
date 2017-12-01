using Automation.DatabaseCore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Automation.DatabaseCore.Models
{
    public class Testcase : ITestData
    {
        public int TestcaseId { get; set; }

        [MaxLength(100)]
        public string TestcaseName { get; set; }

        public int BelongsToSuite { get; set; }

        [MaxLength(500)]
        public string TestcaseDescription { get; set; }

        public virtual Testsuite TestSuite { get; set; }
    }
}
