using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
