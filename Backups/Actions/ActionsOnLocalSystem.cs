using System;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.Enumeration;
using Backups.InterfaceLab.Actions;
using Backups.Service;

namespace Backups.Actions
{
    public class ActionsOnLocalSystem : IActionsOfBackup
    {
        private static int pointCount = 0;
        private DirectoryInfo _lastPointDirectory;
        public ActionsOnLocalSystem(BackupJobLocal job)
        {
            Job = job;
        }

        public BackupJobLocal Job { get; }

        public RestorePoint Run()
        {
            CreateDirectory();
            CreateRestorePoint();

            switch (Job.Type)
            {
                case StorageType.SingleStorage:
                    SingleStorage();
                    break;
                case StorageType.SplitStorage:
                    SplitStorage();
                    break;
            }

            var point = new RestorePoint(Job.JobObjectsList);

            return point;
        }

        public void SingleStorage()
        {
            using (var zipToOpen = new FileStream(_lastPointDirectory.FullName + "RestorePoint" + pointCount + ".zip", FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (FileOfJob f in Job.JobObjectsList)
                    {
                        var file = new FileInfo(f.Name);

                        FileInfo copyOfFile = file.CopyTo(Path.Combine(_lastPointDirectory.FullName, file.Name));

                        archive.CreateEntryFromFile(copyOfFile.FullName, copyOfFile.Name);

                        copyOfFile.Delete();
                    }
                }
            }
        }

        public void SplitStorage()
        {
            foreach (FileOfJob f in Job.JobObjectsList)
            {
                var file = new FileInfo(f.Name);

                FileInfo copyOfFile = file.CopyTo(_lastPointDirectory.FullName + @"\" + file.Name);

                using (var zipToOpen = new FileStream(_lastPointDirectory.FullName + @"\" + file.Name + "_" + pointCount + ".zip", FileMode.CreateNew))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(copyOfFile.FullName, copyOfFile.Name);
                    }
                }

                copyOfFile.Delete();
            }
        }

        public void CreateDirectory()
        {
            if (Directory.Exists(Job.Name))
            {
                return;
            }

            Directory.CreateDirectory(Job.Name);
        }

        public void CreateRestorePoint()
        {
            if (!Directory.Exists(Job.Name))
                throw new Exception("Job doesnt exist");

            pointCount++;

            if (Directory.Exists($@"RestorePoint" + pointCount))
            {
                Directory.Delete($@"RestorePoint" + pointCount);
            }

            _lastPointDirectory = Directory.CreateDirectory(Job.Name + @"\" + "RestorePoint" + pointCount);
        }

        public void DeleteRestorePoint(string number)
        {
        }
    }
}
