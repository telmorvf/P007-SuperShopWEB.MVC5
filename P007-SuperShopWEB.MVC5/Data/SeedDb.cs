﻿using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Helpers;
using System;
using System.Collections.Generic;
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
            //await _context.Database.EnsureCreatedAsync();     // Only create
            await _context.Database.MigrateAsync();             // Create and Migrate

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

            // Country and Cities
            if (!_context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Lisboa" });
                cities.Add(new City { Name = "Porto" });
                cities.Add(new City { Name = "Faro" });

                _context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Portugal"
                });

                await _context.SaveChangesAsync();
            }


            var user = await _userHelper.GetUserByEmailAsync("telmorf@yopmail.com");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Telmo",
                    LastName = "Fernandes",
                    Email = "telmorf@yopmail.com",
                    UserName = "telmorf@yopmail.com",
                    PhoneNumber = "1234567890",
                    Address = "Rua Jau 33",
                    CityId = _context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    City = _context.Countries.FirstOrDefault().Cities.FirstOrDefault()

                };

                var result = await _userHelper.AddUserAsync(user,"Passw0rd");
                if(result != IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create the user in the Seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");

                //Add Token Automático
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);    // Pedido de Token
                await _userHelper.ConfirmEmailAsync(user, token);                           // Confirma Token ao user
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }

            if (!_context.Products.Any())
            {
                AddProduct("Apple-Airpods", user, "00000000-0000-0000-0000-000000000001");
                AddProduct("iPad2-Back", user, "00000000-0000-0000-0000-000000000002");
                AddProduct("iphone-11", user, "00000000-0000-0000-0000-000000000003");
                AddProduct("Magic Socks", user, "00000000-0000-0000-0000-000000000004");

                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name,User user, string guidImage)
        {
            _context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user,
                ImageId = Guid.Parse(guidImage)
            });
        }



    }
}
