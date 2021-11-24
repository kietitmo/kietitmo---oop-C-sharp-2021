using System;
using System.Collections.Generic;
using Backups.InterfaceLab;
namespace Backups.Classes
{
    public class RestorePoint
    {
        private static int toSetID = 0;
        public RestorePoint(List<FileOfJob> files, Storage storage, IDirectory directoryOfRestorePoint)
        {
            ID = toSetID + 1;
            CreateTime = DateTime.Now;
            JobObjectsList = new List<FileOfJob>(files);
            StorageRestorePoint = storage;
            DirectoryOfRestorePoint = directoryOfRestorePoint;
            Size = 0;
            foreach (FileOfJob jobObject in JobObjectsList)
            {
                Size += jobObject.Size;
            }
        }

        public IDirectory DirectoryOfRestorePoint { get; set; }
        public int ID { get; set; }
        public DateTime CreateTime { get; }
        public List<FileOfJob> JobObjectsList { get; set; }
        public Storage StorageRestorePoint { get; set; }

        public double Size { get; set; }
    }
}