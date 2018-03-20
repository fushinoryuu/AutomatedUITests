using Automation.DatabaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Automation.DatabaseCore
{
    public class AutomationDatabaseContext : DbContext
    {
        public AutomationDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestConfiguration> TestConfigurations { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestSuite> TestSuites { get; set; }
    }
}
