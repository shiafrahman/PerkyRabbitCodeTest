using EmployeeCertificateManagement.API.Data;
using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCertificateManagement.API.Service.Repository
{
    public class DepartmentRepo:IDepartRepo
    {
        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartmentAsync(Department dept)
        {
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept != null)
            {
                _context.Departments.Remove(dept);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task UpdateDepartmentAsync(Department dept)
        {
            _context.Entry(dept).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
