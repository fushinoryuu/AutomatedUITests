using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Automation.Xml;
using Automation.Database.Model;

namespace Automation.Gui.Controllers
{
    public class TestResultsController : Controller
    {
        public static bool ImportSuccessful;
        public static bool TriedToImport;

        // GET: Testruns
        public ActionResult Index()
        {
            return View(GetOrderedList());
        }

        // GET: Testruns/Delete/5
        public ActionResult Delete(string guid)
        {
            using (var db = new testsettingsEntities())
            {
                if (string.IsNullOrWhiteSpace(guid))
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var testrun = db.testruns.Find(guid);

                if (testrun == null)
                    return HttpNotFound();

                return View(testrun);
            }
        }

        // POST: Testruns/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string guid)
        {
            using (var db = new testsettingsEntities())
            {
                var item = db.testruns.Find(guid);

                if (item == null)
                    throw new NoNullAllowedException("GUID field can't be null.");

                db.testruns.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult NunitDataExtraction()
        {
            TriedToImport = true;
            ImportSuccessful = new NunitDataExtractor().SaveResultsToDb();

            return RedirectToAction("Index");
        }

        private static IList<testrun> GetOrderedList()
        {
            using (var db = new testsettingsEntities())
            {
                return db.testruns.OrderByDescending(testrun => testrun.starttime).ToList();
            }
        }
    }
}