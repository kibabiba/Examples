using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryChecker
{
    class Program
    {
        public class DirectoryObj
        {
            public string Name { get; set; }
            public double SizeMb { get; set; }
        }
        private static string _root = "C:\\";
        private static int maxFileSize = 1024 * 1024 * 202; //адин мегабайт!!!
        private static readonly List<DirectoryObj> Directories = new List<DirectoryObj>();

        static void Main()
        {
            ScanDirectory(_root);
            Directories.ForEach(p => Console.WriteLine($"{p.SizeMb} Mb - {p.Name}"));
            Console.WriteLine("-finished-");
            Console.ReadKey();
        }

        private static void ScanDirectory(string root)
        {
            var directoryInfo = new DirectoryInfo(root);

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                try
                {
                    var sizeSum = subdirectory.GetFiles().Select(f => f.Length).Sum();
                if (sizeSum > maxFileSize)
                    Directories.Add(new DirectoryObj
                    {
                        Name = subdirectory.FullName,
                        SizeMb = Math.Round(1D * sizeSum / (1024 * 1024), 2)
                    });

                    ScanDirectory(subdirectory.FullName);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
