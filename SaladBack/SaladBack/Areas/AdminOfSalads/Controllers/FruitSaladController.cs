using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SaladBack.Core;
using SaladBack.Core.Models;
using SaladBack.Data.DAL;
using SaladBack.Service.Extentions;
using SaladBack.Service.Services.Interfaces;
using SaladBack.ViewModel;

namespace SaladBack.Areas.AdminOfSalads.Controllers
{
    [Area("AdminOfSalads")]
    public class FruitSaladController : Controller
    {
        private readonly SaladDbContext _context;
        private readonly IFruitService _fruitService;
        private readonly IWebHostEnvironment _env;

        public FruitSaladController(SaladDbContext context, IFruitService fruitService, IWebHostEnvironment env)
        {
            _context = context;
            _fruitService = fruitService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<FruitSalad> fruitSalads = await _context.FruitSalads.Include(fs => fs.SaladImages).OrderByDescending(f => f.Id).ToListAsync();
            return View(fruitSalads);
        }
        [HttpGet]
        public async Task<IActionResult> Create(FruitSaladVM vm)
        {
            vm.Fruits = await _fruitService.GetAll();
            vm.Sizes = await _context.Sizes.ToListAsync();
            return View(vm);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(FruitSaladVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill all fields");
                vm.Fruits = await _fruitService.GetAll();
                vm.Sizes = await _context.Sizes.ToListAsync();
                return View(vm);
            }
            if (vm.Name is null)
            {
                ModelState.AddModelError("", "Please fill Name fields");
                vm.Fruits = await _fruitService.GetAll();
                vm.Sizes = await _context.Sizes.ToListAsync();
                return View(vm);
            }
            if (vm.Files is null)
            {
                ModelState.AddModelError("", "Please fill Files fields");
                vm.Fruits = await _fruitService.GetAll();
                vm.Sizes = await _context.Sizes.ToListAsync();
                return View(vm);
            }
            if (vm.FruitId is null)
            {
                ModelState.AddModelError("", "Please fill Fruits fields");
                vm.Fruits = await _fruitService.GetAll();
                vm.Sizes = await _context.Sizes.ToListAsync();
                return View(vm);
            }
            //if (vm.ImageIds is null)
            //{
            //    ModelState.AddModelError("", "Please fill Images fields");
            //    vm.Fruits = await _fruitService.GetAll();
            //    vm.Sizes = await _context.Sizes.ToListAsync();
            //    return View(vm);
            //}


            FruitSalad fruitSalad = new FruitSalad
            {
                Name = vm.Name,
                Price = vm.Price,
                Rating = vm.Rating,
                Count = vm.Count,
                FruitSaladFruits = new List<FruitSaladFruit>(),
                SaladImages = new List<SaladImage>(),
                //Sizes= new List<Size>(),
            };
            if (vm.FruitId != null && vm.FruitId.Any())
            {
                foreach (var id in vm.FruitId)
                {
                    fruitSalad.FruitSaladFruits.Add(new FruitSaladFruit
                    {
                        FruitId = id
                    });
                }
            }

            var size = _context.Sizes.FirstOrDefault(s => s.Id == vm.SizeId);
            if (size == null)
            {
                vm.Sizes = _context.Sizes.AsNoTracking().ToList();
                return View(vm);
            }
            fruitSalad.Sizes?.Add(size);

            //if (vm.SizeId != null && vm.SizeId.Any())
            //{
            //    foreach (var id in vm.SizeId)
            //    {
            //        Size relatedSize = new()
            //        {
            //            FruitSaladId = id, 
            //        };
            //        fruitSalad.Sizes.Add(relatedSize);
            //    }
            //}

            if (vm.Files != null && vm.Files.Any())
            {
                string path = Path.Combine(_env.WebRootPath, "assets", "images");

                foreach (var file in vm.Files)
                {
                    file.AddImage(path);

                    SaladImage saladImg = new()
                    {
                        Url = file.AddImage(path),
                    };

                    fruitSalad.SaladImages.Add(saladImg);
                }
            }

            _context.FruitSalads.Add(fruitSalad);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return NotFound();
            FruitSalad? fruitSalad = await _context.FruitSalads
                                                .Include(fs => fs.SaladImages)
                                                .Include(fs => fs.FruitSaladFruits).ThenInclude(fs => fs.Fruit)
                                                .FirstOrDefaultAsync(fs => fs.Id == id);
            if (fruitSalad == null) return NotFound();
            FruitSaladVM vm = new()
            {
                Id = fruitSalad.Id,
                Name = fruitSalad.Name,
                Price = fruitSalad.Price,
                Rating = fruitSalad.Rating,
                Count = fruitSalad.Count,
                ImageIds = fruitSalad.SaladImages?.Select(i => i.Id).ToList(),
                Images = fruitSalad.SaladImages?.ToList(),
                FruitId = fruitSalad.FruitSaladFruits?.Select(i => i.FruitId).ToList(),
                //SizeId = fruitSalad.Sizes?.Select(i => i.FruitSaladId).ToList(),
                Fruits = await _fruitService.GetAll(),
                Sizes = await _context.Sizes.ToListAsync(),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, FruitSaladVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please fill all fields");
                vm.Fruits = await _fruitService.GetAll();
                vm.Sizes = await _context.Sizes.ToListAsync();
                return View(vm);
            }


            FruitSalad? fruitSalad = _context.FruitSalads?.Include(fs => fs.SaladImages)?
                .Include(fs => fs.FruitSaladFruits).ThenInclude(fs => fs.Fruit)
                .FirstOrDefault(fs => fs.Id == id);

            

            if (vm.FruitId != null && vm.FruitId.Any())
            {
                fruitSalad.FruitSaladFruits.Clear();
                foreach (var idF in vm.FruitId)
                {
                    fruitSalad.FruitSaladFruits.Add(new FruitSaladFruit
                    {
                        FruitId = idF
                    });
                }
            }
            vm.Images = fruitSalad.SaladImages.ToList();
            if (vm.Files != null && vm.Files.Any())
            {
                string path = Path.Combine(_env.WebRootPath, "assets", "images");

                foreach (var file in vm.Files)
                {
                    file.AddImage(path);

                    SaladImage saladImg = new()
                    {
                        Url = file.AddImage(path),
                    };

                    fruitSalad.SaladImages.Add(saladImg);
                }
            }


            if (vm.DeletedImageIds != null)
            {
                if (vm.DeletedImageIds.Count == fruitSalad.SaladImages.Count)
                {
                    ModelState.AddModelError("", "Images can not be null");
                    vm.Fruits = await _fruitService.GetAll();
                    vm.Sizes = await _context.Sizes.ToListAsync();
                    return View(vm);
                }
                foreach (var idD in vm.DeletedImageIds)
                {
                    SaladImage? saladImage = await _context.SaladImage.FirstOrDefaultAsync(i => i.Id == idD);
                    if (saladImage != null)
                    {
                        string path = Path.Combine(_env.WebRootPath, "assets", "images", saladImage.Url);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        _context.SaladImage.Remove(saladImage);
                    }
                }
            }

            fruitSalad.Name = vm.Name;
            fruitSalad.Price = vm.Price;
            fruitSalad.Rating = vm.Rating;
            fruitSalad.Count = vm.Count;
            //if (vm.SizeId != null && vm.SizeId.Any())
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.FruitSalads.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var imagesFolderPath = Path.Combine(_env.WebRootPath, "assets", "images");

            var imageFileNames = await _context.SaladImage
                .Where(i => i.FruitSaladId == product.Id)
                .Select(i => i.Url)
                .ToListAsync();

            foreach (var imageFileName in imageFileNames)
            {
                var imagePath = Path.Combine(imagesFolderPath, imageFileName);

                await FileUpload.DeleteImage(imagePath);
            }

            _context.FruitSalads.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
