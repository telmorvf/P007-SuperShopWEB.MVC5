using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
