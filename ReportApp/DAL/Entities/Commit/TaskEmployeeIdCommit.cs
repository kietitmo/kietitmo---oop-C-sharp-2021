using System;

namespace ReportApp.DAL.Entities.Commit
{
    public class TaskEmployeeIdCommit : AbstractCommit
    {
        public TaskEmployeeIdCommit()
        {
        }
        public TaskEmployeeIdCommit(Guid taskId, Guid newEmployeeId, string commentOfCommit)
        {
            Id = Guid.NewGuid();
            CommitDate = DateTime.Now;
            TaskId = taskId;
            OldEmployeeId = EmployeeId;
            EmployeeId = newEmployeeId;
            CommentOfCommit = commentOfCommit;
        }

        public override Guid Id { get; set; }
        public override DateTime CommitDate { get; set; }
        public override Guid TaskId { get; set; }
        public Guid OldEmployeeId { get; set; }
        public Guid EmployeeId { get; set; }
        public override string CommentOfCommit { get; set; }
    }
}
