using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SingleStorageSaving : IStorageTypeAlgorithm
    {
        private static int pointCount = 1;
        public void StorageCreation(List<FileOfJob> jobObjectsList, DirectoryInfo lastPointDirectory, DirectoryVirtual directoryStorages)
        {
            using (var zipToOpen = new FileStream(lastPointDirectory.FullName + @"\" + "RestorePoint" + pointCount + ".zip", FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (FileOfJob f in jobObjectsList)
                    {
                        var file = new FileInfo(f.Name);
                        FileInfo copyOfFile = file.CopyTo(Path.Combine(lastPointDirectory.FullName, file.Name));

                        archive.CreateEntryFromFile(copyOfFile.FullName, copyOfFile.Name);
                        copyOfFile.Delete();
                    }

                    directoryStorages.ArchiveFiles.Add(archive);
                }
            }

            pointCount++;
        }
    }
}
