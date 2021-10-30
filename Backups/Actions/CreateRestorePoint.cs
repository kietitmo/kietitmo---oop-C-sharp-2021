using System;
using System.IO;
using Backups.InterfaceLab.Actions;

namespace Backups.Actions
{
    public class CreateRestorePoint : IRestorePointCreation
    {
        public DirectoryInfo CreateNewRestorePoint(string name, int pointCount, DirectoryInfo lastPointDirectory)
        {
            if (!Directory.Exists(name)) //// backupjob.name
                throw new Exception("Job fail");
            if (Directory.Exists(@"RestorePoint" + pointCount))
            {
                pointCount++;
            }

            lastPointDirectory = Directory.CreateDirectory(Path.Combine(name, $@"RestorePoint" + pointCount));
            return lastPointDirectory;
        }
    }
}
