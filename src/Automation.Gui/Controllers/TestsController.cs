using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Automation.Xml;
using Automation.Gui.Models;

namespace Automation.Gui.Controllers
{
    public class TestsController : Controller
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
        public ActionResult ImportTest()
        {
            TriedToImport = true;

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.GetFullPath(file.FileName);
                    ImportSuccessful = new TestCaseImporter().SaveTestsToDb(path);
                }
            }

            return RedirectToAction("Index");
        }
    }
}