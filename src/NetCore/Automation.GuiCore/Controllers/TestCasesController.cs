using Microsoft.AspNetCore.Mvc;

namespace Automation.GuiCore.Controllers
{
    public class TestCasesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
