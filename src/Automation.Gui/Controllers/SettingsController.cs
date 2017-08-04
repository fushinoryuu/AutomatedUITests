using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Automation.Gui.Models;

namespace Automation.Gui.Controllers
{
    public class SettingsController : Controller
    {
        private readonly testsettingsEntities _db = new testsettingsEntities();

        // GET: Settings
        public ActionResult Index()
        {
            return View(_db.settings.ToList());
        }

        // GET: Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var setting = _db.settings.Find(id);

            if (setting == null)
                return HttpNotFound();

            return View(setting);
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,targetBrowser,operatingSystem,seleniumHubUri,screenshotFolder,isActive")] setting setting)
        {
            setting.id = GetNextId();

            if (ModelState.IsValid)
            {
                if (setting.isActive == 1)
                    DeactivateAll();

                _db.settings.Add(setting);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        protected int GetNextId()
        {
            var items = (from item in _db.settings
                         orderby item.id
                         select item).ToList();

            var nextNumber = items.Last().id;

            return ++nextNumber;
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var setting = _db.settings.Find(id);

            if (setting == null)
                return HttpNotFound();

            return View(setting);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,targetBrowser,operatingSystem,seleniumHubUri,screenshotFolder,isActive")] setting setting)
        {
            if (ModelState.IsValid)
            {
                if (setting.isActive == 1)
                    DeactivateAll();

                _db.Entry(setting).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        private static void DeactivateAll()
        {
            using (var localDb = new testsettingsEntities())
            {
                var toUpdate = (from item in localDb.settings
                                where item.isActive == 1
                                select item).ToList();

                toUpdate.ForEach(i => i.isActive = 0);
                localDb.SaveChanges();
                localDb.Dispose();
            }
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var setting = _db.settings.Find(id);

            if (setting == null)
                return HttpNotFound();

            return View(setting);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = _db.settings.Find(id);

            if (item == null)
                throw new NoNullAllowedException("Id field can't be null.");

            _db.settings.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult GenerateXml()
        {
            new ConfigWriter.XmlWriter().OutputXml();

            return View(_db.settings.ToList());
        }
    }
}