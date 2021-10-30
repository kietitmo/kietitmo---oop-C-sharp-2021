using System.Collections.Generic;
using Backups.Actions;
using Backups.Classes;
using Backups.Enumeration;

namespace Backups.Service
{
    public class BackupJobVirtual : IBackupService
    {
        public BackupJobVirtual(string name, List<FileOfJob> jobObjectsList, StorageType type)
        {
            VirtualSystem = new VirtualSystem();
            Type = type;
            Name = name;
            JobObjectsList = jobObjectsList;
            Size = 0;
            foreach (FileOfJob file in JobObjectsList)
                Size += file.Size;
        }

        public string Name { get; set; }
        public VirtualSystem VirtualSystem { get; set; }
        public StorageType Type { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public double Size { get; set; }
        public void RunBackupJob()
        {
            var actionOnVirtualSystem = new ActionOnVirtualSystem(new BackupJobVirtual(Name, JobObjectsList, Type), VirtualSystem);
            actionOnVirtualSystem.Run();
        }
    }
}
