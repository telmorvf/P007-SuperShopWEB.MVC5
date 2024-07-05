using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Helpers;
using System.Threading.Tasks;

namespace SuperShop2022.Controllers.API
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserHelper _userHelper;

        public AccountController(SignInManager<User> signInManager,
            IUserHelper userHelper)
        {
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        [HttpGet]
        [Route("[controller]/Login1")]
        public async Task<IActionResult> Login1(string email, string password)
        {
            if (password == null || email == null)
            {
                return Ok("false");
            }

            var user = await _userHelper.GetUserByEmailAsync(email);

            if (user == null)
            {
                return Ok("false");
            }

            var response = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (response.Succeeded)
            {
                return Ok(user.FullName);
            }

            return Ok("false");
        }

    }
}