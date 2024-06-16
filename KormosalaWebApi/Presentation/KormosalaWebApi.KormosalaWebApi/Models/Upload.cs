using Microsoft.AspNetCore.Http;

namespace KormosalaWebApi.KormosalaWebApi.Models
{
    public class Upload
    {
        public IFormFile File { get; set; }
    }
}
