using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace IServiceProvider注入
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection()
                 .AddSingleton<SingletonService>()
                 .AddScoped<ScopedService>()
                 .BuildServiceProvider()
                ;
            var rootScope = service.GetService<IServiceProvider>();
            using (var scope = service.CreateScope())
            {
                var child = scope.ServiceProvider;
                var singletionService = child.GetRequiredService<SingletonService>();
                var scopeService = child.GetRequiredService<ScopedService>();
                
                Debug.Assert(ReferenceEquals(child, scopeService.RequestService));
                Debug.Assert(ReferenceEquals(rootScope, singletionService.ApplicationService));



                //Debug.Assert(ReferenceEquals(child, child.GetRequiredService<IServiceProvider>()));
                //Debug.Assert(ReferenceEquals(child, scopeService.RequestService));
                //Debug.Assert(ReferenceEquals(rootScope, singletionService.ApplicationService));

            }


        }
    }
    public class SingletonService
    {
        public IServiceProvider ApplicationService { get; }
        public SingletonService(IServiceProvider service)
        {
            ApplicationService = service;
        }
    }
    public class ScopedService
    { 
        public IServiceProvider RequestService { get; }
        public ScopedService(IServiceProvider service)
        {
            RequestService = service;
        }
    
    
    }



}
