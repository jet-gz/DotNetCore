using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 承载坏境
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        private readonly TransportType _transport;
        private readonly Endpoint _deliverTo;
        private readonly ILogger _logger;
        private readonly Action<ILogger, DateTimeOffset, PerformanceMetrics, Endpoint, TransportType, Exception> _logForyDelivery;

        public FakeMetricsDeliverer(IOptions<MetricsCollectionOptions> optionsAccessor
            ,ILogger<FakeMetricsCollector> logger)
        {
            var options = optionsAccessor.Value;
            _transport = options.Transport;
            _deliverTo = options.DeliverTo;
            _logger = logger;
            _logForyDelivery =
                LoggerMessage.Define<DateTimeOffset, PerformanceMetrics, Endpoint, TransportType>
                (LogLevel.Information, 0, "[{0}]Deliver performance counter {1}to{2}via {3}");
        }

        public Task DeliverAsync(PerformanceMetrics counter)
        {
            _logForyDelivery(_logger,DateTimeOffset.Now,counter,_deliverTo,_transport,null);
           // Console.WriteLine($"[{DateTimeOffset.Now}]Deliver performance counter {counter} to { _deliverTo} via { _transport}");
            return Task.CompletedTask;
        }
    }
}
