using Microsoft.EntityFrameworkCore;

namespace Automation.DatabaseCore.Model
{
    public class TestSettingsFactory
    {
        public static TestSettingsContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestSettingsContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new TestSettingsContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}