using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 管道流程
{
    public interface IApplicationBuilder
    {
        RequestDelegate Build();

        IApplicationBuilder Use(Func<RequestDelegate,RequestDelegate> middleware);
    }

    public class ApplicationBuilder : IApplicationBuilder
    {

        private readonly IList<Func<RequestDelegate, RequestDelegate>> _middlewares =
            new List<Func<RequestDelegate, RequestDelegate>>();


        public RequestDelegate Build()
        {
            _middlewares.Reverse();
            return httpContext =>
            {
                RequestDelegate next = _ => { _.Response.StatusCode = 404; return Task.CompletedTask; };
                foreach (var middleware in _middlewares)
                {
                    next = middleware(next);
                }
                return next(httpContext);
            };
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }

}
