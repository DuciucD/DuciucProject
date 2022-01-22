using Microsoft.EntityFrameworkCore;

namespace DuciucProject.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
    }
}
