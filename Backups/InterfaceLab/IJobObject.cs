using System;

namespace Backups.InterfaceLab
{
    public interface IJobObject
    {
        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public double Size { get; set; }
        public string Path { get; set; }
    }
}
