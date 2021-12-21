using System;

namespace ReportApp.DAL.Entities.Commit
{
    public class TaskCommentCommit : AbstractCommit
    {
        public TaskCommentCommit()
        {
        }
        public TaskCommentCommit(Guid taskId, CommentEntity commentOfTask,  string commentOfCommit)
        {
            Id = Guid.NewGuid();
            CommitDate = DateTime.Now;
            TaskId = taskId;
            CommentOfTask = commentOfTask;
            CommentOfCommit = commentOfCommit;
        }

        public override Guid Id { get; set; }
        public override DateTime CommitDate { get; set; }
        public override Guid TaskId { get; set; }
        public  CommentEntity CommentOfTask { get; set; }
        public override string CommentOfCommit { get; set; }
    }
}
