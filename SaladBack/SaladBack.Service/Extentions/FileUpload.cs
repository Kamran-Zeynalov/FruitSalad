using Microsoft.AspNetCore.Http;
using SaladBack.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladBack.Service.Extentions
{
    public static class FileUpload
    {
        public static string AddImage(this IFormFile image,string path)
        {
            Random r = new();
            int rInt = r.Next(0, 1000);
            string realImage = string.Concat(rInt, image.FileName);
            var endPath = Path.Combine(path,realImage);

            using (FileStream fs = new(endPath, FileMode.Create))
            {
                image.CopyTo(fs);
            }
            return realImage;
        }

        public static async Task DeleteImage(string path)
        {
            if(File.Exists(path)) File.Delete(path);
        }

    }
}
