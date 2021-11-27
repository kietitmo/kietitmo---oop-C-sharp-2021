namespace Backups.Classes
{
    public class FileOfJob
    {
        public FileOfJob()
        {
        }

        public FileOfJob(string name, double size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }

        public FileOfJob(FileOfJob other)
        {
            Name = other.Name;
            Size = other.Size;
            Path = other.Path;
        }

        public string Name { get; set; }
        public double Size { get; set; }
        public string Path { get; set; }
    }
}
