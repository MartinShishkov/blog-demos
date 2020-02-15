using Microsoft.AspNetCore.Mvc;

namespace CleanControllers.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
