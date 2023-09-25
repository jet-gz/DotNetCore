using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace 中间件
{

    /// <summary>
    /// 约定方式定义的中间件
    /// 一个有效的 公共构造函数，该构造函数必须包含一个RequestDelegate参数，参数的位置不能约束
    /// 针对请求处理实现在返回类I型那个为Task的invokeasync 方法，它的第一个参数为请求上下文Context
    ///  对于后续的参数约束没有限制，但是这些参数必须在相应的服务注册必须存在
    /// </summary>
    public class StringContentMiddleware2 
    {
        private readonly RequestDelegate _next;
        private readonly string _contents;
        /// <summary>
        /// 
        /// </summary>
        private readonly bool _forewardToNext;


        public StringContentMiddleware2(RequestDelegate next, string contents, bool forewardToNext = true)
        {
            _contents = contents;
            _next = next;
            _forewardToNext = forewardToNext;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync(_contents);
            if (_forewardToNext)
            {
                await _next(context);
            }
        }


    }
}
