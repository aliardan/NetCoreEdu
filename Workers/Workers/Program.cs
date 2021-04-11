using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        private static Directory _directory = new Directory(System.IO.Directory.GetCurrentDirectory());

        static async Task Main(string[] args)
        {
            BackgroundWorker bworker = new BackgroundWorker();
            bworker.DoWork += PrintAllFiles;
            bworker.RunWorkerAsync(".txt");

            Console.ReadKey();
        }

        private static void PrintAllFiles(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var files = _directory.GetFiles((string)e.Argument);
                var message = string.Join('\n', files);
                Console.WriteLine(message);
                Console.WriteLine("===========================================");
                Task.Delay(1000).Wait();
            }
        }
    }
}
