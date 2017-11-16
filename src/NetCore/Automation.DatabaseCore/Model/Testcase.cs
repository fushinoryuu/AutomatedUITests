namespace Automation.DatabaseCore.Model
{
    public class Testcase : TestSettingsEntities
    {
        public int TestcaseId { get; set; }
        public string TestcaseName { get; set; }
        public int BelongsToSuite { get; set; }
        public string TestcaseDescription { get; set; }
        public virtual Testsuite TestSuite { get; set; }

        public Testcase(string connectionString) : base(connectionString)
        {
        }
    }
}
