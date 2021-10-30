using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class RestorePoint
    {
        public RestorePoint(List<FileOfJob> files)
        {
            CreateTime = DateTime.Now;
            JobObjectsList = new List<FileOfJob>(files);
            Size = 0;
            foreach (FileOfJob jobObject in JobObjectsList)
            {
                Size += jobObject.Size;
            }
        }

        public DateTime CreateTime { get; }
        public List<FileOfJob> JobObjectsList { get; }

        public double Size { get; }
    }
}