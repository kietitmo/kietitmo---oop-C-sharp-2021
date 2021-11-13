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
            ParentDictionary = parentDirectoty;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public IDirectory ParentDictionary { get; set; }
        public List<FileOfJob> Files { get; } = new List<FileOfJob>();
        public List<IDirectory> Directories { get; } = new List<IDirectory>();
    }
}
