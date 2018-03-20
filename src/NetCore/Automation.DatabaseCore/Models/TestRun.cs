using System;
using System.ComponentModel.DataAnnotations;

namespace Automation.DatabaseCore.Models
{
    public class TestRun
    {
        [Key, MaxLength(36)]
        public string Guid { get; set; }

        public int TestCaseCount { get; set; }

        [MaxLength(12)]
        public string Result { get; set; }

        public int TestsPassed { get; set; }

        public int TestsFailed { get; set; }

        public int TestsInconclusive { get; set; }

        public int TestsSkipped { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public double Duration { get; set; }
    }
}