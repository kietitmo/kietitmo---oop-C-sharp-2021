using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;

namespace Backups.Service
{
    public class BackupJob
    {
        private IActionsOfBackup _actionsOfJob;

        public BackupJob(string name, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving, IFileSystem fileSystem, List<RestorePoint> restorePointList)
        {
            _actionsOfJob = new ActionsOfBackup(name, jobObjectsList, storageSaving, fileSystem, restorePointList);
        }

        public void RunBackupJob()
        {
            _actionsOfJob.Run();
            return;
        }

        public void DeleteRestorePoint(RestorePoint restorePointNeedToRemove)
        {
            _actionsOfJob.DeleteRestorePoint(restorePointNeedToRemove);
            return;
        }
    }
}
