using Backups.Classes;

namespace Backups.ActionsOfVirtualSave
{
    public class CreateDirectory
    {
        public void CreateADirectory(VirtualSystem fileSystem, string name) ///// job.anem
        {
            fileSystem.Directories.RemoveAll(d => d.Name == name);

            var jobDirectory = new VirtualDirectory(name, fileSystem.JobObjectsList, null);
            fileSystem.Directories.Add(jobDirectory);
        }
    }
}
