using System.Collections.Generic;
using System.IO;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab.Actions;
using Backups.Service;
using NUnit.Framework;

namespace Backups.Tests
{
    class BackupTest
    {
        [Test]
        public void TestCase1_SplitStorage()
        {
            var file1 = new FileOfJob("1.txt");
            var file2 = new FileOfJob("2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var backupJob = new BackupJob("backupJob", fileList, storageTypeAlgorithm);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();

            Assert.AreEqual(backupJob.FileInSystem.Directories.Count, 2);
        }

    }
}
