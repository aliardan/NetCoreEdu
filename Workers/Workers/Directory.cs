using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Directory
    {
        private readonly string _path;
        private readonly ConcurrentDictionary<CacheKey, CacheRecord> _cache;

        public Directory(string path)
        {
            _path = path;
            _cache = new ConcurrentDictionary<CacheKey, CacheRecord>();
        }

        private IEnumerable<string> GetFilesOfSubTree(string subPath, string fileFormat)
        {
            CacheKey key = new CacheKey{SubDirectory = subPath, FileFormat = fileFormat};

            if (_cache.ContainsKey(key) && (DateTime.Now - _cache[key].TimeStamp) < TimeSpan.FromMinutes(5))
            {
                return _cache[key].Files;
            }
            else
            {
                List<string> result = new List<string>();

                var files = System.IO.Directory.GetFiles(subPath, "*"+fileFormat);
                result.AddRange(files);

                var directories = System.IO.Directory.GetDirectories(subPath);
                foreach (string directory in directories)
                {
                    result.AddRange(GetFilesOfSubTree(directory, fileFormat));
                }

                _cache[key] = new CacheRecord(){ Files = result, TimeStamp = DateTime.Now};

                return result;
            }
        }

        public IEnumerable<string> GetFiles(string format)
        {
            var result = GetFilesOfSubTree(_path, format);
            return result;
        }

        private struct CacheRecord
        {
            public DateTime TimeStamp;
            public IEnumerable<string> Files;
        }

        private struct CacheKey
        {
            /// <summary>
            /// Absolute path
            /// </summary>
            public string SubDirectory;
            public string FileFormat;
        }
    }
}
