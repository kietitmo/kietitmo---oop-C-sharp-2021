using System.Collections.Generic;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SplitStorageSaving : IStorageTypeAlgorithm
    {
        private static int _pointCount = 1;
        public StorageType TypeStorage { get; set; } = StorageType.SplitStorage;
        public Storage StorageCreation(List<FileOfJob> jobObjectsList, DirectoryOfBackup directory)
        {
            foreach (FileOfJob file in jobObjectsList)
            {
                var archive = new ArchiveFile(file.Name + ".zip", file.Size, directory.Path + @"\" + file.Name + ".zip");

                archive.Files.Add(new FileOfJob(file));

                directory.ArchiveFiles.Add(archive);
            }

            _pointCount++;
            return new Storage(directory.ArchiveFiles, StorageType.SplitStorage);
        }
    }
}
