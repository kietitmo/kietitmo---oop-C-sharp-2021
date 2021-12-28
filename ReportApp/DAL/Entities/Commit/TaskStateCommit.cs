using System;
using ReportApp.DTO.Tools;

namespace ReportApp.DAL.Entities.Commit
{
    public class TaskStateCommit : AbstractCommit
    {
        public TaskStateCommit()
        {
        }
        public TaskStateCommit(Guid taskId, TaskState newState, string commentOfCommit)
        {
            Id = Guid.NewGuid();
            CommitDate = DateTime.Now;
            TaskId = taskId;
            OldState = State;
            State = newState;
            CommentOfCommit = commentOfCommit;
        }

        public override Guid Id { get; set; }
        public override DateTime CommitDate { get; set; }
        public override Guid TaskId { get; set; }
        public TaskState OldState { get; set; }
        public TaskState State { get; set; }
        public override string CommentOfCommit { get; set; }
    }
}
