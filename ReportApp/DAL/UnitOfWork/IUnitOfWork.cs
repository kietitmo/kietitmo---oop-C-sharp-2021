using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; set; }
        IReportRepository ReportRepository { get; set; }
        ITaskRepository TaskRepository { get; set; }
        ICommitRepository CommitRepository { get; set; }
        ICommentRepository CommentRepository { get; set; }
    }
}
