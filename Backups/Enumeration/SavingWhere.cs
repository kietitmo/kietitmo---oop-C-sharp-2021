namespace Backups.Enumeration
{
    /// <summary>
    /// Where we will save Backup Files.
    /// </summary>
    public enum SavingWhere
    {
        /// <summary>
        /// On local computer.
        /// </summary>
        LocalSystem,

        /// <summary>
        /// On virtual System
        /// </summary>
        VirtualSystem,

        /// <summary>
        /// On googledrive, cloud,...
        /// </summary>
        Other,
    }
}
