using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        public Storage()
        {
        }

        public Storage(List<ArchiveFile> fileList, StorageType type)
        {
            Type = type;
            ArchiveFileList = fileList;
        }

        public List<ArchiveFile> ArchiveFileList { get; set; }
        public StorageType Type { get; set; }
    }
}
