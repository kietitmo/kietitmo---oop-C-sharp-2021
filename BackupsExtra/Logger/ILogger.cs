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
        public void Info(string message);
        public void Warning(string message);
        public void Error(string message);
        public void Log(LogType logType, string message);
    }
}
