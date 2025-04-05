using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Core.Models;
using SaladBack.Data.DAL;
using SaladBack.Service.Extentions;
using SaladBack.Service.Services.Interfaces;

namespace SaladBack.Areas.AdminOfSalads.Controllers
{
    [Area("AdminOfSalads")]
    public class FruitSaladController : Controller
    {
        private readonly SaladDbContext _context;
        private readonly IFruitSaladService _fruitSaladService;
        private readonly IFruitService _fruitService;
        private readonly IWebHostEnvironment _env;

        public FruitSaladController(SaladDbContext context, IFruitSaladService fruitSaladService, IFruitService fruitService, IWebHostEnvironment env)
        {
            _context = context;
            _fruitSaladService = fruitSaladService;
            _fruitService = fruitService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<FruitSalad> fruitSalads = await _fruitSaladService.GetAll();
            return View(fruitSalads);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Fruits = await _fruitService.GetAll();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int[] fruitId, FruitSalad fruitSalad)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill all fields");
            }
            if (fruitSalad is null)
            {
                throw new ArgumentNullException("fruitSalad");
            }

            //if (fruitSalad.Name.Any())
            //{
            //    throw new AbandonedMutexException("Name");
            //}
            List<Fruit> fruits = await _fruitService.GetAll();
            if (fruits.Count == 0)
            {
                throw new ArgumentNullException("Fruits");
            }
            foreach (var fruit in fruits)
            {
                for (int i = 0; i < fruitId.Length; i++)
                {
                    if (fruit.Id == fruitId[i])
                    {
                        FruitSaladFruit fruitsSaladFruit = new()
                        {
                            FruitId = fruit.Id,
                        };
                        fruitSalad.FruitSaladFruits?.Add(fruitsSaladFruit);
                    }
                }
            }

            foreach (var image in fruitSalad.SaladImages)
            {

                string path = Path.Combine(_env.WebRootPath, "assets", "images");
                image.ImageFile.AddImage(path);

                SaladImage saladImg = new SaladImage
                {
                    Url = image.ImageFile.FileName,

                };
                fruitSalad.SaladImages.Add(saladImg);
            }

            _context.FruitSalads.Add(fruitSalad);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }
    }
}
