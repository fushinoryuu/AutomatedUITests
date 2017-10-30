using System;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Automation.Xml;
using Automation.Database.Model;

namespace Automation.Gui.Controllers
{
    public class TestCasesController : Controller
    {
        private readonly testsettingsEntities _db = new testsettingsEntities();
        public static bool ImportSuccessful;
        public static bool TriedToImport;

        // GET: Tests
        public ActionResult Index()
        {
            return View(_db.testsuites.ToList());
        }

        public ActionResult ImportTests()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportXml(HttpPostedFileBase file)
        {
            TriedToImport = true;

            if (file == null || file.ContentLength <= 0 || !file.FileName.EndsWith("xml"))
            {
                ImportSuccessful = false;
                return RedirectToAction("Index");
            }

            try
            {
                var path = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(file.FileName));

                file.SaveAs(path);

                ImportSuccessful = new TestCaseImporter().ImportXmlFile(path);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                ImportSuccessful = false;
            }

            return RedirectToAction("Index");
        }

        public ActionResult SuiteDetails(int? suiteId)
        {
            if (suiteId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var items = _db.testcases.Where(i => i.testsuite.testsuiteid == suiteId).ToList();

            if (items.Count == 0)
                return HttpNotFound();

            return View(items);
        }

        public ActionResult DeleteSuite(int? suiteId)
        {
            if (suiteId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var suite = _db.testsuites.Find(suiteId);

            if (suite == null)
                return HttpNotFound();

            return View(suite);
        }

        [HttpPost, ActionName("DeleteSuite"), ValidateAntiForgeryToken]
        public ActionResult DeleteSuiteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}