using System.Collections.Generic;
using Backups.InterfaceLab;

namespace Backups.Classes
{
    public class VirtualSystem : IFileSystem
    {
        public VirtualSystem()
        {
            Directories = new List<IDirectory>();
            JobObjectsList = new List<FileOfJob>();
        }

        public List<IDirectory> Directories { get; set; }

        public List<FileOfJob> JobObjectsList { get; set; }
    }
}
