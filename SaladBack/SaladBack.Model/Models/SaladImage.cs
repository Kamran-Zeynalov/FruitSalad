using Microsoft.AspNetCore.Http;
using SaladBack.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Core.Models
{
    public class SaladImage : Base
    {
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? Url { get; set; }
        public int FruitSaladId { get; set; }
        public FruitSalad? FruitSalad { get; set; }
    }
}
