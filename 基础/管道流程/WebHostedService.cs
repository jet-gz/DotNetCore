using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace 管道流程
{
    public class WebHostedService:IHostedService
    {
        private readonly IServer _server;
        private readonly RequestDelegate _handler;
        public WebHostedService(IServer server, RequestDelegate handler)
        {
            _server = server;
            _handler = handler;
        }
        public Task StartAsync(CancellationToken cancellationToken) =>
            _server.StartAsync(_handler);
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
