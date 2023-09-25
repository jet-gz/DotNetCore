using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace 中间件注入服务
{
    public class FooBarMiddleware : IMiddleware
    {
        public FooBarMiddleware(IFoo foo,IBar bar)
        {
            Debug.Assert(foo!=null);
            Debug.Assert(bar != null);
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Debug.Assert(next!=null);
            return Task.CompletedTask;
        }
    }
}
