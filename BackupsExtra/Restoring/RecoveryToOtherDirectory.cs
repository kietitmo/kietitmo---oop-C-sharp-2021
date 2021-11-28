using Backups.Classes;

namespace BackupsExtra.Restoring
{
    public class RecoveryToOtherDirectory : IRecover
    {
        private RestorePoint _restorePoint;
        private DirectoryOfBackup _targetDirectory;
        public RecoveryToOtherDirectory(DirectoryOfBackup targetDirectory, RestorePoint restorePoint)
        {
            _restorePoint = restorePoint;
            _targetDirectory = targetDirectory;
        }

        public void Recovery()
        {
            _targetDirectory.Files.AddRange(_restorePoint.JobObjectsList);
        }
    }
}
