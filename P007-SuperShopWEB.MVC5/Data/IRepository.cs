using System.Collections.Generic;
using System.Threading.Tasks;
using P007_SuperShopWEB.MVC5.Data.Entities;


namespace P007_SuperShopWEB.MVC5.Data
{
    public interface IRepository
    {
        void AddProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        bool ProductExists(int id);
        void RemoveProduct(Product product);
        Task<bool> SaveAllAsync();
        void UpdateProduct(Product product);
    }
}