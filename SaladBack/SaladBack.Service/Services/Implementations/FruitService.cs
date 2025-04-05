using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Data.DAL;
using SaladBack.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Service.Services.Implementations
{
    public class FruitService : IFruitService
    {
        private readonly SaladDbContext _context;

        public FruitService(SaladDbContext context)
        {
            _context = context;
        }
   
        public async Task Add(string name)
        {
             if (name == null) throw new ArgumentNullException("name");
             _context.Add(name);
            await _context.SaveChangesAsync();
        }

        public Task Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Fruit> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Fruit>> GetAll()
        {
            return await _context.Fruits.Include(f => f.FruitSaladFruits)
                .ThenInclude(fsf =>fsf.FruitSalad).ToListAsync(); 
        }

        public Task Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
