using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RateLimitApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            //IIpPolicyStore ipPolicy = host.Services.GetRequiredService<IIpPolicyStore>();
            //ipPolicy.SeedAsync().Wait();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}