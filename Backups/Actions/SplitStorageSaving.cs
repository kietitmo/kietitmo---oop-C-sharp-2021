using System.Collections.Generic;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SplitStorageSaving : IStorageTypeAlgorithm
    {
        private static int _pointCount = 1;
        public void StorageCreation(List<FileOfJob> jobObjectsList, IDirectory lastPointDirectory)
        {
            foreach (FileOfJob file in jobObjectsList)
            {
                var archive = new ArchiveFile(lastPointDirectory.NameOfDirectory + @"\" + file.Name + ".zip", file.Size);

                archive.Files.Add(new FileOfJob(file));

                lastPointDirectory.Files.Add(archive);
            }

            _pointCount++;
        }
    }
}
