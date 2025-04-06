using SaladBack.Core;
using SaladBack.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaladBack.ViewModel
{
    public class FruitSaladVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int Count { get; set; }
        public List<IFormFile>? Files { get; set; }
        public List<SaladImage>? Images { get; set; }
        public List<int>? ImageIds { get; set; }
        [NotMapped]
        public ICollection<int>? DeletedImageIds { get; set; }
        public List<Fruit>? Fruits { get; set; }
        public List<Size>? Sizes { get; set; }
        public List<int>? FruitId { get; set; }
        public int? SizeId { get; set; }
    }
}
