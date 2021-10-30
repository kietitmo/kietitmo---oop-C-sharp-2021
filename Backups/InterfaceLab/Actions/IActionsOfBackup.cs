using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IActionsOfBackup
    {
        public RestorePoint Run();

        public void SingleStorage();

        public void SplitStorage();

        public void CreateDirectory();

        public void CreateRestorePoint();
        public void DeleteRestorePoint(string number);
    }
}
