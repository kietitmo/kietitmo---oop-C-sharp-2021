using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class EmployeeRepository : RepositoryGeneric<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository() : base() { }
        public EmployeeRepository(ReportContext context) : base(context) { }
    }
}
