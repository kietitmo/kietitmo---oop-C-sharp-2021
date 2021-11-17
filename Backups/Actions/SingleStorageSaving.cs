using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SingleStorageSaving : IStorageTypeAlgorithm
    {
        private static int _pointCount = 1;
        public void StorageCreation(List<FileOfJob> jobObjectsList, IDirectory lastPointDirectory)
        {
            var archive = new ArchiveFile(Path.Combine(lastPointDirectory.NameOfDirectory, $@"RestorePoint{_pointCount}.zip"), jobObjectsList.Sum(x => x.Size));

            lastPointDirectory.Files.Add(archive);

            foreach (FileOfJob file in jobObjectsList)
            {
                archive.Files.Add(new FileOfJob(file));
            }

            _pointCount++;
        }
    }
}
