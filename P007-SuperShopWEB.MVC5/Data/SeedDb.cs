using Microsoft.AspNetCore.Identity;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace P007_SuperShopWEB.MVC5.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("telmorf@yopmail.com");

            if(user == null)
            {
                user = new User
                {
                    FirstName = "Telmo",
                    LastName = "Fernandes",
                    Email = "telmorf@yopmail.com",
                    UserName = "telmorf@yopmail.com",
                    PhoneNumber = "1234567890"

                };
                var result = await _userHelper.AddUserAsync(user,"Pass0rd");
                if(result != IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create the user in the Seeder");
                }
            }

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series 4", user);
                AddProduct("iPad Mini", user);

                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name,User user)
        {
            _context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user
            });
        }



    }
}
