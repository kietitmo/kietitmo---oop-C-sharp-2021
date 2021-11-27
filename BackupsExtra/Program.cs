using System;
using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab.Actions;
using Backups.Service;
using BackupsExtra.InforOfJob;
namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            foreach (DirectoryOfBackup directory in fileSystem.Directories)
            {
                Console.WriteLine(directory.Path);
                foreach (FileOfJob file in directory.Files)
                {
                    Console.WriteLine(file.Name + "\t" + file.Path);
                }
            }

            Console.WriteLine("==========================================");
            foreach (RestorePoint rp in restorePointList)
            {
                foreach (FileOfJob file in rp.JobObjectsList)
                {
                    Console.WriteLine(file.Name);
                }
            }

            Console.WriteLine("==========================================");
            fileList.Remove(file2);
            backupJob.RunBackupJob();

            foreach (DirectoryOfBackup directory in fileSystem.Directories)
            {
                Console.WriteLine(directory.Path);
                foreach (FileOfJob file in directory.Files)
                {
                    Console.WriteLine(file.Name + "\t" + file.Path);
                }
            }

            Console.WriteLine("=========================xx=================");
            foreach (RestorePoint rp in restorePointList)
            {
                foreach (ArchiveFile file in rp.StorageRestorePoint.ArchiveFileList)
                {
                    Console.WriteLine(file.Name);
                }
            }

            var infor = new BackupJobAndRestorePointManager(restorePointList, backupJob);
            infor.Save();

            BackupJobAndRestorePointManager infor2;
            infor2 = infor.Load();
            Console.WriteLine(infor2.RestorePointList.Count);
        }
    }
}
