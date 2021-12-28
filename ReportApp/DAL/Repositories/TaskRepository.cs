using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class TaskRepository : RepositoryGeneric<TaskEntity>, ITaskRepository
    {
        public TaskRepository() : base() { }
        public TaskRepository(ReportContext context) : base(context) { }
    }
}
