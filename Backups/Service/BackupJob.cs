using System;
using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Service
{
    [Serializable]
    public class BackupJob
    {
        public BackupJob(string name, string path, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving, DirectoriesManager fileSystem, List<RestorePoint> restorePointList)
        {
            ActionsOfJob = new ActionsOfBackup(name, path, jobObjectsList, storageSaving, fileSystem, restorePointList);
            TypeStorage = storageSaving.TypeStorage;
        }

        public BackupJob()
        {
        }

        public ActionsOfBackup ActionsOfJob { get; set; }
        public StorageType TypeStorage { get; set; }

        public void RunBackupJob()
        {
            ActionsOfJob.Run();
            return;
        }
    }
}
