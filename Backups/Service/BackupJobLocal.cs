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

        public ActionsOnLocalSystem ActionOnLocalSystem { get; set; }
        public StorageType Type { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }

        public void RunBackupJob()
        {
            ActionOnLocalSystem = new ActionsOnLocalSystem(new BackupJobLocal(Name, JobObjectsList, Type));
            ActionOnLocalSystem.CreateDirectory();
            ActionOnLocalSystem.Run();
            return;
        }

        public void DeleteRestorePoint(string number)
        {
            ActionOnLocalSystem.DeleteRestorePoint(number);
            return;
        }
    }
}
