using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Backups.Classes;
using Backups.Service;

namespace BackupsExtra.InforOfJob
{
    [Serializable]
    public class BackupJobAndRestorePointManager
    {
        public BackupJobAndRestorePointManager(List<RestorePoint> restorePoints, BackupJob job)
        {
            RestorePointList = restorePoints;
            Job = job;
        }

        public BackupJobAndRestorePointManager()
        {
        }

        public List<RestorePoint> RestorePointList { get; set; }
        public BackupJob Job { get; set; }

        public void RunBackup()
        {
            Job.RunBackupJob();
        }

        public StorageType GetStorageType()
        {
            return Job.TypeStorage;
        }

        public void PrintStringRP()
        {
            foreach (RestorePoint point in RestorePointList)
            {
                Console.WriteLine("================================");
                Console.WriteLine("ID: " + point.ID);
                Console.WriteLine("CreationTime: " + point.CreateTime);
                Console.WriteLine("Size: " + point.Size);
                foreach (FileOfJob file in point.JobObjectsList)
                {
                    Console.Write("File Name: " + file.Name + "\t");
                    Console.WriteLine("File Size: " + file.Size);
                }

                Console.WriteLine("Type Storage: " + point.StorageRestorePoint.Type);
                foreach (FileOfJob file in point.StorageRestorePoint.ArchiveFileList)
                {
                    Console.Write("File Name: " + file.Name + "\t");
                    Console.WriteLine("File Size: " + file.Size);
                }
            }
        }

        public void Save()
        {
            using (var stream = new FileStream(@"C:\Users\TUAN KIET\source\repos\kietitmo-labs-oop-2021\BackupsExtra\App.config", FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(BackupJobAndRestorePointManager), new Type[] { typeof(ArchiveFile), typeof(DateTime), typeof(DirectoriesManager) });
                xml.Serialize(stream, this);
                stream.Close();
            }
        }

        public BackupJobAndRestorePointManager Load()
        {
            using (var stream = new FileStream(@"C:\Users\TUAN KIET\source\repos\kietitmo-labs-oop-2021\BackupsExtra\App.config", FileMode.OpenOrCreate))
            {
                var xml = new XmlSerializer(typeof(BackupJobAndRestorePointManager), new Type[] { typeof(ArchiveFile), typeof(DateTime), typeof(DirectoriesManager) });
                return (BackupJobAndRestorePointManager)xml.Deserialize(stream);
            }
        }
    }
}
