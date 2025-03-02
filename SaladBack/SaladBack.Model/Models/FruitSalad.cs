using SaladBack.Core.BaseEntity;

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
    }
}
