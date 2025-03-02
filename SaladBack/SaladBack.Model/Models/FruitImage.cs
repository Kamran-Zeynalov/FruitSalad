using SaladBack.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Core.Models
{
    public class FruitImage:Base
    {
        public string? Url { get; set; }
        public int FruitId { get; set; }
        public Fruit? Fruit { get; set; }
    }
}
