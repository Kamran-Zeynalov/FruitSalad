using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Core.Models;
using SaladBack.Data.DAL;
using SaladBack.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Service.Services.Implementations
{
    public class FruitSaladService : IFruitSaladService
    {
        private readonly SaladDbContext _context;

        public FruitSaladService(SaladDbContext context) => _context = context;



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
                                    .Include(fs => fs.FruitSaladFruits).ThenInclude(fsf => fsf.Fruit)
                                    .Include(fs => fs.SaladImages)
                                    .ToListAsync();
        }
    }
}
