using EmployeeCertificateManagement.Library.Domain;

namespace EmployeeCertificateManagement.API.Service.Interface
{
    public interface ICertificateRepo
    {
        Task<IEnumerable<Certificate>> GetCertificatesAsync();
        Task<Certificate> GetCertificateByIdAsync(int id);
        Task UpdateCertificateAsync(Certificate cft);
        Task<Certificate> AddCertificateAsync(Certificate cft);
        Task DeleteCertificateAsync(int id);
    }
}
