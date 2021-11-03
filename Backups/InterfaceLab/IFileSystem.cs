using System.Collections.Generic;

namespace Backups.InterfaceLab
{
    public interface IFileSystem
    {
        public List<IDirectory> Directories { get; set; }
    }
}
