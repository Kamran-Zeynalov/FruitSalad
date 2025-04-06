using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Data.DAL;
using SaladBack.Service.Services.Interfaces;

namespace SaladBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly SaladDbContext _context;

        public HomeController(SaladDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.FruitSalads = await _context.FruitSalads
                                                    .Include(fs =>fs.SaladImages)
                                                    .Include(fs => fs.FruitSaladFruits)
                                                        .ThenInclude(fs => fs.Fruit)
                                                    .ToListAsync();
            return View();
        }
    }
}
