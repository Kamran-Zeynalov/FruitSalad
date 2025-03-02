using Microsoft.EntityFrameworkCore;
using SaladBack.Core;
using SaladBack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Data.DAL
{
    public class SaladDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Nut> Nuts  { get; set; }
        public DbSet<FruitSalad> FruitSalads { get; set; }
        public DbSet<FruitSaladFruit> FruitSaladFruits { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
