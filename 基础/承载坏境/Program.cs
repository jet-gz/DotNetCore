using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace 承载坏境
{
    class Program
    {

        /*
         * cmd 执行 dotnet run environment=development/ environment=staging/environment=production
         * 
         * **/

        static void Main(string[] args)
        {
            var collector = new FakeMetricsCollector();
            new HostBuilder()
                 .ConfigureHostConfiguration(builder => builder.AddCommandLine(args))
                .ConfigureAppConfiguration((context, builder) => builder
                    .AddJsonFile(path: "appsettings.json", optional: false)
                    .AddJsonFile(
                        path: $"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                        optional: true))
                .ConfigureServices((context, svcs) => svcs
                    .AddSingleton<IProcessorMetricsCollector>(collector)
                    .AddSingleton<IMemoryMetricsCollector>(collector)
                    .AddSingleton<INetworkMetricsCollector>(collector)
                    .AddSingleton<IMetricsDeliverer, FakeMetricsDeliverer>()
                    .AddSingleton<IHostedService, TaskService>()

                    .AddOptions()
                    .Configure<MetricsCollectionOptions>(context.Configuration.GetSection("MetricsCollection")))
                .ConfigureLogging((c,b)=>b
                   .AddConfiguration(c.Configuration.GetSection("Logging"))
                   .AddConsole()
                   )
                .Build()
                .Run();




            Console.WriteLine("Hello World!");
        }
    }
}
