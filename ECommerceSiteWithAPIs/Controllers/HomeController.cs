using Microsoft.AspNetCore.Mvc;

namespace ECommerceSiteWithAPIs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
