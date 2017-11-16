using Microsoft.EntityFrameworkCore;

namespace Automation.DatabaseCore.Model
{
    public class TestSettingsContext : DbContext
    {
        public TestSettingsContext(DbContextOptions options) : base(options)
        {
        }

        public static TestSettingsContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestSettingsContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new TestSettingsContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }

        public DbSet<Setting> Settings { get; set; }
    }
}