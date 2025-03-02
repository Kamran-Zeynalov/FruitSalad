using SaladBack.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Core.Models
{
    public class SaladImage : Base
    {
        public string? Url { get; set; }
        public int FruitSaladId { get; set; }
        public FruitSalad? FruitSalad { get; set; }
    }
}
