using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace 长时间运行
{
    class Program
    {
        static void Main(string[] args)
        {
            new HostBuilder()
                .ConfigureServices(svc => svc
                   // .AddSingleton<IHostedService, TaskService>()
                   // 两种注册方式
                    .AddHostedService<TaskService>()
                 )
                .Build()
                .Run();
            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
