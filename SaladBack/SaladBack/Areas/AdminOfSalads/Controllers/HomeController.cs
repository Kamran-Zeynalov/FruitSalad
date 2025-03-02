using Microsoft.AspNetCore.Mvc;

namespace SaladBack.Areas.AdminOfSalads.Controllers
{
    [Area("AdminOfSalads")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
