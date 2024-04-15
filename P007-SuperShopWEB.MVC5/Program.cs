using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P007_SuperShopWEB.MVC5.Data;

namespace P007_SuperShopWEB.MVC5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            // Passa para RunSeeding

            // constroi o Host mas n�o fa�as o run ainda, guarda em var host
            var host = CreateHostBuilder(args).Build();

            // Depois quero usalo para correr o Seeding naquele host
            // (se n�o existir BD ou dados na tabela corre o Seeding)

            RunSeeding(host);
            // S� depois corre o host j� com tudo montado
            host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            // usa design pattern Factory
            // CTRL . using Microsoft.Extensions.DependencyInjection
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
