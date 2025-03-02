using SaladBack.Core.BaseEntity;
using SaladBack.Core.Models;

namespace SaladBack.Core
{
    public class Fruit:Base
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<FruitSaladFruit>? FruitSaladFruits { get; set; }
        public List<FruitImage>? FruitImages  { get; set; }
    }
}
