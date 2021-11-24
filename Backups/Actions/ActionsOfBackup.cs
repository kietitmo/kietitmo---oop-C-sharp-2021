using System;
using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Backups.InterfaceLab;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class ActionsOfBackup : IActionsOfBackup
    {
        private static int pointCount = 0;
        private IDirectory _lastPointDirectory;
        private IDirectory _jobDirectory;
        public ActionsOfBackup(string name, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving, IFileSystem fileInSystem, List<RestorePoint> restorePoint)
        {
            Name = name;
            JobObjectsList = jobObjectsList;
            StorageSaving = storageSaving;
            FileSystem = fileInSystem;
            RestorePointList = restorePoint;
        }

        public IStorageTypeAlgorithm StorageSaving { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public List<RestorePoint> RestorePointList { get; set; }
        public IFileSystem FileSystem { get; set; }

        public RestorePoint Run()
        {
            CreateDirectory();
            CreateRestorePoint();

            var point = new RestorePoint(JobObjectsList, StorageSaving.StorageCreation(JobObjectsList, _lastPointDirectory), _lastPointDirectory);
            RestorePointList.Add(point);
            return point;
        }

        public void CreateDirectory()
        {
            if (FileSystem.Directories.Count != 0)
            {
                return;
            }

            _jobDirectory = new DirectoryOfBackup(Name);
            FileSystem.Directories.Add(_jobDirectory);
        }

        public void CreateRestorePoint()
        {
            if (_jobDirectory == null)
                throw new Exception("Job doesnt exist");

            pointCount++;

            _jobDirectory.Directories.RemoveAll(d => d.Name == $@"RestorePoint{pointCount}");

            _lastPointDirectory = new DirectoryOfBackup(Path.Combine(Name, $@"RestorePoint {pointCount}"), _jobDirectory as DirectoryOfBackup);

            _jobDirectory.Directories.Add(_lastPointDirectory);
        }

        public void DeleteRestorePoint(RestorePoint restorePointNeedToDelete)
        {
            _jobDirectory.Directories.Remove(restorePointNeedToDelete.DirectoryOfRestorePoint);
            RestorePointList.Remove(restorePointNeedToDelete);
        }
    }
}
