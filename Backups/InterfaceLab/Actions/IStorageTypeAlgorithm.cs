using System.Collections.Generic;
using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IStorageTypeAlgorithm
    {
        public Storage StorageCreation(List<FileOfJob> jobObjectsList, IDirectory lastPointDirectory);
    }
}
