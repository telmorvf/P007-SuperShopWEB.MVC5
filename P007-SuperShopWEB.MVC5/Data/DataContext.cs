﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        // propriedade responsável pela tabela
        public DbSet<Product> Products { get; set; }

        // Instalar o NuGet: => using Microsoft.EntityFrameworkCore
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
    }
}
