using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}