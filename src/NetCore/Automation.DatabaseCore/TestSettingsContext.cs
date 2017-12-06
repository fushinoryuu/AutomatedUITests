using Microsoft.EntityFrameworkCore;
using Automation.DatabaseCore.Models;

namespace Automation.DatabaseCore
{
    public class TestSettingsContext : DbContext
    {
        public TestSettingsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Testcase> Testcases { get; set; }
        public DbSet<Testrun> Testruns { get; set; }
        public DbSet<Testsuite> Testsuites { get; set; }
    }
}