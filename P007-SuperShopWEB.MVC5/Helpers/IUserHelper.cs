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

        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
        
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);

        // MVC31 TokenAPI
        Task<SignInResult> ValidatePasswordAsync(User user, string password);


        // MVC33 - Server Envio de Email
        Task<string> GenerateEmailConfirmationTokenAsync(User user);        //gerar o Token
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);    // enviar o email
        Task<User> GetUserByIdAsync(string userId);     // Envia o Id do User e Devolve o User

        // MVC34 Recovery and Reset user Password
        Task<string> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);
    }
}
