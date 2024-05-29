using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace P007_SuperShopWEB.MVC5.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
