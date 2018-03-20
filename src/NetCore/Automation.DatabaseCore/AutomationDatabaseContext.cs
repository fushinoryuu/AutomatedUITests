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
    }
}
