using System;
using System.IO;

namespace Backups.Classes
{
    public class FileOfJob
    {
        private string _name;
        private DateTime _dateModified;
        private double _size;
        private string _path;

        public FileOfJob(string name)
        {
            var file = new FileInfo(name);

            Path = file.FullName;
            Name = file.Name;
            DateModified = file.CreationTime;
            Size = file.Length;
        }

        public FileOfJob(FileOfJob other)
        {
            Name = other.Name;
            DateModified = other.DateModified;
            Size = other.Size;
        }

        public string Name { get => _name; set => _name = value; }
        public DateTime DateModified { get => _dateModified; set => _dateModified = value; }
        public double Size { get => _size; set => _size = value; }
        public string Path { get => _path; set => _path = value; }
    }
}
