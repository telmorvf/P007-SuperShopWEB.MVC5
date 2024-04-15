using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }
    }
}
