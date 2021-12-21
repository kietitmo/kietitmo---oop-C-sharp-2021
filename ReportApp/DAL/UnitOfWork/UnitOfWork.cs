using ReportApp.DAL.Context;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;
using System;


namespace ReportApp.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ReportContext _context;
        public UnitOfWork(ReportContext context)
        {
            _context = context;

            EmployeeRepository = new EmployeeRepository(context);
            ReportRepository = new ReportRepository(context);
            TaskRepository = new TaskRepository(context);
            CommitRepository = new CommitRepository(context);
            CommentRepository = new CommentRepository(context);
        }

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IReportRepository ReportRepository { get; set; }
        public ITaskRepository TaskRepository { get; set; }
        public ICommitRepository CommitRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
