using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        public Storage(List<FileOfJob> fileList, StorageType type)
        {
            Type = type;
            ArchiveFileList = fileList;
        }

        public List<FileOfJob> ArchiveFileList { get; set; }
        public StorageType Type { get; set; }
    }
}
