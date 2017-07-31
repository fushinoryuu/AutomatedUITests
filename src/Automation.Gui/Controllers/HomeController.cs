using System.Web.Mvc;

namespace Automation.Gui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("Settings");
        }
    }
}