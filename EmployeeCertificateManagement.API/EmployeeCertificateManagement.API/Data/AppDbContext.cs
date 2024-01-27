using EmployeeCertificateManagement.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCertificateManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(p => p.Department).WithMany(c => c.Employees).HasForeignKey(p => p.DeptId);
            modelBuilder.Entity<Employee>().HasOne(p => p.Certificate).WithMany(s => s.Employees).HasForeignKey(p => p.CertificateId);
            SeedData(modelBuilder);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DeptName = "IT" },
                new Department { Id = 2, DeptName = "HR" },
                new Department { Id = 3, DeptName = "Finance" },
                new Department { Id = 4, DeptName = "Marketing" },
                new Department { Id = 5, DeptName = "Operations" }
            // Add more departments as needed
            );

            modelBuilder.Entity<Certificate>().HasData(
                new Certificate { Id = 1, date = DateTime.Now },
                new Certificate { Id = 2, date = DateTime.Now.AddDays(-1) },
                new Certificate { Id = 3, date = DateTime.Now.AddDays(-2) },
                new Certificate { Id = 4, date = DateTime.Now.AddDays(-3) },
                new Certificate { Id = 5, date = DateTime.Now.AddDays(-4) }
            // Add more certificates as needed
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, EmpName = "John Doe", Salary = 50000, DeptId = 1, CertificateId = 1 },
                new Employee { Id = 2, EmpName = "Jane Doe", Salary = 60000, DeptId = 2, CertificateId = 2 },
                new Employee { Id = 3, EmpName = "Bob Smith", Salary = 70000, DeptId = 3, CertificateId = 3 },
                new Employee { Id = 4, EmpName = "Alice Johnson", Salary = 55000, DeptId = 4, CertificateId = 4 },
                new Employee { Id = 5, EmpName = "Charlie Brown", Salary = 80000, DeptId = 5, CertificateId = 5 }
            // Add more employees as needed
            );
        }
    }
}
