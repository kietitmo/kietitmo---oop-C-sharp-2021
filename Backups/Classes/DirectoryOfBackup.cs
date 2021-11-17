using System.Collections.Generic;
using Backups.InterfaceLab;

namespace Backups.Classes
{
    public class DirectoryOfBackup : IDirectory
    {
        private static int toSetID = 0;
        public DirectoryOfBackup(string name, DirectoryOfBackup parentDirectoty = null)
        {
            ID = toSetID + 1;
            Name = name;
            ParentDirectory = parentDirectoty;
            ChildrenDirectories = new List<IDirectory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public IDirectory ParentDirectory { get; set; }
        public List<FileOfJob> Files { get; } = new List<FileOfJob>();
        public List<IDirectory> ChildrenDirectories { get; }
    }
}
