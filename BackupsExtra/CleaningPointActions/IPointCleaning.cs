using System.Collections.Generic;
using Backups.Classes;
namespace BackupsExtra.CleaningPointActions
{
    public interface IPointCleaning
    {
        public void Clean(List<RestorePoint> restorePointsList);
    }
}
