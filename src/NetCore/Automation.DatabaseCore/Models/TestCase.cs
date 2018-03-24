using System.ComponentModel.DataAnnotations;

namespace Automation.DatabaseCore.Models
{
    public class TestCase
    {
        public int CaseId { get; set; }

        [MaxLength(100)]
        public string CaseName { get; set; }

        public int BelongsToSuite { get; set; }

        [MaxLength(500)]
        public string CaseDescription { get; set; }
        
        public virtual TestSuite Suite { get; set; }
    }
}
