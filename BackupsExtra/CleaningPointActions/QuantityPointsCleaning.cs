using System.Collections.Generic;
using System.Linq;
using Backups.Classes;
using Backups.Tools;

namespace BackupsExtra.CleaningPointActions
{
    public class QuantityPointsCleaning : IPointCleaning
    {
        private int _quantity;
        public QuantityPointsCleaning(int quantity)
        {
            _quantity = quantity;
        }

        public void Clean(List<RestorePoint> restorePointsList)
        {
            int quantityNeedDelete = restorePointsList.Count - _quantity;
            for (int i = 0; i < quantityNeedDelete; i++)
            {
                restorePointsList.Remove(restorePointsList.First());
            }

            if (restorePointsList.Count == 0)
            {
                throw new BackupException("AllRestorePointsAreDeletedException");
            }
        }
    }
}
