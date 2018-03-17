using Automation.NewDatabaseCore.Model;
using Microsoft.EntityFrameworkCore;

namespace Automation.NewDatabaseCore
{
    public class AutomationDatabaseContext : DbContext
    {
        public AutomationDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestConfiguration> Configurations { get; set; }
    }
}
