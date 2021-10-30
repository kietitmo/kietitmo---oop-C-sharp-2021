using System.Collections.Generic;
using Backups.InterfaceLab;

namespace Backups.Classes
{
    public class VirtualDirectory : IDirectory
    {
        public VirtualDirectory(string name, List<FileOfJob> fileOfJobs, VirtualDirectory parentDictionary)
        {
            Name = name;
            ParentDictionary = parentDictionary;
            ChildDirectories = new List<IDirectory>();
            Files = new List<FileOfJob>(fileOfJobs);
        }

        public string Name { get; set; }

        public IDirectory ParentDictionary { get; set; }

        public List<FileOfJob> Files { get; set; }

        public List<IDirectory> ChildDirectories { get; set; }
    }
}
