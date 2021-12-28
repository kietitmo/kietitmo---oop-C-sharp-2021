using System;

namespace ReportApp.DAL.Entities.Commit
{
    public class TaskDescriptionCommit : AbstractCommit
    {
        public TaskDescriptionCommit()
        {
        }
        public TaskDescriptionCommit(Guid taskId, string descriptionOfTask, string commentOfCommit)
        {
            Id = Guid.NewGuid();
            CommitDate = DateTime.Now;
            TaskId = taskId;
            OldDescriptionOfTask = DescriptionOfTask;
            DescriptionOfTask = descriptionOfTask;
            CommentOfCommit = commentOfCommit;
        }

        public override Guid Id { get; set; }
        public override DateTime CommitDate { get; set; }
        public override Guid TaskId { get; set; }
        public string OldDescriptionOfTask { get; set; }
        public string DescriptionOfTask { get; set; }
        public override string CommentOfCommit { get; set; }
        }
}
