using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Models;

namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
