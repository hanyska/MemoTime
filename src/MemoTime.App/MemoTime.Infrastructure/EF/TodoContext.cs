using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace MemoTime.Infrastructure.Ef
{
    public class TodoContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<Label> Labels { get; set; }
       
        public TodoContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>().HasMany(x => x.Tasks).WithOne(x => x.Project).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TodoTask>().HasOne(x => x.Label).WithMany(x => x.Tasks)
                .OnDelete(DeleteBehavior.SetNull);
            
            
        }
    }
}