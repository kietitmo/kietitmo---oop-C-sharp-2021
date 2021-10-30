using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.Enumeration;

namespace Backups.Service
{
    public class BackupJobLocal : IBackupService
    {
        public BackupJobLocal(string name, List<FileOfJob> jobObjectsList, StorageType type)
        {
            Name = name;
            Type = type;
            JobObjectsList = new List<FileOfJob>(jobObjectsList);
            Type = type;
        }

        public StorageType Type { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }

        public void RunBackupJob()
        {
            var actionOnLocalSystem = new ActionsOnLocalSystem(new BackupJobLocal(Name, JobObjectsList, Type));
            actionOnLocalSystem.CreateDirectory();
            actionOnLocalSystem.Run();
            ////CreateDirectory.CreateADirectory(Name);
            ////LastPointDirectory = CreateRestorePoint.CreateNewRestorePoint(Name, countPoint, LastPointDirectory);
            ////if (Type == StorageType.SingleStorage)
            ////{
            ////    var saving = new SingleStorageCreation();
            ////    saving.CreateCopy(JobObjectsList, countPoint, LastPointDirectory);
            ////    countPoint = countPoint + 1;
            ////    return;
            ////}

            ////if (Type == StorageType.SplitStorage)
            ////{
            ////    var saving = new SplitStorageCreation();
            ////    saving.CreateCopy(JobObjectsList, countPoint, LastPointDirectory);
            ////    countPoint = countPoint + 1;
            ////    return;
            ////}
        }
    }
}
