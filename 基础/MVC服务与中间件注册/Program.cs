using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVC服务与中间件注册
{
    class Program
    {
        /**
         * 整个mvc框架建立在了 EndpointRoutingMiddleware 中间件和EndpointMiddleware中间件
         * 构建的路由上，
         * 
         * **/


        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(build =>
                    build.ConfigureServices(service =>
                        service.AddRouting()
                                .AddControllersWithViews()
                    )
                    .Configure(app =>
                        app.UseRouting()
                           .UseEndpoints(x => x.MapControllers())
                    )
                )
                .Build()
                .Run();

        }
    }
    public class Hello2Controller
    {
        [HttpGet("hello2")]
        public string SayHello() => "Hello World !!!";
    
    }
    public class HelloController:Controller
    {
        [HttpGet("/hello/{name}")]
        public IActionResult SayHello(string name)
        {
            ViewBag.Name = name;
            return View();
        }

    }




}
