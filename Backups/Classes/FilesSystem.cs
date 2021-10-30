using System.Collections.Generic;

namespace Backups.Classes
{
    public class FilesSystem
    {
        public FilesSystem()
        {
            Directories = new List<DirectoryVirtual>();
        }

        public List<DirectoryVirtual> Directories { get; set; }
    }
}
