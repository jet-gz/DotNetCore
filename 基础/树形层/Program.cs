using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;

namespace 树形层
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Print(int layer,string name)
            {
                Console.WriteLine($"{new string (' ',layer*4)}{name}");
            }

            new ServiceCollection()
                .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"F:\nosql"))
                .AddTransient<IFileManager, FileManager>()
                .BuildServiceProvider()
                .GetRequiredService<IFileManager>()
                .Show(Print)
                ;
            


            Console.ReadKey();
        }
    }
}
