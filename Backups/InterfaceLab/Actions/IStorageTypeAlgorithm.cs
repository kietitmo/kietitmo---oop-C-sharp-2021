using System.Collections.Generic;
using System.IO;
using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IStorageTypeAlgorithm
    {
        public void StorageCreation(List<FileOfJob> jobObjectsList, DirectoryInfo lastPointDirectory, DirectoryVirtual directoryStorages);
    }
}
