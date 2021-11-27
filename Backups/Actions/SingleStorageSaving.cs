using System.Collections.Generic;
using System.Linq;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class SingleStorageSaving : IStorageTypeAlgorithm
    {
        private static int _pointCount = 1;
        public StorageType TypeStorage { get; set; } = StorageType.Single;

        public Storage StorageCreation(List<FileOfJob> jobObjectsList, DirectoryOfBackup directory)
        {
            var archive = new ArchiveFile(@"RestorePoint" + _pointCount + ".zip", jobObjectsList.Sum(x => x.Size), directory.Path);

            directory.ArchiveFiles.Add(archive);

            foreach (FileOfJob file in jobObjectsList)
            {
                archive.Files.Add(new FileOfJob(file));
            }

            _pointCount++;
            return new Storage(directory.ArchiveFiles, StorageType.Single);
        }
    }
}
