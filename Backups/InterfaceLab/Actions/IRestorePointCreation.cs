using System.IO;
namespace Backups.InterfaceLab.Actions
{
    public interface IRestorePointCreation
    {
        public DirectoryInfo CreateNewRestorePoint(string name, int pointCount, DirectoryInfo lastPointDirectory);
    }
}
