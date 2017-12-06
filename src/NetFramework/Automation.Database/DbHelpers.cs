using System.Linq;
using Automation.Database.Model;

namespace Automation.Database
{
    public static class DbHelpers
    {
        public static void DeactivateAll()
        {
            var db = new testsettingsEntities();
            var toUpdate = db.settings.Where(item => item.isActive == 1).ToList();

            toUpdate.ForEach(i => i.isActive = 0);
            db.SaveChanges();
            db.Dispose();
        }

        public static int GetNextId()
        {
            var db = new testsettingsEntities();
            var items = db.settings.OrderBy(item => item.id).ToList();

            if (!items.Any())
                return 1;

            return ++items.Last().id;
        }
    }
}