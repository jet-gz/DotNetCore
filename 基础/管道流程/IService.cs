using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 管道流程
{
    public interface IServer
    {
        Task StartAsync(RequestDelegate handler);

    }
}
