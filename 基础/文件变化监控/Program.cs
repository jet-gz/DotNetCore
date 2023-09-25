using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace 文件变化监控
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var fileProvider = new PhysicalFileProvider(@"c:\test"))
            {
                string orginal = null;

                ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), Callback);

                async void Callback()
                {
                    Console.WriteLine("文件被修改了");
                
                }
            }
           
            Console.ReadKey();
        }
    }
}
