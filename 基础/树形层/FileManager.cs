using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace 树形层
{
    public interface IFileManager
    {
        void Show(Action<int, string> render);
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

    }
}
