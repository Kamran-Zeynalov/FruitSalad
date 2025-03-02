using Microsoft.AspNetCore.Mvc;
using SaladBack.Core.Models;
using SaladBack.Service.Services.Interfaces;

namespace SaladBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly IFruitSaladService _fruitSaladService;
        private readonly IFruitService _fruitService;

        public ProductController(IFruitSaladService fruitSaladService, IFruitService fruitService)
        {
            _fruitSaladService = fruitSaladService;
            _fruitService = fruitService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            FruitSalad fruitSalad = await _fruitSaladService.Get(id);
            ViewBag.AllFruits = await _fruitService.GetAll();
            return View(fruitSalad);
        }
    }
}
