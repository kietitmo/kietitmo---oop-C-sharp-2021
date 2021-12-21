using System;

namespace ReportApp.DAL.Entities.Commit
{
    public abstract class AbstractCommit
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CommitDate { get; set; }
        public virtual Guid TaskId { get; set; }
        public virtual string CommentOfCommit { get; set; }
    }
}
