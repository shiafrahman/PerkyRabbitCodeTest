using EmployeeCertificateManagement.Library.Domain;
using EmployeeCertificateManagement.Library.DTOs;

namespace EmployeeCertificateManagement.API.Service.Interface
{
    public interface IEmployee
    {
        Task<Employee> CreateEmployeeAsync(string name, decimal salary, int dptId, int certificateId);
        Task<Employee> UpdateEmployeeAsync(int id, string name, decimal salary, int dptId, int certificateId);
        Task<CertificateDto> GetEmployeeByIdAsync(int id);
        Task<List<CertificateDto>> GetAllEmployeeAsync();
        Task DeleteEmployeeAsync(int id);
    }
}
