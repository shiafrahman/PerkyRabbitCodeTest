using EmployeeCertificateManagement.Library.Domain;

namespace EmployeeCertificateManagement.API.Service.Interface
{
    public interface IDepartRepo
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task UpdateDepartmentAsync(Department dept);
        Task<Department> AddDepartmentAsync(Department dept);
        Task DeleteDepartmentAsync(int id);
    }
}
