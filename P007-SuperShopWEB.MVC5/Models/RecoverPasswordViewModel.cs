using System.ComponentModel.DataAnnotations;

namespace P007_SuperShopWEB.MVC5.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
