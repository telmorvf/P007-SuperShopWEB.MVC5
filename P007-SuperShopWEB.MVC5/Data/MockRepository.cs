using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using P007_SuperShopWEB.MVC5.Data.Entities;


namespace P007_SuperShopWEB.MVC5.Data
{
    public class MockRepository : IRepository
    {
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product {Name = "Um", Price = 11 });
            products.Add(new Product {Name = "Dois", Price = 12 });
            products.Add(new Product {Name = "Tres", Price = 13 });
            products.Add(new Product {Name = "Quatro", Price = 14 });
            products.Add(new Product {Name = "Cinco", Price = 15 });

            return products;
        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

    }
}