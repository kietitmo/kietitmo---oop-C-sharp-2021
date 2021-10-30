using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class ArchiveFile : FileOfJob
    {
        public ArchiveFile(string name, double size, string path, DateTime time)
            : base(name, size, path, time)
        {
            JobObjectsList = new List<FileOfJob>();
        }

        public List<FileOfJob> JobObjectsList { get; set; }
    }
}
