namespace Backups.Classes
{
    public class ArchiveFile : FileOfJob
    {
        public ArchiveFile(string name)
            : base(name) { }
        public ArchiveFile(ArchiveFile other)
            : base(other) { }
    }
}
