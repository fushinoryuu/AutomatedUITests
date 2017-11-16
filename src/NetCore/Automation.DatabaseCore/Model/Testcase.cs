namespace Automation.DatabaseCore.Model
{
    public class Testcase
    {
        public int TestcaseId { get; set; }
        public string TestcaseName { get; set; }
        public int BelongsToSuite { get; set; }
        public string TestcaseDescription { get; set; }
        public virtual Testsuite TestSuite { get; set; }
    }
}
