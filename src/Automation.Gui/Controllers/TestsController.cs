using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Automation.Xml;
using Automation.Gui.Models;

namespace Automation.Gui.Controllers
{
    public class TestsController : Controller
    {
        private readonly testsettingsEntities _db = new testsettingsEntities();

        // GET: Tests
        public ActionResult Index()
        {
            return View(_db.testsuites.ToList());
        }
    }
}