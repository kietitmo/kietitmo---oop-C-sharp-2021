using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SplitStorageSaving : IStorageTypeAlgorithm
    {
        private static int pointCount = 1;
        public void StorageCreation(List<FileOfJob> jobObjectsList, DirectoryInfo lastPointDirectory, DirectoryVirtual directoryStorages)
        {
            foreach (FileOfJob f in jobObjectsList)
            {
                var file = new FileInfo(f.Name);

                FileInfo copyOfFile = file.CopyTo(lastPointDirectory.FullName + @"\" + file.Name);

                using (var zipToOpen = new FileStream(lastPointDirectory.FullName + @"\" + file.Name + "_" + pointCount + ".zip", FileMode.CreateNew))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(copyOfFile.FullName, copyOfFile.Name);

                        directoryStorages.ArchiveFiles.Add(archive);
                    }
                }

                copyOfFile.Delete();
            }

            pointCount++;
        }
    }
}
