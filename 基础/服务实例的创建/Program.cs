using Microsoft.Extensions.DependencyInjection;
using System;

namespace 服务实例的创建
{
    class Program
    {
        static void Main(string[] args)
        {
            //var root = new ServiceCollection()
            //    .AddTransient<IFoo, Foo>()
            //    .AddTransient<IBar, Bar>()
            //    .AddTransient<IQux, Qux>()
            //    //没注册Baz
            //    .BuildServiceProvider();
            //root.GetService<IQux>();

            //因为没有注册Baz 所以选择了2个构造函数

            //==============================================


            var root = new ServiceCollection()
                .AddTransient<IFoo, Foo>()
                .AddTransient<IBar, Bar>()
                .AddTransient<IQux, Qux>()
                .AddTransient<IBaz,Baz>()
                .BuildServiceProvider();
            root.GetService<IQux>();


        }
    }



    public interface IFoo{}
    public interface IBar { }
    public interface IBaz { }
    public interface IQux { }

    public class Foo:IFoo { }
    public class Bar:IBar { }
    public class Baz:IBaz { }
    public class Qux:IQux 
    {
        //public Qux(IFoo foo)
        //{
        //    Console.WriteLine("Foo 构造函数");
        //}

        //public Qux(IFoo foo,IBar bar)
        //{
        //    Console.WriteLine("Foo,Bar 构造函数");
        //}
        //public Qux(IFoo foo,IBar bar,IBaz baz)
        //{
        //    Console.WriteLine("Foo,Bar,Baz 构造函数");
        //}


        // 因为下面的2个构造函数，按理来说，2个都可以选择
        // 但是只能有一个对象，所以会报错的， 
        // 也就说，如果要它能被选择，就需要一个构造函数的参数类型集合是所有有效的构造函数的集合的超级
        public Qux(IFoo foo,IBar bar) { }
        public Qux(IBar bar,IBaz baz) { }

    }

}
