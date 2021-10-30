using System.IO;
namespace Backups.Actions
{
    public class CreateDirectory
    {
        public void CreateADirectory(string name) //// backupjob.name
        {
            if (Directory.Exists(name))
            {
                Directory.Delete(name, true);
            }

            Directory.CreateDirectory(name);
        }
    }
}
