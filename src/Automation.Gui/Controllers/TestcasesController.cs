using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Automation.Database.Model;

namespace Automation.Gui.Controllers
{
    public class TestcasesController : Controller
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
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    var path = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(file.FileName));

                    file.SaveAs(path);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            else
            {
                Console.WriteLine("You have not specified a file.");
            }

            return RedirectToAction("Index");
        }
    }
}