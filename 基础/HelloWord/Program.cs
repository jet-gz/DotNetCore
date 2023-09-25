using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder() 
                .ConfigureWebHost(x =>
                    x.UseKestrel()
                    .Configure(x =>
                    x.Run(context => context.Response.WriteAsync("Hello Word!!"))
                    )
                ).Build()
                .Run();
        }
    }
}
