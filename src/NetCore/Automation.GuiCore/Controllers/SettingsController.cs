using System.Data;
using System.Linq;
using Automation.NewDatabaseCore;
using Automation.NewDatabaseCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Automation.GuiCore.Controllers
{
    public class SettingsController : Controller
    {
        public IConfigurationRoot Configuration { get; }
        private AutomationDatabaseContext Db { get; }

        public SettingsController(IConfigurationRoot configuration)
        {
            Configuration = configuration;
            Db = DbHelpers.OpenDbConnection(Configuration);
        }

        // GET: Settings
        public IActionResult Index()
        {
            var list = Db.Configurations.ToList();

            Db.Dispose();

            return View(list);
        }

        // GET: Settings/Create
        public IActionResult Create()
        {
            // TODO - Create view
            return Index();
        }

        // POST: Settings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody]TestConfiguration setting)
        {
            // TODO - Create view
            return Index();
        }

        // GET: Settings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var setting = Db.Configurations.Find(id);

            if (setting == null)
                return NotFound();

            Db.Dispose();

            // TODO - Create view
            return Index();
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = Db.Configurations.Find(id);

            if (item == null)
                throw new NoNullAllowedException("ID field can't be null.");

            Db.Configurations.Remove(item);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult GenerateSettingsFile()
        {
            // TODO - Update this method Automation.IO project is done
            return Index();
        }

        public IActionResult RunAutomatedTests()
        {
            // TODO - Update this method when Automation.Tests.Utils project is done
            return Index();
        }

        public IActionResult StopAutomatedTests()
        {
            // TODO - Update this method when Automation.Tests.Utils project is done
            return Index();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Db.Dispose();

            base.Dispose(disposing);
        }
    }
}