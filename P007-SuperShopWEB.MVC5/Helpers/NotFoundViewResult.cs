using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace P007_SuperShopWEB.MVC5.Helpers
{
    public class NotFoundViewResult : ViewResult
    {
        public NotFoundViewResult(string viewName)
        {
            ViewName = viewName;
            StatusCode = (int)HttpStatusCode.NotFound;
        }

    }
}
