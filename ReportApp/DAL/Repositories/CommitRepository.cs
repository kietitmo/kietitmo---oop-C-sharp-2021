using ReportApp.DAL.Context;
using ReportApp.DAL.Entities.Commit;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class CommitRepository : RepositoryGeneric<AbstractCommit>, ICommitRepository
    {
        public CommitRepository() : base() { }
        public CommitRepository(ReportContext context) : base(context) { }
    }
}
