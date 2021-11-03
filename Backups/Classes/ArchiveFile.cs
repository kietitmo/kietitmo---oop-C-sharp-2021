using System.Collections.Generic;
namespace Backups.Classes
{
    public class ArchiveFile : FileOfJob
    {
        public ArchiveFile(string fullName, double size)
            : base(fullName, size) { }

        public List<FileOfJob> Files { get; } = new List<FileOfJob>();
    }
}
