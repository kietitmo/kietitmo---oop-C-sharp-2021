using System;
using System.Collections.Generic;
namespace Backups.Classes
{
    public class RestorePoint
    {
        private static int toSetID = 0;
        public RestorePoint(List<FileOfJob> files, Storage storage, DirectoryOfBackup directory)
        {
            ID = toSetID + 1;
            CreateTime = DateTime.Now;
            JobObjectsList = new List<FileOfJob>(files);
            StorageRestorePoint = storage;
            Directory = directory;
            Size = 0;
            foreach (FileOfJob jobObject in JobObjectsList)
            {
                Size += jobObject.Size;
            }

            toSetID++;
        }

        public RestorePoint()
        {
        }

        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public Storage StorageRestorePoint { get; set; }
        public DirectoryOfBackup Directory { get; set; }

        public double Size { get; set; }
    }
}