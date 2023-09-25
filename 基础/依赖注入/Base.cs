using System;
using System.Collections.Generic;
using System.Text;

namespace 依赖注入
{
    public class Base : IDisposable
    {
        public Base() => Console.WriteLine($"这是{GetType().Name} 创建");
        public void Dispose()
        {
            Console.WriteLine( $"这是{GetType().Name}销毁");
        }
    }

    public class Foo : Base, IFoo, IDisposable {  }
    public class Bar : Base, IBar, IDisposable { }
    public class Baz : Base, IBaz, IDisposable { }

    public class FooBar<T1, T2>:IFooBar<T1,T2>
    { 
        public IFoo Foo { get; }
        public IBar Bar { get; }

        public FooBar(IFoo foo,IBar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }




}
