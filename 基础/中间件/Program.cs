using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

using System;

namespace 中间件
{
    class Program
    {
        static RequestDelegate Middlewarel1(RequestDelegate next) =>
        async context => {
           await context.Response.WriteAsync("Hello");
           await next(context);
        };
        static RequestDelegate Middlewarel2(RequestDelegate next)=>
        async context => {
           await context.Response.WriteAsync(" Word");
        await next(context);
        };


        /**
         * 对于前2种中间件，他们的不同之处体现在定义和注册方式上，还体现在自身生命周期的差异
         * 强类型方式定义的中间件可以注册为任意生命周期模式的服务
         * 按照约定定义的中间件则总是一个singleton服务
         * ***/

        static void Main(string[] args)
        {
            #region 方式一
            //Host.CreateDefaultBuilder().ConfigureWebHostDefaults(build => build
            //     .Configure(app => app
            //     .Use(Middlewarel1)
            //     .Use(Middlewarel2)
            //     ))
            //     .Build()
            //     .Run();

            #endregion

            #region 接口的方式
            Host.CreateDefaultBuilder()
                .ConfigureServices(svcs => svcs
                .AddSingleton(new StringContentMiddleware("接口方式的中间件")))
                .ConfigureWebHostDefaults(builder => builder
                .Configure(app => app
                .UseMiddleware<StringContentMiddleware>()))
            .Build()
            .Run();

            #endregion

            #region 约定方式
           
            //Host.CreateDefaultBuilder()
            //     .ConfigureWebHostDefaults(builder => builder
            //     .Configure(app => app
            //     .UseMiddleware<StringContentMiddleware2>("Hello" )
            //     .UseMiddleware<StringContentMiddleware2>(" Word",false)))
            // .Build()
            // .Run();
            #endregion

        }
    }
}
