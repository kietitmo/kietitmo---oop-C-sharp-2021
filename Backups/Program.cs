using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Backups.Enumeration;
using Backups.Service;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var file1 = new FileInfo("1.txt");
            var file2 = new FileInfo("2.txt");
            var file3 = new FileInfo("3.txt");

            var f1 = new FileOfJob(file1.Name, file1.Length, file1.DirectoryName, file1.CreationTime);
            var f2 = new FileOfJob(file2.Name, file2.Length, file2.DirectoryName, file2.CreationTime);
            var f3 = new FileOfJob(file3.Name, file3.Length, file3.DirectoryName, file3.CreationTime);

            var fileList = new List<FileOfJob>() { f1, f2, f3 };
            var backupJob = new BackupJobLocal("backupJob", fileList, StorageType.SingleStorage);
            backupJob.RunBackupJob();
        }
    }
}
