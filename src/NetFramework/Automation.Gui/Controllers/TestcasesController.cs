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
        public static bool ImportSuccessful;
        public static bool TriedToImport;

        // GET: Tests
        public ActionResult Index()
        {
            using (var db = new testsettingsEntities())
            {
                return View(db.testsuites.ToList());
            }
        }

        public ActionResult ImportTests()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ImportXml(HttpPostedFileBase file)
        {
            TriedToImport = true;

            try
            {
                var extension = Path.GetExtension(file.FileName);

                // ReSharper disable once PossibleNullReferenceException
                if (file.ContentLength <= 0 || !extension.Equals(".xml"))
                {
                    ImportSuccessful = false;

                    return RedirectToAction("Index");
                }

                var path = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(file.FileName) 
                    ?? throw new InvalidOperationException());

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

            using (var db = new testsettingsEntities())
            {
                var items = db.testcases.Where(i => i.testsuite.testsuiteid == suiteId).ToList();

                if (items.Count == 0)
                    return HttpNotFound();

                return View(items);
            }
        }

        public ActionResult DeleteSuite(int? suiteId)
        {
            if (suiteId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new testsettingsEntities())
            {
                var suite = db.testsuites.Find(suiteId);

                if (suite == null)
                    return HttpNotFound("Test suite not found.");

                return View(suite);
            }
        }

        [HttpPost, ActionName("DeleteSuite"), ValidateAntiForgeryToken]
        public ActionResult DeleteSuiteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCase(int? caseId)
        {
            if (caseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new testsettingsEntities())
            {
                var caseObj = db.testcases.Find(caseId);

                if (caseObj == null)
                    return HttpNotFound("Test case not found.");

                return View(caseObj);
            }
        }

        [HttpPost, ActionName("DeleteCase"), ValidateAntiForgeryToken]
        public ActionResult DeleteCaseConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}