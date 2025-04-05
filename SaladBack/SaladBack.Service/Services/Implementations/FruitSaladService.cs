using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Core.Models;
using SaladBack.Data.DAL;
using SaladBack.Service.Extentions;
using SaladBack.Service.Services.Interfaces;
using System.Collections.Frozen;

namespace SaladBack.Service.Services.Implementations
{
    public class FruitSaladService : IFruitSaladService
    {
        private readonly SaladDbContext _context;

        public FruitSaladService(SaladDbContext context)
        {
            _context = context;
        }

        public async Task Create(int fruitId, FruitSalad fruitSalad)
        {
            if (fruitSalad is null)
            {
               throw new ArgumentNullException("fruitSalad");
            }
            if (fruitSalad.Name.Any())
            {
                throw new AbandonedMutexException("Name");
            }
            List<Fruit> fruits = _context.Fruits.ToList();
            if (fruits.Count == 0)
            {
                throw new ArgumentNullException("Fruits");
            }
            foreach (var fruit in fruits)
            {
                if(fruit.Id == fruitId)
                {
                    fruitSalad.FruitSaladFruits.Add(new FruitSaladFruit
                    {
                        FruitId = fruit.Id,
                        FruitSaladId = fruitSalad.Id
                    });
                }
            }

            if (fruitSalad.SaladImages is null)
            {
                throw new ArgumentNullException("SaladImages");
            }
            else {
                foreach (var image in fruitSalad.SaladImages)
                {
                    if (image is null)
                    {
                        throw new ArgumentNullException("SaladImage");
                    }
                }
            }

        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FruitSalad> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("id");
            FruitSalad? fruitSalad = await _context.FruitSalads
                                                        .Include(fs => fs.FruitSaladFruits).ThenInclude(fsf => fsf.Fruit)
                                                        .Include(fs => fs.Sizes)
                                                        .Include(fs => fs.SaladImages)
                                                        .FirstOrDefaultAsync(fs => fs.Id == id);
            return fruitSalad;
        }

        public async Task<List<FruitSalad>> GetAll()
        {
            return await _context.FruitSalads
                .Include(fs => fs.FruitSaladFruits).ThenInclude(fs =>fs.Fruit)
                .Include(fs =>fs.SaladImages)
                .ToListAsync();
        }

        public Task Update(int id, FruitSalad fruitSalad)
        {
            throw new NotImplementedException();
        }
    }
}
