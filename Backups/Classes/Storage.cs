using System.Collections.Generic;
using System.IO.Compression;

namespace Backups.Classes
{
    public class Storage
    {
        public Storage()
        {
            StorageArchiveFile = new List<ZipArchive>();
        }

        public List<ZipArchive> StorageArchiveFile { get; set; }
    }
}
