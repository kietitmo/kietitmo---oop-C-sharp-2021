////using System;
////using System.IO;
////using Backups.InterfaceLab.Actions;

////namespace Backups.ActionsOfVirtualSave
////{
////    public class CreateRestorePoint : IRestorePointCreation
////    {
////        public DirectoryInfo CreateNewRestorePoint(string name, int pointCount, DirectoryInfo lastPointDirectory)
////        {
////            if (_jobDirectory == null)
////                throw new Exception("Job doesnt exist");

////            PointCount++;

////            _jobDirectory.Directories.RemoveAll(d => d.Name == $@"Restore Point {PointCount}");

////            _lastPointDirectory = new VirtualDirectoty(Path.Combine(Job.Name, $@"Restore Point {PointCount}"), _jobDirectory as VirtualDirectoty);

////            _jobDirectory.Directories.Add(_lastPointDirectory);
////        }
////    }
////}
