using System;
using System.Collections.Generic;
using Backups.Classes;
using Backups.Tools;

namespace BackupsExtra.CleaningPointActions
{
    public class DatePointsCleaning : IPointCleaning
    {
        private DateTime _date;
        public DatePointsCleaning(DateTime date)
        {
            _date = date;
        }

        public void Clean(List<RestorePoint> restorePointsList)
        {
            restorePointsList.RemoveAll(restorePoint => restorePoint.CreateTime <= _date);
            if (restorePointsList.Count == 0)
            {
                throw new BackupException("AllRestorePointsAreDeletedException");
            }
        }
    }
}
