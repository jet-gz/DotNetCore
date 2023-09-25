using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace 依赖注入
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 依赖注入
            //var provider = new ServiceCollection()
            //        .AddTransient<IFoo, Foo>()
            //        .AddScoped<IBar>(_=> new Bar())
            //        .AddTransient<IBaz, Baz>()
            //        .AddTransient(typeof(IFooBar<,>), typeof(FooBar<,>))
            //        .BuildServiceProvider()
            //    ;

            //Debug.Assert(provider.GetService<IFoo>() is Foo);
            //Debug.Assert(provider.GetService<IBar>() is Bar);
            //Debug.Assert(provider.GetService<IBaz>() is Baz);
            //var foobar = (FooBar<IFoo, IBar>)provider.GetService<IFooBar<IFoo, IBar>>();
            //Debug.Assert(foobar.Foo is Foo);
            //Debug.Assert(foobar.Bar is Bar); 
            #endregion


            #region 生命周期
            //var service = new ServiceCollection()
            //    //每次都会创建新的对象， 即用即建，用后即弃
            //    .AddTransient<IFoo, Foo>()
            //     //对象被保存在了当前的IServiceProvider容器对象上，
            //     //所以它只能在当前的范围内保证提供的实例是单例的，
            //    .AddScoped<IBar>(_=> new Bar())
            //    //对象被保存了根级容器IserviceProvider里面，所以它能够在在多个同根IserviceProvider
            //    //对象提供真正的单例
            //    .AddSingleton<IBaz, Baz>()
            //    .BuildServiceProvider()
            //    ;
            //var provider1 = service.CreateScope().ServiceProvider;
            //var provider2 = service.CreateScope().ServiceProvider;

            //GetServices<IFoo>(provider1);
            //GetServices<IBar>(provider1);
            //GetServices<IBaz>(provider1);
            //Console.WriteLine("===============");
            //GetServices<IFoo>(provider2);
            //GetServices<IBar>(provider2);
            //GetServices<IBaz>(provider2);

            #endregion

            #region 释放
            //using (var root = new ServiceCollection()
            //    .AddTransient<IFoo,Foo>()
            //    .AddScoped<IBar,Bar>()
            //    .AddSingleton<IBaz,Baz>()
            //    .BuildServiceProvider()
            //    )
            //{
            //    using (var scope = root.CreateScope())
            //    {
            //        var provider = scope.ServiceProvider;
            //        provider.GetService<IFoo>();
            //        provider.GetService<IBar>();
            //        provider.GetService<IBaz>();
            //        Console.WriteLine("子容器disposed");
            //    }
            //    Console.WriteLine("root 容器");
            //}

            /**
             * 子容器销毁的时候，Bar Foo 都会销毁
             * 因为Baz 是全局单例，root 销毁的时候Baz 才开始销毁
             */
            #endregion

            #region 服务注册验证
            /**
             * BuildServiceProvider(true) 就开启了服务的范围检查
             * 针对服务检查的，有个ServiceProviderOptions 的ValidateScopes属性
             * 
             * **/
            #endregion



            Console.ReadKey();

        }

        static void GetServices<T>(IServiceProvider provider)
        {
            provider.GetService<T>();
            provider.GetService<T>();
        }
    }
}
