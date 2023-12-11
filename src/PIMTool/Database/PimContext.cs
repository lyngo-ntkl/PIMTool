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
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Visa = "VN", FirstName = "Ly", LastName = "Ngô", BirthDate = new DateTime(2002,4,4)},
                new Employee { Id = 2, Visa = "VN", FirstName = "Linh", LastName = "Nguyễn", BirthDate = new DateTime(2002,4,12)},
                new Employee { Id = 3, Visa = "VN", FirstName = "Lan", LastName = "Trần", BirthDate = new DateTime(1994,12,4)},
                new Employee { Id = 4, Visa = "VN", FirstName = "Duy", LastName = "Hoàng", BirthDate = new DateTime(1996,9,20)},
                new Employee { Id = 5, Visa = "VN", FirstName = "Huy", LastName = "Phan", BirthDate = new DateTime(1997,3,20)},
                new Employee { Id = 6, Visa = "VN", FirstName = "Minh", LastName = "Doãn", BirthDate = new DateTime(2000,11,7)},
                new Employee { Id = 7, Visa = "VN", FirstName = "Quang", LastName = "Tô", BirthDate = new DateTime(2001,9,15)},
                new Employee { Id = 8, Visa = "VN", FirstName = "Trường", LastName = "Phạm", BirthDate = new DateTime(1999,8,12)},
                new Employee { Id = 9, Visa = "VN", FirstName = "Tiến", LastName = "Vũ", BirthDate = new DateTime(1998,3,28)},
                new Employee { Id = 10, Visa = "VN", FirstName = "Thịnh", LastName = "Đinh", BirthDate = new DateTime(2004,5,8)}
                );
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, GroupLeaderId = 9},
                new Group { Id = 2, GroupLeaderId = 8},
                new Group { Id = 3, GroupLeaderId = 7},
                new Group { Id = 4, GroupLeaderId = 6},
                new Group { Id = 5, GroupLeaderId = 5}
            );
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(x => new { x.ProjectId, x.EmployeeId});
        }
    }
}