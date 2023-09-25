using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 管道流程
{
    public delegate Task RequestDelegate(HttpContext httpContext);
}
