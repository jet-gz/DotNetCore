using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace 文件内容读取
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var service =  new ServiceCollection()
            //    .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"C:\test"))
            //    .AddTransient<IFileManager, FileManager>()
            //    .BuildServiceProvider();

            //var content = await service.GetRequiredService<IFileManager>().ReadAllTextAsync("data.txt");
            //Console.WriteLine(content);

            //Debug.Assert(content== await File.ReadAllTextAsync(@"c:\test\data.txt"));

            var assembly = Assembly.GetEntryAssembly();

            var service = new ServiceCollection()
                .AddSingleton<IFileProvider>(new EmbeddedFileProvider(assembly))
                .AddTransient<IFileManager, FileManager>()
                .BuildServiceProvider();

            var content = await service.GetRequiredService<IFileManager>().ReadAllTextAsync("data.txt");
            Console.WriteLine(content);

           


        }
    }
}
