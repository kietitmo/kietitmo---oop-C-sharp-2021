using System.Collections.Generic;
using Backups.InterfaceLab;
namespace Backups.Classes
{
    public class FileSystem : IFileSystem
    {
        public FileSystem()
        {
            Directories = new List<IDirectory>();
        }

        public List<IDirectory> Directories { get; set; }
    }
}
