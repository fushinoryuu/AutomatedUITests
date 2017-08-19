using System.Linq;
using System.Web.Mvc;
using Automation.Xml;
using Automation.Gui.Models;

namespace Automation.Gui.Controllers
{
    public class TestrunsController : Controller
    {
        private readonly testsettingsEntities _db = new testsettingsEntities();

        // GET: Testruns
        public ActionResult Index()
        {
            return View(_db.testruns.ToList());
        }

        public ActionResult NunitDataExtraction()
        {
            new NunitDataExtractor().SaveResultsToDb();

            return RedirectToAction("Index");
        }
    }
}