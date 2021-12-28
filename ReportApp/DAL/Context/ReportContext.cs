using Microsoft.EntityFrameworkCore;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Commit;
namespace ReportApp.DAL.Context
{
    public class ReportContext : DbContext
    {
        public ReportContext() { }

        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<AbstractCommit> Commits { get; set; }
        ////public DbSet<TaskCommentCommit> TaskCommentCommits { get; set; }
        ////public DbSet<TaskDescriptionCommit> TaskDescriptionCommits { get; set; }
        ////public DbSet<TaskEmployeeIdCommit> TaskEmployeeCommits { get; set; }
        ////public DbSet<TaskStateCommit> TaskStateCommits { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=KIET-TOT-BUNG;Initial Catalog=reportappdb;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbstractCommit>()
                .ToTable("Commit")
                .HasDiscriminator<string>("CommitType")
                .HasValue<TaskCommentCommit>("TaskCommentCommit")
                .HasValue<TaskDescriptionCommit>("TaskDescriptionCommit")
                .HasValue<TaskEmployeeIdCommit>("TaskEmployeeIdCommit")
                .HasValue<TaskStateCommit>("TaskStateCommit");
        }
    }
}
