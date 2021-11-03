namespace Backups.Classes
{
    public class FileOfJob
    {
        private string _name;
        private double _size;

        public FileOfJob(string name, double size)
        {
            Name = name;
            Size = size;
        }

        public FileOfJob(FileOfJob other)
        {
            Name = other.Name;
            Size = other.Size;
        }

        public string Name { get => _name; set => _name = value; }
        public double Size { get => _size; set => _size = value; }
    }
}
