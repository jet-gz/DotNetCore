using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 中间件
{
    public class StringContentMiddleware:IMiddleware 
    {
        private readonly string _content;
        public StringContentMiddleware()
        {

        }
        public StringContentMiddleware(string content)
        {
            _content = content;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        =>context.Response.WriteAsync(_content);
        

    }
}
