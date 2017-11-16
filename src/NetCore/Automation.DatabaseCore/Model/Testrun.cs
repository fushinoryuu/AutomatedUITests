using System;

namespace Automation.DatabaseCore.Model
{
    public class Testrun : TestSettingsContext
    {
        public string Guid { get; set; }
        public int TestcaseCount { get; set; }
        public string Result { get; set; }
        public int Passed { get; set; }
        public int Failed { get; set; }
        public int Inconclusive { get; set; }
        public int Skipped { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public double Duration { get; set; }

        public Testrun(string connectionString) : base(connectionString)
        {
        }
    }
}