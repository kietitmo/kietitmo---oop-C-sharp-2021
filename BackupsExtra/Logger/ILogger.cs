namespace BackupsExtra.Logger
{
    public enum LogType
    {
        /// <summary>
        /// Info.
        /// </summary>
        Info,

        /// <summary>
        /// Warning.
        /// </summary>
        Warning,

        /// <summary>
        /// Error.
        /// </summary>
        Error,
    }

    public interface ILogger
    {
        public void BackupInfo(string message);
        public void BackupWarning(string message);
        public void BackupError(string message);
        public void Log(LogType logType, string message);
    }
}
