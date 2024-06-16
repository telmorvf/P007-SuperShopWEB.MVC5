using System;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MailKit.Security;
using System.Threading.Tasks;



namespace P007_SuperShopWEB.MVC5.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendEmail(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> SendEmailAsync(string to, string subject, string body)
        {
            //"NameFrom": "Telmo Admin",
            //"Smtp": "smtp.gmail.com",
            //"Port": "587",
            //"From": "telmorf.email@gmail.com",
            //"Password": "tqayzsqshhiuehkf",
            //"EnableSsl":  true

            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from)); // Telmo Admin, telmorf.email@gmail.com
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body,
            };
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            try
            {
                //using (var client = new SmtpClient()){}
                // SSL: 465 (secure socket layer)
                // what is MIME - Multipurpose Internet Mail Extensions
                // client.Connect(smtp, int.Parse(port), false);
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync(from, password);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.ToString()

                };
            }
            finally 
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }

            return new Response
            {
                IsSuccess = true
            };

        }

    }
}
