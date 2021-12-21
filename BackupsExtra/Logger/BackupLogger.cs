using System;
using System.IO;

namespace BackupsExtra.Logger
{
    public class BackupLogger : ILogger
    {
        private static readonly object LockObject = new object();
        private static BackupLogger _instance;
        private BackupLogger() { }

        public static BackupLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (LockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new BackupLogger();
                    }
                }
            }

            return _instance;
        }

        public void BackupInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void BackupWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void BackupError(string message)
        {
            Log(LogType.Error, message);
        }

        public void Log(LogType logType, string message)
        {
            using (var writer = new StreamWriter(@"C:\Users\sirtu\Source\Repos\kietitmo\BackupsExtra\log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }

            Console.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}
