using P007_SuperShopWEB.MVC5.Data.Entities;
using System.Linq;

namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUser();
    }
}