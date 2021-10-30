using System.Collections.Generic;
using System.IO.Compression;
namespace Backups.Classes
{
    public class DirectoryVirtual
    {
        public DirectoryVirtual(string name)
        {
            Name = name;
            ArchiveFiles = new List<ZipArchive>();
        }

        public DirectoryVirtual(DirectoryVirtual other)
        {
            Name = other.Name;
            ArchiveFiles = new List<ZipArchive>(other.ArchiveFiles);
        }

        public string Name { get; set; }
        public List<ZipArchive> ArchiveFiles { get; set; }
    }
}
