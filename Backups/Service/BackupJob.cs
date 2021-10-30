using System.Collections.Generic;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Service
{
    public class BackupJob
    {
        public BackupJob(string name, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving)
        {
            Name = name;
            JobObjectsList = jobObjectsList;
            StorageSaving = storageSaving;
            FileInSystem = new FilesSystem();
        }

        public FilesSystem FileInSystem { get; set; }
        public IStorageTypeAlgorithm StorageSaving { get; set; }
        public Actions.Actions ActionsOfJob { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }

        public void RunBackupJob()
        {
            ActionsOfJob = new Actions.Actions(Name, JobObjectsList, StorageSaving, FileInSystem);
            ActionsOfJob.Run();
            return;
        }

        public void DeleteRestorePoint(string number)
        {
            ActionsOfJob.DeleteRestorePoint(number);
            return;
        }
    }
}
