using Microsoft.AspNetCore.Http;
using SaladBack.Core.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaladBack.Core.Models
{
    public class FruitSalad:Base
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public List<FruitSaladFruit>? FruitSaladFruits { get; set; }
        public List<SaladImage>? SaladImages { get; set; }
        public List<Size>? Sizes { get; set; }
        public int Count { get; set; }



        [NotMapped]
        public List<IFormFile>? ImageFiles { get; set; }
        [NotMapped]
        public int SizeId { get; set; }
        [NotMapped]
        public int FruitId { get; set; }
    }
}
