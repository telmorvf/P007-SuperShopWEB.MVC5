using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;
using System.Linq;

namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUser()
        {
            return _context.Products.Include(p => p.User);
        }
    }
}
