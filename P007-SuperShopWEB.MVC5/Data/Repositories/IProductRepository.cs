using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using P007_SuperShopWEB.MVC5.Data.Entities;


namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUser();

        IEnumerable<SelectListItem> GetComboProducts();

    }
}