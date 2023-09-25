using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mvc配置初始化
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Console.WriteLine($"--->{environment.ApplicationName}--{environment.EnvironmentName}");
            Console.WriteLine($"--->{environment.ContentRootPath}--{environment.WebRootPath}");
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<FoobarOptions>(_configuration);
        }
            

        public void Configure(IApplicationBuilder app, IOptions<FoobarOptions> optionsAccessor)
        {
            var options = optionsAccessor.Value;
            var json = JsonConvert.SerializeObject(options, Formatting.Indented);
            app.Run(async context =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync($"<pre>{json}</pre>");
                
            });
        }
    }
}
