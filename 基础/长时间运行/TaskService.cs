using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 长时间运行
{
    public class TaskService : IHostedService
    {
        IDisposable _scheduler;


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
            static void Callback(object obj)
            {
                Console.WriteLine($"{DateTimeOffset.Now}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler?.Dispose();
            Console.WriteLine("停止了");
            return Task.CompletedTask;
        }
    }
}
