using Microsoft.EntityFrameworkCore;
using PIMTool.Core.Domain.Entities;

namespace PIMTool.Database
{
    public class PimContext : DbContext
    {
        // TODO: Define your models
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        public PimContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Group>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(x => new { x.ProjectId, x.EmployeeId});
        }
    }
}