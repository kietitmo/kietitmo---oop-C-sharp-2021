using ReportApp.DAL.Context;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Interfaces;

namespace ReportApp.DAL.Repositories
{
    public class CommentRepository : RepositoryGeneric<CommentEntity>, ICommentRepository
    {
        public CommentRepository() : base() { }
        public CommentRepository(ReportContext context) : base(context) { }
    }
}
