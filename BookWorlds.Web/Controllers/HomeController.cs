using Microsoft.AspNetCore.Mvc;

namespace BookWorlds.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
