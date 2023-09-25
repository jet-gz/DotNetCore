using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 承载坏境
{
   
    public interface IMemoryMetricsCollector
    {
        long GetUsage();
    }

    public interface IMetricsDeliverer
    {
        Task DeliverAsync(PerformanceMetrics counter);
    }
    public interface INetworkMetricsCollector
    {
        long GetThroughput();
    }
    public interface IProcessorMetricsCollector
    {
        int GetUsage();
    }
}
