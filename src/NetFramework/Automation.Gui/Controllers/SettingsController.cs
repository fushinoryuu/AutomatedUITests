using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using Automation.Xml;
using Automation.Tests.Utils;
using Automation.Database.Model;

namespace Automation.Gui.Controllers
{
    public class SettingsController : Controller
    {
        private int _processId;

        // GET: Settings
        public ActionResult Index()
        {
            using (var db = new testsettingsEntities())
            {
                return View(db.settings.ToList());
            }
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,targetBrowser,operatingSystem,seleniumHubUri,screenshotFolder,isActive")] setting setting)
        {
            setting.id = Database.DbHelpers.GetNextId();

            using (var db = new testsettingsEntities())
            {
                if (ModelState.IsValid)
                {
                    if (setting.isActive == 1)
                        Database.DbHelpers.DeactivateAll();

                    db.settings.Add(setting);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(setting);
            }
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new testsettingsEntities())
            {
                var setting = db.settings.Find(id);

                if (setting == null)
                    return HttpNotFound();

                return View(setting);
            }
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,targetBrowser,operatingSystem,seleniumHubUri,screenshotFolder,isActive")] setting setting)
        {
            if (!ModelState.IsValid)
                return View(setting);

            using (var db = new testsettingsEntities())
            {
                if (setting.isActive == 1)
                    Database.DbHelpers.DeactivateAll();

                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new testsettingsEntities())
            {
                var setting = db.settings.Find(id);

                if (setting == null)
                    return HttpNotFound();

                return View(setting);
            }
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new testsettingsEntities())
            {
                var item = db.settings.Find(id);

                if (item == null)
                    throw new NoNullAllowedException("Id field can't be null.");

                db.settings.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult GenerateXml()
        {
            new AppConfigWriter().OutputXml();

            using (var db = new testsettingsEntities())
            {
                return View(db.settings.ToList());
            }
        }

        public ActionResult RunAutomatedTests()
        {
            // If you move or rename the root directory 'SeleniumAutomationToolbox', please update these paths
#if DEBUG
            const string path = @"C:\SeleniumAutomationToolbox\src\NetFramework\Automation.Tests\bin\Debug\Automation.Tests.dll";
#endif

#if !DEBUG
            const string path = @"C:\SeleniumAutomationToolbox\src\NetFramework\Automation.Tests\bin\Release\Automation.Tests.dll";
#endif

            _processId = RunTestsHelper.RunNunitTests(
                $"{path} " +
                "--workers=30 " +
                @"--work=C:\SeleniumAutomationToolbox\NunitWork " +
                "--trace=Verbose",
                ProcessWindowStyle.Normal);

            using (var db = new testsettingsEntities())
            {
                return View(db.settings.ToList());
            }
        }

        public ActionResult StopAutomatedTests()
        {
            RunTestsHelper.StopNunitTests(_processId);

            using (var db = new testsettingsEntities())
            {
                return View(db.settings.ToList());
            }
        }
    }
}