using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab.Actions;
using Backups.Service;
using BackupsExtra.CleaningPointActions;
using BackupsExtra.InforOfJob;
using BackupsExtra.MergePoints;
using BackupsExtra.Restoring;

namespace BackupsExtra.Tests
{
    public class BackupExtraTest
    {
        [Test]
        public void Test_Merge_Restopoint_SplitStorage()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            var mergePointsOperation = new MergePointsOperation(fileSystem, restorePointList, restorePointList[0], restorePointList[1]);
            mergePointsOperation.Merge();
            Assert.AreEqual(restorePointList.Count, 1);
        }

        [Test]
        public void Test_Merge_Restopoint_SingleStorage()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            var mergePointsOperation = new MergePointsOperation(fileSystem, restorePointList, restorePointList[0], restorePointList[1]);
            mergePointsOperation.Merge();
            Assert.AreEqual(restorePointList.Count, 1);
        }

        [Test]
        public void Test_Restore_Restopoint_SplitStorage()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SplitStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            var recover = new RecoveryToOriginalDirectory(fileList, restorePointList.First());
            recover.Recovery();

            Assert.AreEqual(fileList.Count, 2);
        }

        [Test]
        public void Test_Restore_Restopoint_SingleStorage()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            var recover = new RecoveryToOriginalDirectory(fileList, restorePointList.Last());
            recover.Recovery();

            Assert.AreEqual(fileList.Count, 1);
        }

        [Test]
        public void Test_Date_cleaning()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();

            var delebyDate = new DatePointsCleaning(DateTime.Now);
            restorePointList.Last().CreateTime = DateTime.Now.AddDays(1);
            delebyDate.Clean(restorePointList);

            Assert.AreEqual(restorePointList.Count, 1);
        }

        [Test]
        public void Test_Quantity_RestorePoint_cleaning()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            backupJob.RunBackupJob();

            var delebyDate = new QuantityPointsCleaning(1);
            delebyDate.Clean(restorePointList);

            Assert.AreEqual(restorePointList.Count, 1);
        }

        [Test]
        public void Test_Hybird_RestorePoint_cleaning()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            backupJob.RunBackupJob();

            restorePointList.Last().CreateTime = DateTime.Now.AddDays(1);
            restorePointList.First().CreateTime = DateTime.Now.AddDays(2);

            var listConditionCleaning = new List<IPointCleaning>()
            {
                new DatePointsCleaning(DateTime.Now),
                new QuantityPointsCleaning(1),
            };

            var delebyDate = new HybirdPointsCleaning(listConditionCleaning);
            delebyDate.Clean(restorePointList);

            Assert.AreEqual(restorePointList.Count, 1);
        }

        [Test]
        public void Get_StateJob_From_ConfigFile()
        {
            var file1 = new FileOfJob("1.txt", 2, @"Z:\1.txt");
            var file2 = new FileOfJob("2.txt", 2, @"Z:\2.txt");

            var fileList = new List<FileOfJob>() { file1, file2 };

            IStorageTypeAlgorithm storageTypeAlgorithm = new SingleStorageSaving();
            var fileSystem = new DirectoriesManager();
            var restorePointList = new List<RestorePoint>();
            var backupJob = new BackupJob("backupJob", @"Z:\backupJob", fileList, storageTypeAlgorithm, fileSystem, restorePointList);

            backupJob.RunBackupJob();
            fileList.Remove(file2);
            backupJob.RunBackupJob();
            backupJob.RunBackupJob();

            var infor = new BackupJobAndRestorePointManager(restorePointList, backupJob);
            infor.Save();

            BackupJobAndRestorePointManager infor2;
            infor2 = infor.Load();
            Assert.AreEqual(infor2.RestorePointList.Count, 3);
        }
    }
}
