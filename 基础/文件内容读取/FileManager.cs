using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 文件内容读取
{
    public interface IFileManager
    {
        void Show(Action<int, string> render);
        Task<string> ReadAllTextAsync(string path);
    }


    public class FileManager:IFileManager
    {
        private readonly IFileProvider _fileProvider;

        public FileManager(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public void Show(Action<int, string> render)
        {
            int indent = -1;
            Render("");
        
            void Render(string subPath)
            {
                indent++;
                foreach (var item in _fileProvider.GetDirectoryContents(subPath))
                {
                    render(indent, item.Name);
                    if (item.IsDirectory)
                    {
                        Render($@"{subPath}\{item.Name}".TrimStart('\\'));
                    }
                }
            
            }
        
        }


        public async Task<string> ReadAllTextAsync(string path)
        {
            byte[] buffer;
            using (var stream = _fileProvider.GetFileInfo(path).CreateReadStream())
            {
                buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer,0,buffer.Length);
            }
            return Encoding.Default.GetString(buffer);
        
        }



    }
}
