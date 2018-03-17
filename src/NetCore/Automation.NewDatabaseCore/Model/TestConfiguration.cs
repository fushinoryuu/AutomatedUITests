using System.ComponentModel.DataAnnotations;

namespace Automation.NewDatabaseCore.Model
{
    public class TestConfiguration
    {
        public int ConfigId { get; set; }

        [MaxLength(50)]
        public string TargetBrowser { get; set; }

        [MaxLength(50)]
        public string OperatingSystem { get; set; }

        [MaxLength(100)]
        public string SeleniumHubUri { get; set; }

        public sbyte IsActive { get; set; }
    }
}
