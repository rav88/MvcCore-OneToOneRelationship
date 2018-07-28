using Microsoft.AspNetCore.Mvc;

namespace MvcDzien3Configs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
