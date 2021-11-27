using System.Collections.Generic;

namespace Backups.Classes
{
    public class DirectoriesManager
    {
        public DirectoriesManager()
        {
            Directories = new List<DirectoryOfBackup>();
        }

        public List<DirectoryOfBackup> Directories { get; set; }
    }
}
