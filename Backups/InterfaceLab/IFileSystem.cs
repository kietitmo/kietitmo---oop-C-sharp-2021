using System.Collections.Generic;
using Backups.Classes;

namespace Backups.InterfaceLab
{
    public interface IFileSystem
    {
        public List<IDirectory> Directories { get; set; }

        public List<FileOfJob> JobObjectsList { get; set; }
    }
}
