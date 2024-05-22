using System;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Models;


namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IConverterHelper
    {
        Product ToProduct(ProductViewModel model, Guid imageId, bool isNew);

        ProductViewModel ToProductViewModel(Product product);
    }
}
