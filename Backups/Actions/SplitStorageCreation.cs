using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SplitStorageCreation : IJobObjectSaving
    {
        public void CreateCopy(List<FileOfJob> jobObjectsList, int pointCount, DirectoryInfo lastPointDirectory)
        {
            foreach (FileOfJob jobObject in jobObjectsList)
            {
                var file = new FileInfo(jobObject.Name);

                FileInfo copy = file.CopyTo(Path.Combine(lastPointDirectory.FullName, file.Name));

                using (var zipToOpen = new FileStream(Path.Combine(lastPointDirectory.FullName, $@"{file.Name}_{pointCount}.zip"), FileMode.CreateNew))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(copy.FullName, copy.Name);
                    }
                }

                copy.Delete();
            }
        }
    }
}
