using System.Linq;
using Automation.DatabaseCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Automation.GuiCore.Controllers
{
    public class SettingsController : Controller
    {
        public IConfigurationRoot Configuration { get; }

        public SettingsController(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        // GET: Settings
        public IActionResult Index()
        {
            var db = DbHelpers.OpenDbConnection(Configuration);
            var list = db.Settings.ToList();

            db.Dispose();

            return View(list);
        }
    }
}