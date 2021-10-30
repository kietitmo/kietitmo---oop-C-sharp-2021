using System;
using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab.Actions;
using Backups.Service;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var file1 = new FileOfJob("1.txt");
            var file2 = new FileOfJob("2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var backupJob = new BackupJob("backupJob", fileList, storageTypeAlgorithm);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            Console.WriteLine(backupJob.FileInSystem.Directories.Count);
        }
    }
}
