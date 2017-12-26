using Microsoft.AspNetCore.Mvc;

namespace Automation.GuiCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                return View();
            }

            catch
            {
                return Error();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
