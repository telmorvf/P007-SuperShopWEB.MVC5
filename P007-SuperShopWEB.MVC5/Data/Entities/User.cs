using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P007_SuperShopWEB.MVC5.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        public string Address { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
