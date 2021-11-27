using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Restoring
{
    public class RecoveryToOriginalDirectory : IRecover
    {
        private RestorePoint _restorePoint;
        private List<FileOfJob> _filesList;
        public RecoveryToOriginalDirectory(List<FileOfJob> filesList, RestorePoint restorePoint)
        {
            _restorePoint = restorePoint;
            _filesList = filesList;
        }

        public void Recovery()
        {
            _filesList.Clear();
            foreach (ArchiveFile archiveFile in _restorePoint.StorageRestorePoint.ArchiveFileList)
            {
                foreach (FileOfJob file in archiveFile.Files)
                {
                    if (!_filesList.Contains(file))
                    {
                        _filesList.Add(file);
                    }
                }
            }
        }
    }
}
