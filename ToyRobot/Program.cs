using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddOptions<AppSettings>().Configure<IConfiguration>((settings, configuration) => { configuration.GetSection(nameof(AppSettings)).Bind(settings); });
                    services.AddTransient<ToyRobotFunction>();
                })
                .Build();

            var toy = host.Services.GetRequiredService<ToyRobotFunction>();

            toy.Run();

            await host.RunAsync();
        }
    }
}
