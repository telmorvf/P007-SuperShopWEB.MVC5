using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Models;

namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IConverterHelper
    {
        Product ToProduct(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(Product product);
    }
}
