using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace 中间件注入服务
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder => builder
            .ConfigureServices(svcs => svcs
                .AddSingleton<FooBarMiddleware>()
                .AddSingleton<IFoo, Foo>()
                .AddSingleton<IBar, Bar>())
            .Configure(app => app.UseMiddleware<FooBarMiddleware>()))
        .Build()
        .Run();
        }
    }
}
