using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using P007_SuperShopWEB.MVC5.Models;


namespace P007_SuperShopWEB.MVC5.Controllers
{
    public class ErrorsController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("error/404")]
        public IActionResult error404()
        {
            return View();
        }
    }
}
