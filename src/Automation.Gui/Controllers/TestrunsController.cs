using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Automation.Xml;
using Automation.Database.Model;

namespace Automation.Gui.Controllers
{
    public class TestrunsController : Controller
    {
        private readonly testsettingsEntities _db = new testsettingsEntities();
        public static bool ImportSuccessful;

        // GET: Testruns
        public ActionResult Index()
        {
            return View(GetOrderedList());
        }

        // GET: Testruns/Delete/5
        public ActionResult Delete(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var testrun = _db.testruns.Find(guid);

            if (testrun == null)
                return HttpNotFound();

            return View(testrun);
        }

        // POST: Testruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string guid)
        {
            var item = _db.testruns.Find(guid);

            if (item == null)
                throw new NoNullAllowedException("GUID field can't be null.");

            _db.testruns.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult NunitDataExtraction()
        {
            ImportSuccessful = new NunitDataExtractor().SaveResultsToDb();

            return View(GetOrderedList());
        }

        private IList<testrun> GetOrderedList()
        {
            return _db.testruns.OrderByDescending(testrun => testrun.starttime).ToList();
        }
    }
}