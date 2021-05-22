using System;

namespace FileRepository
{
    public class File
    {
        public File(string content, string fileName, Guid id)
        {
            Content = content;
            FileName = fileName;
            Id = id;
        }

        public Guid Id {get;}
        public string FileName {get; }
        public string Content { get;}
    }
}
