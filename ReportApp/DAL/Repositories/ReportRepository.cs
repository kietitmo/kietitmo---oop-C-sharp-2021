using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class ReportRepository : RepositoryGeneric<ReportEntity>, IReportRepository
    {
        public ReportRepository() : base() { }
        public ReportRepository(ReportContext context) : base(context) { }
    }
}
