using System.Collections.Generic;
using System.IO;
using Backups.Classes;

namespace Backups.InterfaceLab.Actions
{
    public interface IJobObjectSaving
    {
        void CreateCopy(List<FileOfJob> jobObjectsList, int pointCount, DirectoryInfo lastPointDirectory);
    }
}
