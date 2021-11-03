using System.Collections.Generic;
using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IStorageTypeAlgorithm
    {
        public void StorageCreation(List<FileOfJob> jobObjectsList, IDirectory lastPointDirectory);
    }
}
