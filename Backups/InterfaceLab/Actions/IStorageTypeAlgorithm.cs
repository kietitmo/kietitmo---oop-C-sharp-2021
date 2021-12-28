using System.Collections.Generic;
using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IStorageTypeAlgorithm
    {
        public StorageType TypeStorage { get; set; }
        public Storage StorageCreation(List<FileOfJob> jobObjectsList, DirectoryOfBackup directory);
    }
}
