using System;
using System.ComponentModel.DataAnnotations;
using Automation.DatabaseCore.Interfaces;

namespace Automation.DatabaseCore.Models
{
    public class Testrun : ITestData
    {
        [MaxLength(36)]
        public string Guid { get; set; }

        public int TestcaseCount { get; set; }

        [MaxLength(12)]
        public string Result { get; set; }

        public int Passed { get; set; }

        public int Failed { get; set; }

        public int Inconclusive { get; set; }

        public int Skipped { get; set; }

        public DateTime Starttime { get; set; }

        public DateTime Endtime { get; set; }

        public double Duration { get; set; }
    }
}