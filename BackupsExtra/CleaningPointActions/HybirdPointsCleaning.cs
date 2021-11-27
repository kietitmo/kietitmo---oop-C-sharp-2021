using System.Collections.Generic;
using Backups.Classes;
using Backups.Tools;

namespace BackupsExtra.CleaningPointActions
{
    public class HybirdPointsCleaning : IPointCleaning
    {
        private List<IPointCleaning> _oftionCleaningList;
        public HybirdPointsCleaning(List<IPointCleaning> oftionCleaningList)
        {
            _oftionCleaningList = oftionCleaningList;
        }

        public void Clean(List<RestorePoint> restorePointsList)
        {
            _oftionCleaningList.ForEach(oftion => oftion.Clean(restorePointsList));
            if (restorePointsList.Count == 0)
            {
                throw new BackupException("AllRestorePointsAreDeletedException");
            }
        }
    }
}
