using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladBack.Core.Models;
using SaladBack.Data.DAL;
using SaladBack.Service.Services.Interfaces;

namespace SaladBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly SaladDbContext _context;
        private readonly IFruitService _fruitService;

        public ProductController(SaladDbContext context, IFruitService fruitService)
        {
            _context = context;
            _fruitService = fruitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            FruitSalad? fruitSalad = await _context.FruitSalads.FirstOrDefaultAsync(fs => fs.Id ==id);
            ViewBag.AllFruits = await _fruitService.GetAll();
            return View(fruitSalad);
        }
    }
}
