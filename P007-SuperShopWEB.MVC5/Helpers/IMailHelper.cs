using Azure;
using P007_SuperShopWEB.MVC5.Data.Entities;
using System.Threading.Tasks;

namespace P007_SuperShopWEB.MVC5.Helpers
{
    public interface IMailHelper
    {
        //void SendEmail(string email, string subject, string body);

        Response SendEmail(string to, string subject, string body);

        Task<Response> SendEmailAsync(string to, string subject, string body);
    }
}
