using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Data.DAL;
using SaladBack.Service.Extentions;

namespace SaladBack.Areas.AdminOfSalads.Controllers
{
    [Area("AdminOfSalads")]
    public class FruitController : Controller
    {
        private readonly SaladDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FruitController(SaladDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Fruit> fruits = _context.Fruits.OrderByDescending(p => p.Id).ToList();
            return View(fruits);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fruit fruit)
        {
            if (_context.Fruits.Any(f => f.Name == fruit.Name))
            {
                ModelState.AddModelError("", "Same Value");
                return View();
            };
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Check Value");
                return View();
            }
            
            //_env.WebRootPath/assets/images
            string imagePath = Path.Combine(_env.WebRootPath, "assets", "images");
            fruit.ImageUrl = fruit.Image.AddImage(imagePath);

            _context.Fruits.Add(fruit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Edit(int id) {
            Fruit? fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);
            return View(fruit);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, string name, string desc, IFormFile image)
        {
            if (id is null) return BadRequest();
            Fruit? fruit = _context.Fruits.FirstOrDefault(f => f.Id == id);
            if (fruit is null) return BadRequest();

            if (_context.Fruits.Any(f => f.Name == name && f.Id != id)) {
                ModelState.AddModelError("Name", "Same Name");
                return View();
            }
            fruit.Name = name;
            fruit.Desc = desc;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Detail(int? id)
        {
        if(id is null) return NotFound();
        Fruit? fruit = _context.Fruits.SingleOrDefault(f => f.Id == id);
        if (fruit is null) return BadRequest();
        return View(fruit);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();
            Fruit? fruit = _context.Fruits.SingleOrDefault(f => f.Id == id);
            if (fruit is null) return BadRequest();
            return View(fruit);
        }
        [HttpPost]
        public IActionResult Delete(Fruit fruit)
        {

         _context.Fruits.Remove(fruit);
            _context.SaveChanges();
        return RedirectToAction("Index");
        }

        
        public IActionResult Search(string name)
        {
            List<Fruit> fruits = _context.Fruits.Where(f =>f.Name.ToLower().Contains(name.ToLower())).ToList();
            return PartialView("_FruitPartial", fruits.ToList());
        }


    }
}
