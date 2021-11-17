using System;
using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;
using Backups.Service;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var file1 = new FileOfJob("1.txt", 2);
            var file2 = new FileOfJob("2.txt", 2);

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            IFileSystem fileSystem = new FileSystem();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            foreach (IDirectory directory in fileSystem.Directories)
            {
                foreach (IDirectory directoryChild in directory.ChildrenDirectories)
                {
                    Console.WriteLine(directoryChild.Name);
                    foreach (FileOfJob file in directoryChild.Files)
                    {
                        Console.WriteLine(file.Name + " ");
                    }
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

            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");

            foreach (IDirectory directory in fileSystem.Directories)
            {
                foreach (IDirectory directoryChild in directory.ChildrenDirectories)
                {
                    foreach (FileOfJob file in directoryChild.Files)
                    {
                        Console.WriteLine(file.Name + " ");
                    }
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
        }
    }
}
