using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SaladBack.Core;
using SaladBack.Data.DAL;
using SaladBack.Service.Services.Interfaces;

namespace SaladBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFruitSaladService _fruitSaladService;

        public HomeController(IFruitSaladService fruitSaladService) => _fruitSaladService = fruitSaladService;

        public async Task<IActionResult> Index()
        {
            ViewBag.FruitSalads = await _fruitSaladService.GetAll();
            return View();
        }
    }
}
