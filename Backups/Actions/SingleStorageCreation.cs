using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SingleStorageCreation : IJobObjectSaving
    {
        public void CreateCopy(List<FileOfJob> jobObjectsList, int pointCount, DirectoryInfo lastPointDirectory)
        {
            using (var zipToOpen = new FileStream(Path.Combine(lastPointDirectory.FullName, $@"RestorePoint_" + pointCount + ".zip"), FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (FileOfJob jobObject in jobObjectsList)
                    {
                        var file = new FileInfo(jobObject.Name);

                        FileInfo copy = file.CopyTo(Path.Combine(lastPointDirectory.FullName, file.Name));

                        archive.CreateEntryFromFile(copy.FullName, copy.Name);

                        copy.Delete();
                    }
                }
            }
        }
    }
}
