using System.Collections.Generic;
using System.Xml.Serialization;
using Backups.Classes;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    [System.Serializable]
    public class ActionsOfBackup
    {
        private static int pointCount = 0;
        private DirectoryOfBackup _lastDirectory;

        public ActionsOfBackup(string name, string path, List<FileOfJob> jobObjectsList, IStorageTypeAlgorithm storageSaving, DirectoriesManager directoriesManager, List<RestorePoint> restorePoint)
        {
            Name = name;
            Path = path;
            JobObjectsList = jobObjectsList;
            StorageSaving = storageSaving;
            DirectoriesManager = directoriesManager;
            RestorePointList = restorePoint;
        }

        public ActionsOfBackup()
        {
        }

        [XmlIgnore]
        public IStorageTypeAlgorithm StorageSaving { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public List<RestorePoint> RestorePointList { get; set; }
        public DirectoriesManager DirectoriesManager { get; set; }

        public RestorePoint Run()
        {
            pointCount++;
            _lastDirectory = new DirectoryOfBackup(Path + @"\" + $@"RestorePoint{pointCount}", Name + pointCount);
            DirectoriesManager.Directories.Add(_lastDirectory);
            var point = new RestorePoint(JobObjectsList, StorageSaving.StorageCreation(JobObjectsList, _lastDirectory), _lastDirectory);
            RestorePointList.Add(point);
            return point;
        }
    }
}
