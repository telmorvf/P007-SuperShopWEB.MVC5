using System.ComponentModel.DataAnnotations;

namespace P007_SuperShopWEB.MVC5.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
