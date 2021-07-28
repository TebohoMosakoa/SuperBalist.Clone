using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile($"ocelot.development.json", true, true);
                 })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 })
             .ConfigureLogging((hostingContext, loggingbuilder) =>
             {
                 loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 loggingbuilder.AddConsole();
                 loggingbuilder.AddDebug();
             });
    }
}
