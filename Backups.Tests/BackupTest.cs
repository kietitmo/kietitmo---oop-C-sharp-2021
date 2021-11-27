using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
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
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var directories = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\", fileList, storageTypeAlgorithm, directories, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            int restorePointCount = restorePointList.Count;
            int storageCount = 0;

            foreach (RestorePoint rp in restorePointList)
            {
                foreach (FileOfJob file in rp.StorageRestorePoint.ArchiveFileList)
                {
                    storageCount++;
                }
            }

            Assert.AreEqual(restorePointCount, 2);
            Assert.AreEqual(storageCount, 3);
        }

        [Test]
        public void TestCase2_SingleStorage()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var directories = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\", fileList, storageTypeAlgorithm, directories, restorePointList);

            backupJob.RunBackupJob();
            int storageFile = 0;

            foreach (RestorePoint rp in restorePointList)
            {
                foreach (FileOfJob file in rp.StorageRestorePoint.ArchiveFileList)
                {
                    storageFile++;
                }
            }

            Assert.AreEqual(storageFile, 1);
            Assert.AreEqual(directories.Directories.Count, 1);
        }
    }
}
