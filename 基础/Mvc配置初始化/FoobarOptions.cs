using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc配置初始化
{
    public class FoobarOptions
    {
        public Foobar Foobar { get; set; }
        public string Baz { get; set; }
    }

    public class Foobar
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
}
