using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace DotnetCore预先注册的服务
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder => builder
                .UseStartup<Startup>())
            .Build()
            .Run();
        }
    }

    /**
     *
Singleton      IHostingEnvironment                               HostingEnvironment
Singleton      IHostEnvironment                                  HostingEnvironment
Singleton      HostBuilderContext                                HostBuilderContext
Singleton      IConfiguration                                    ConfigurationRoot
Singleton      IApplicationLifetime                              ApplicationLifetime
Singleton      IHostApplicationLifetime                          ApplicationLifetime
Singleton      IHostLifetime                                     ConsoleLifetime
Singleton      IHost                                             Host
Singleton      IOptions<TOptions>                                OptionsManager<TOptions>
Scoped         IOptionsSnapshot<TOptions>                        OptionsManager<TOptions>
Singleton      IOptionsMonitor<TOptions>                         OptionsMonitor<TOptions>
Transient      IOptionsFactory<TOptions>                         OptionsFactory<TOptions>
Singleton      IOptionsMonitorCache<TOptions>                    OptionsCache<TOptions>
Singleton      ILoggerFactory                                    LoggerFactory
Singleton      ILogger<TCategoryName>                            Logger<T>
Singleton      IConfigureOptions<LoggerFilterOptions>            DefaultLoggerLevelConfigureOptions
Singleton      IConfigureOptions<LoggerFilterOptions>            ConfigureNamedOptions<LoggerFilterOptions>
Singleton      ILoggerProviderConfigurationFactory               LoggerProviderConfigurationFactory
Singleton      ILoggerProviderConfiguration<T>                   LoggerProviderConfiguration<T>
Singleton      IConfigureOptions<LoggerFilterOptions>            LoggerFilterConfigureOptions
Singleton      IOptionsChangeTokenSource<LoggerFilterOptions>    ConfigurationChangeTokenSource<LoggerFilterOptions>
Singleton      LoggingConfiguration                              LoggingConfiguration
Singleton      ILoggerProvider                                   ConsoleLoggerProvider
Singleton      IConfigureOptions<ConsoleLoggerOptions>           LoggerProviderConfigureOptions<ConsoleLoggerOptions,ConsoleLoggerProvider>
Singleton      IOptionsChangeTokenSource<ConsoleLoggerOptions>   LoggerProviderOptionsChangeTokenSource<ConsoleLoggerOptions,ConsoleLoggerProvider>
Singleton      ILoggerProvider                                   DebugLoggerProvider
Singleton      LoggingEventSource                                LoggingEventSource
Singleton      ILoggerProvider                                   EventSourceLoggerProvider
Singleton      IConfigureOptions<LoggerFilterOptions>            EventLogFiltersConfigureOptions
Singleton      IOptionsChangeTokenSource<LoggerFilterOptions>    EventLogFiltersConfigureOptionsChangeSource
Singleton      ILoggerProvider                                   EventLogLoggerProvider
Singleton      IWebHostEnvironment                               HostingEnvironment
Singleton      IHostingEnvironment                               HostingEnvironment
Singleton      IApplicationLifetime                              GenericWebHostApplicationLifetime
Singleton      IConfigureOptions<GenericWebHostServiceOptions>   ConfigureNamedOptions<GenericWebHostServiceOptions>
Singleton      DiagnosticListener                                DiagnosticListener
Singleton      DiagnosticSource                                  DiagnosticListener
Singleton      IHttpContextFactory                               DefaultHttpContextFactory
Scoped         IMiddlewareFactory                                MiddlewareFactory
Singleton      IApplicationBuilderFactory                        ApplicationBuilderFactory
Singleton      IConnectionListenerFactory                        SocketTransportFactory
Transient      IConfigureOptions<KestrelServerOptions>           KestrelServerOptionsSetup
Singleton      IServer                                           KestrelServer
Singleton      IConfigureOptions<KestrelServerOptions>           ConfigureNamedOptions<KestrelServerOptions>
Singleton      IPostConfigureOptions<HostFilteringOptions>       PostConfigureOptions<HostFilteringOptions>
Singleton      IOptionsChangeTokenSource<HostFilteringOptions>   ConfigurationChangeTokenSource<HostFilteringOptions>
Transient      IStartupFilter                                    HostFilteringStartupFilter
Transient      IInlineConstraintResolver                         DefaultInlineConstraintResolver
Transient      ObjectPoolProvider                                DefaultObjectPoolProvider
Singleton      ObjectPool<UriBuildingContext>                    DefaultObjectPool<UriBuildingContext>
Transient      TreeRouteBuilder                                  TreeRouteBuilder
Singleton      RoutingMarkerService                              RoutingMarkerService
Transient      IConfigureOptions<RouteOptions>                   ConfigureRouteOptions
Singleton      EndpointDataSource                                CompositeEndpointDataSource
Singleton      ParameterPolicyFactory                            DefaultParameterPolicyFactory
Singleton      MatcherFactory                                    DfaMatcherFactory
Transient      DfaMatcherBuilder                                 DfaMatcherBuilder
Singleton      DfaGraphWriter                                    DfaGraphWriter
Transient      Lifetime                                          Lifetime
Singleton      EndpointMetadataComparer                          EndpointMetadataComparer
Singleton      LinkGenerator                                     DefaultLinkGenerator
Singleton      IEndpointAddressScheme<String>                    EndpointNameAddressScheme
Singleton      IEndpointAddressScheme<RouteValuesAddress>        RouteValuesAddressScheme
Singleton      LinkParser                                        DefaultLinkParser
Singleton      EndpointSelector                                  DefaultEndpointSelector
Singleton      MatcherPolicy                                     HttpMethodMatcherPolicy
Singleton      MatcherPolicy                                     HostMatcherPolicy
Singleton      TemplateBinderFactory                             DefaultTemplateBinderFactory
Singleton      RoutePatternTransformer                           DefaultRoutePatternTransformer
     * 
     * 
     * 
     * **/



}
