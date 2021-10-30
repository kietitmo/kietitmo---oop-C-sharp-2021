////using System;
////using System.Collections.Generic;
////using System.Text;

////namespace Backups.ActionsOfVirtualSave
////{
////    class SplitStorageCreation
////    {
////        public void Split()
////        {
////            foreach (var file in Job.Files)
////            {
////                var archive = new ArchiveFileInformation(file.Size,
////                                                         Path.Combine(_lastPointDirectory.Name, $@"{file.FullName}.zip"));

////                archive.Files.Add(file.Copy());

////                _lastPointDirectory.Files.Add(archive);
////            }
////        }
////    }
////}
