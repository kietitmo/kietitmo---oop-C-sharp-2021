using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;
using Backups.Service;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTest
    {
        [Test]
        public void TestCase1_SplitStorage()
        {
            var file1 = new FileOfJob("1.txt", 2);
            var file2 = new FileOfJob("2.txt", 2);

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            IFileSystem fileSystem = new FileSystem();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            int restorePointCount = restorePointList.Count;
            int storageCount = 0;
            foreach (IDirectory directory in fileSystem.Directories)
            {
                foreach (IDirectory directoryChild in directory.Directories)
                {
                    foreach (FileOfJob file in directoryChild.Files)
                    {
                        storageCount++;
                    }
                }
            }

            Assert.AreEqual(restorePointCount, 2);
            Assert.AreEqual(storageCount, 3);
        }

        [Test]
        public void TestCase2_SingleStorage()
        {
            var file1 = new FileOfJob("1.txt", 2);
            var file2 = new FileOfJob("2.txt", 2);

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            IFileSystem fileSystem = new FileSystem();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();

            Assert.AreEqual(fileSystem.Directories.Count, 1);
            int storageFile = 0;
            foreach (IDirectory directory in fileSystem.Directories)
            {
                foreach (IDirectory directoryChild in directory.Directories)
                {
                    foreach (FileOfJob file in directoryChild.Files)
                    {
                        storageFile++;
                    }
                }
            }
            Assert.AreEqual(storageFile, 1);
        }
    }
}
