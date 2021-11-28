using System.Collections.Generic;

namespace Backups.Classes
{
    public class ArchiveFile : FileOfJob
    {
        public ArchiveFile() { }
        public ArchiveFile(string name, double size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }

        public ArchiveFile(ArchiveFile other)
        {
            Name = other.Name;
            Size = other.Size;
            Path = other.Path;
            Files = other.Files;
        }

        public List<FileOfJob> Files { get; set; } = new List<FileOfJob>();
    }
}
