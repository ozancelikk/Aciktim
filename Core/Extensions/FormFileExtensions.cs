using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            using (var ms = new MemoryStream())
            {
                await formFile.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
