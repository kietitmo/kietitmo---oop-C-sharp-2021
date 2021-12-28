using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.MergePoints
{
    public class MergePointsOperation
    {
        private RestorePoint _firstRestorePoint;
        private RestorePoint _secondRestorePoint;
        private List<RestorePoint> _restorePointsList;
        private DirectoriesManager _directoriesManager;
        public MergePointsOperation(DirectoriesManager directoriesManager, List<RestorePoint> restorePointsList,  RestorePoint firstRestorePoint, RestorePoint secondRestorePoint)
        {
            _firstRestorePoint = firstRestorePoint;
            _secondRestorePoint = secondRestorePoint;
            _restorePointsList = restorePointsList;
            _directoriesManager = directoriesManager;
        }

        public void Merge()
        {
            if (_secondRestorePoint.StorageRestorePoint.Type == StorageType.SingleStorage)
            {
                _restorePointsList.Remove(_firstRestorePoint);
                _directoriesManager.Directories.Remove(_firstRestorePoint.Directory);
                return;
            }

            foreach (ArchiveFile file in _firstRestorePoint.StorageRestorePoint.ArchiveFileList)
            {
                if (!IsArchiveInList(file, _secondRestorePoint.StorageRestorePoint.ArchiveFileList))
                {
                    _secondRestorePoint.StorageRestorePoint.ArchiveFileList.Add(new ArchiveFile(file));
                }
            }

            _restorePointsList.Remove(_firstRestorePoint);
            _directoriesManager.Directories.Remove(_firstRestorePoint.Directory);
        }

        private bool IsArchiveInList(ArchiveFile fileNeedCheck, List<ArchiveFile> archiveList)
        {
            foreach (ArchiveFile file in archiveList)
            {
                if (file.Name == fileNeedCheck.Name && file.Size == fileNeedCheck.Size)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
