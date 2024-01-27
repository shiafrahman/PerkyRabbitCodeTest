using EmployeeCertificateManagement.API.Data;
using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using EmployeeCertificateManagement.Library.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCertificateManagement.API.Service.Repository
{
    public class EmployeeRepository:IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(string name, decimal salary, int dptId, int certificateId)
        {
            var emp = new Employee
            {
                EmpName = name,
                Salary = salary,
                DeptId = dptId,
                CertificateId = certificateId
            };

            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            return emp;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                throw new ArgumentException("Employee not found");
            }

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CertificateDto>> GetAllEmployeeAsync()
        {
            var emp = await _context.Employees
                .Include(p => p.Department)
                .Include(p => p.Certificate)
                .Select(p => new CertificateDto
                {
                    Id = p.Id,
                    Name = p.EmpName,
                    Salary = p.Salary,
                    DeptId = p.Department.Id,
                    CertificationId = p.CertificateId,
                    DeptName = p.Department.DeptName,
                    date = p.Certificate.date
                })
                .ToListAsync();

            return emp;
        }

        public async Task<CertificateDto> GetEmployeeByIdAsync(int id)
        {
            var empDto = await _context.Employees
               .Where(p => p.Id == id)
               .Select(p => new CertificateDto
               {
                   Id = p.Id,
                   Name = p.EmpName,
                   Salary = p.Salary,
                   DeptId = p.Department.Id,
                   CertificationId = p.CertificateId,
                   DeptName = p.Department.DeptName,
                   date = p.Certificate.date
               })
               .SingleOrDefaultAsync();

            return empDto;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, string name, decimal salary, int dptId, int certificateId)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return null;
            }

            emp.EmpName = name;
            emp.Salary = salary;
            emp.DeptId = dptId;
            emp.CertificateId = certificateId;

            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();

            return emp;
        }
    }
}
