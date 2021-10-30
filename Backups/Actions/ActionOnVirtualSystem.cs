using System;
using System.IO;
using Backups.Classes;
using Backups.Enumeration;
using Backups.InterfaceLab.Actions;
using Backups.Service;

namespace Backups.Actions
{
    public class ActionOnVirtualSystem : IActionsOfBackup
    {
        private VirtualDirectory _lastPointDirectory;
        private VirtualDirectory _jobDirectory;
        public ActionOnVirtualSystem(BackupJobVirtual job, VirtualSystem fileSystem)
        {
            Job = job;
            VirtualSystem = fileSystem;
            ////VirtualSystem.JobObjectsList = _lastPointDirectory.Files;
        }

        public ulong PointCount { get; private set; } = 0;
        public BackupJobVirtual Job { get; }
        public VirtualSystem VirtualSystem { get; }

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
            var archive = new ArchiveFile(Job.Name, Job.Size, Path.Combine(_lastPointDirectory.Name, $@"RestorePoint{PointCount}.zip"), DateTime.Now);

            _lastPointDirectory.Files.Add(archive);

            foreach (FileOfJob file in Job.JobObjectsList)
            {
                archive.JobObjectsList.Add(new FileOfJob(file));
            }
        }

        public void SplitStorage()
        {
            foreach (FileOfJob file in Job.JobObjectsList)
            {
                var archive = new ArchiveFile(Job.Name, file.Size, Path.Combine(_lastPointDirectory.Name, $@"{file.Name}.zip"), DateTime.Now);

                archive.JobObjectsList.Add(new FileOfJob(file));

                _lastPointDirectory.Files.Add(archive);
            }
        }

        public void CreateDirectory()
        {
            VirtualSystem.Directories.RemoveAll(d => d.Name == Job.Name);

            _jobDirectory = new VirtualDirectory(Job.Name, Job.JobObjectsList, null);
            VirtualSystem.Directories.Add(_jobDirectory);
        }

        public void CreatePoint()
        {
            if (_jobDirectory == null)
                throw new Exception("Job doesnt exist");

            PointCount++;

            _jobDirectory.ChildDirectories.RemoveAll(d => d.Name == $@"Restore Point {PointCount}");

            _lastPointDirectory = new VirtualDirectory(Path.Combine(Job.Name, $@"Restore Point {PointCount}"), Job.JobObjectsList, _jobDirectory as VirtualDirectory);

            _jobDirectory.ChildDirectories.Add(_lastPointDirectory);
        }

        public void DeletePoint()
        {
        }
    }
}
