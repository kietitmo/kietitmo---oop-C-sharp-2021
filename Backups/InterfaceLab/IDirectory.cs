using System.Collections.Generic;
using Backups.Classes;

namespace Backups.InterfaceLab
{
    public interface IDirectory
    {
        public string NameOfDirectory { get; set; }
        public IDirectory ParentDirectory { get; set; }
        public List<FileOfJob> Files { get; }
        public List<IDirectory> ChildrenDirectories { get; }
    }
}
