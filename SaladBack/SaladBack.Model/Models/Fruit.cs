using Microsoft.AspNetCore.Http;
using SaladBack.Core.BaseEntity;
using SaladBack.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaladBack.Core
{
    public class Fruit:Base
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string? ImageUrl { get; set; }

        public List<FruitSaladFruit>? FruitSaladFruits { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="Choose a image fileeee")]
        public IFormFile? Image {  get; set; }
    }
}
