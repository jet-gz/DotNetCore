using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Mvc配置初始化;
using System;

namespace Mvc初始化
{
    class Program
    {
        static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("ASPNETCORE_FOOBAR:FOO", "Foo");
            //Environment.SetEnvironmentVariable("ASPNETCORE_FOOBAR:BAR", "Bar");
            //Environment.SetEnvironmentVariable("ASPNETCORE_Baz", "Baz");

            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder => builder
            .UseSetting("Foobar:Foo", "Foo1")
            .UseSetting("Foobar:Bar", "Bar1")
            .UseSetting("Baz", "Baz1")
            .UseSetting("ApplicatonName","Myjet")
            //命令运行
            .UseSetting("urls", "http://0.0.0.0:8888;http://0.0.0.0:9999")
            .UseStartup<Startup>())
                .Build()
                .Run();
           // Console.WriteLine("Hello World!");
        }
    }
}
