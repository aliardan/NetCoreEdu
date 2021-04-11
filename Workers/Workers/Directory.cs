using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Directory
    {
        private readonly string _path;

        public Directory(string path)
        {
            _path = path;
        }

        private IEnumerable<string> GetFilesOfSubTree(string subPath)
        {
            List<string> result = new List<string>();

            var files = System.IO.Directory.GetFiles(subPath);
            result.AddRange(files);

            var diretories = System.IO.Directory.GetDirectories(subPath);
            foreach (string directory in diretories)
            {
                result.AddRange(GetFilesOfSubTree(directory));
            }

            return result;
        }

        public IEnumerable<string> GetFiles(string format)
        {
            var mainFiles = GetFilesOfSubTree(_path);
            var result = mainFiles.Where(x => System.IO.Path.GetExtension(x) == format);

            return result;
        }
    }
}
