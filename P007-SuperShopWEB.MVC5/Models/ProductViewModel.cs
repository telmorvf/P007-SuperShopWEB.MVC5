using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name ="Image")]
        public IFormFile ImageFile {get; set;}

    }
}
