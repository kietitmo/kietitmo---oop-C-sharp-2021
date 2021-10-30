namespace Backups.Service
{
    public interface IBackupService
    {
        public void RunBackupJob();
        public void DeleteRestorePoint(string number);
    }
}
