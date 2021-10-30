using System;
using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class Actions : IActionsOfBackup
    {
        private static int pointCount = 0;
        private DirectoryInfo _lastPointDirectory;
        private DirectoryVirtual _lastVirtualDirectory;
        private DirectoryVirtual _rootDirectoryVirtual;
        private string nameOfDirectoryVirtual = "-";
        public Actions(string name, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving, FilesSystem fileInSystem)
        {
            Name = name;
            JobObjectsList = jobObjectsList;
            StorageSaving = storageSaving;
            FileInSystem = fileInSystem;
        }

        public IStorageTypeAlgorithm StorageSaving { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public FilesSystem FileInSystem { get; set; }
        public RestorePoint Run()
        {
            CreateDirectory();
            CreateRestorePoint();

            var newDirectoryVirtual = new DirectoryVirtual(nameOfDirectoryVirtual);
            StorageSaving.StorageCreation(JobObjectsList, _lastPointDirectory, newDirectoryVirtual);
            FileInSystem.Directories.Add(new DirectoryVirtual(newDirectoryVirtual));
            var point = new RestorePoint(JobObjectsList);
            return point;
        }

        public void CreateDirectory()
        {
            if (Directory.Exists(Name))
            {
                return;
            }

            _rootDirectoryVirtual = new DirectoryVirtual(Name);
            _lastVirtualDirectory = _rootDirectoryVirtual;
            Directory.CreateDirectory(Name);
        }

        public void CreateRestorePoint()
        {
            if (!Directory.Exists(Name))
                throw new Exception("Job doesnt exist");

            pointCount++;

            if (Directory.Exists($@"RestorePoint" + pointCount))
            {
                Directory.Delete($@"RestorePoint" + pointCount);
            }

            _lastPointDirectory = Directory.CreateDirectory(Name + @"\" + "RestorePoint" + pointCount);
            nameOfDirectoryVirtual = "RestorePoint" + pointCount;
        }

        public void DeleteRestorePoint(string number)
        {
            if (Directory.Exists($@"RestorePoint" + number))
            {
                Directory.Delete($@"RestorePoint" + number);
            }
        }
    }
}
