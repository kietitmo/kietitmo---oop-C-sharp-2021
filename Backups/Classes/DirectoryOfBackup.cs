using System.Collections.Generic;
namespace Backups.Classes
{
    public class DirectoryOfBackup
    {
        public DirectoryOfBackup(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public DirectoryOfBackup()
        {
        }

        public string Path { get; set; }
        public string Name { get; set; }
        public List<FileOfJob> Files { get; set; } = new List<FileOfJob>();
        public List<ArchiveFile> ArchiveFiles { get; set; } = new List<ArchiveFile>();
    }
}
