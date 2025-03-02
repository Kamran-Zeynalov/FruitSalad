using Microsoft.AspNetCore.Mvc;
using SaladBack.Core;
using SaladBack.Data.DAL;

namespace SaladBack.Areas.AdminOfSalads.Controllers
{
    [Area("AdminOfSalads")]
    public class FruitController : Controller
    {
        private readonly SaladDbContext _context;

        public FruitController(SaladDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Fruit> fruits = _context.Fruits.ToList(); 
            return View(fruits);
        }
    }
}
