using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P007_SuperShopWEB.MVC5.Data.Repositories;
using System.Threading.Tasks;

namespace P007_SuperShopWEB.MVC5.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(
            IOrderRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name);
            return View(model);
        }




    }
}
