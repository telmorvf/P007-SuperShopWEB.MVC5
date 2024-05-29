using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        // propriedade responsável pela tabela
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailTemp { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        // Instalar o NuGet: => using Microsoft.EntityFrameworkCore
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
    }
}
