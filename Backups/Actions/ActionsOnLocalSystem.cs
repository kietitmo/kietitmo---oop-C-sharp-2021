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
        private DirectoryInfo _lastPointDirectory;
        public ActionsOnLocalSystem(BackupJobLocal job)
        {
            Job = job;
        }

        public ulong PointCount { get; private set; } = 0;
        public BackupJobLocal Job { get; }

        public RestorePoint Run()
        {
            CreateDirectory();
            CreatePoint();

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
            using (var zipToOpen = new FileStream(Path.Combine(_lastPointDirectory.FullName, $@"Restore Point_{PointCount}.zip"), FileMode.CreateNew))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    foreach (FileOfJob f in Job.JobObjectsList)
                    {
                        var file = new FileInfo(f.Name);

                        FileInfo copy = file.CopyTo(Path.Combine(_lastPointDirectory.FullName, file.Name));

                        archive.CreateEntryFromFile(copy.FullName, copy.Name);

                        copy.Delete();
                    }
                }
            }
        }

        public void SplitStorage()
        {
            foreach (FileOfJob f in Job.JobObjectsList)
            {
                var file = new FileInfo(f.Name);

                FileInfo copy = file.CopyTo(Path.Combine(_lastPointDirectory.FullName, file.Name));

                using (var zipToOpen = new FileStream(Path.Combine(_lastPointDirectory.FullName, $@"{file.Name}_{PointCount}.zip"), FileMode.CreateNew))
                {
                    using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(copy.FullName, copy.Name);
                    }
                }

                copy.Delete();
            }
        }

        public void CreateDirectory()
        {
            if (Directory.Exists(Job.Name))
            {
                Directory.Delete(Job.Name, true);
            }

            Directory.CreateDirectory(Job.Name);
        }

        public void CreatePoint()
        {
            if (!Directory.Exists(Job.Name))
                throw new Exception("Job doesnt exist");

            PointCount++;

            if (Directory.Exists($@"Restore Point {PointCount}"))
            {
                Directory.Delete($@"Restore Point {PointCount}", true);
            }

            _lastPointDirectory = Directory.CreateDirectory(Path.Combine(Job.Name, $@"Restore Point {PointCount}"));
        }

        public void DeletePoint()
        {
        }
    }
}
