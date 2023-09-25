using System;
using System.Collections.Generic;
using System.Text;

namespace 承载坏境
{
    public class FakeMetricsCollector : IProcessorMetricsCollector, IMemoryMetricsCollector, INetworkMetricsCollector
    {
        long INetworkMetricsCollector.GetThroughput() => PerformanceMetrics.Create().Network;
        int IProcessorMetricsCollector.GetUsage() => PerformanceMetrics.Create().Processor;
        long IMemoryMetricsCollector.GetUsage() => PerformanceMetrics.Create().Memory;
    }
}
