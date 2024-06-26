using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P007_SuperShopWEB.MVC5.Data.Repositories;

namespace P007_SuperShopWEB.MVC5.Controllers.API
{
    //[Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("api/[controller]/getproducts")]
        public IActionResult GetProducts()
        {
            //return Ok(_productRepository.GetAll());
            return Ok(_productRepository.GetAllWithUser());
        }

        [HttpGet]
        [Route("api/[controller]/getproductsToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetProductsToken()
        {
            //return Ok(_productRepository.GetAll());
            return Ok(_productRepository.GetAllWithUser());
        }
    }
}
