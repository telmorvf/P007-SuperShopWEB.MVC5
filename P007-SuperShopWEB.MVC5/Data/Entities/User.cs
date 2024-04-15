using Microsoft.AspNetCore.Identity;

namespace P007_SuperShopWEB.MVC5.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
