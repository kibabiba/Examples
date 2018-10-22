using System;
using System.IO;

namespace SvnBackuper
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        const string RepositoriesPath = @"C:\Repositories";
        const string BackupPath = @"C:\Backup\SVN\clubcardservice";

        static void Main()
        {
            RestoreRepositories();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        // ReSharper disable UnusedMember.Local
        private static void BackupRepositories()
        {
            var repositoriesDirecrotyInfo = new DirectoryInfo(RepositoriesPath);
            foreach (var repository in repositoriesDirecrotyInfo.GetDirectories())
            {
                Console.WriteLine(repository.Name);

                var dump = $@"/c svnadmin dump {repository.FullName} > {BackupPath}\{repository.Name}.bak";
                Console.WriteLine(dump);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = dump
                });
            }
        }

        private static void RestoreRepositories()
        {
            var repositoriesDirecrotyInfo = new DirectoryInfo(BackupPath);
            foreach (var backupFile in repositoriesDirecrotyInfo.GetFiles())
            {
                var repository = backupFile.Name.Split('.')[0];
                Console.WriteLine(backupFile);

                var create = $@"/c svnadmin create {RepositoriesPath}\{repository}";
                var load = $@"/c svnadmin load {RepositoriesPath}\{repository} < {BackupPath}\{backupFile}";
                Console.WriteLine(create);
                Console.WriteLine(load);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = create
                });

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = @"C:\windows\system32\cmd.exe",
                    Arguments = load
                });
            }
        }
    }
}
