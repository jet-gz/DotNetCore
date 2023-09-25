using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace 宿主创建
{
    class Program
    {
        static void Main(string[] args)
        {
            new HostBuilder()
                .ConfigureHostConfiguration(b => b.AddCommandLine(args))
                .ConfigureServices(s => s.AddHostedService<FakeHostedService>())
                .Build()
                .Run();

            Console.ReadKey();
        }
    }
}
