using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore生命周期
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(build => build
               .ConfigureServices(s => s
                 .AddSingleton<IFoo, Foo>()
                 .AddSingleton<IBar, Bar>()
                 .AddSingleton<IBaz, Baz>()
                 .AddControllersWithViews())
               .Configure(app => app
               .Use(nex => httpContext =>
               {
                   System.Console.WriteLine($"http===>{httpContext.Request.Path}");
                   return nex(httpContext);
               })
               .UseRouting()
               .UseEndpoints(endpoint => endpoint.MapControllers())))
               .ConfigureLogging(b => b.ClearProviders())
               .Build()
               .Run();

        }
    }

    public interface IFoo { }
    public interface IBar { }
    public interface IBaz { }

    public class Base : IDisposable
    {
        public Base()
        {
            Console.WriteLine($"{this.GetType().Name}创建");
        }
        public void Dispose()
        {
            Console.WriteLine($"{this.GetType().Name} 销毁");
        }
    }

    public class Foo :Base, IFoo { }
    public class Bar :Base, IBar { }
    public class Baz:Base, IBaz{}



}
