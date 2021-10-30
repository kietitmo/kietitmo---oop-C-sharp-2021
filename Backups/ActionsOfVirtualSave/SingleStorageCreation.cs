////using System;
////using System.Collections.Generic;
////using System.Text;

////namespace Backups.ActionsOfVirtualSave
////{
////    class SingleStorageCreation
////    {
////        public void Single()
////        {
////            var archive = new ArchiveFileInformation(Job.Files.Sum(x => x.Size),
////                                                     Path.Combine(_lastPointDirectory.Name, $@"Restore Point {PointCount}.zip"));

////            _lastPointDirectory.Files.Add(archive);

////            foreach (var file in Job.Files)
////            {
////                archive.Files.Add(file.Copy());
////            }
////        }
////    }
////}
