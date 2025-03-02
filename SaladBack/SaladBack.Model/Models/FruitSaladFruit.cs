using SaladBack.Core.BaseEntity;


namespace SaladBack.Core.Models
{
    public class FruitSaladFruit:Base
    {
        public int FruitId { get; set; }
        public int FruitSaladId { get; set; }
        public Fruit? Fruit { get; set; }
        public FruitSalad? FruitSalad { get; set; }
    }
}
