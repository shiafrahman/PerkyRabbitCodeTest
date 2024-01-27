using EmployeeCertificateManagement.API.Data;
using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCertificateManagement.API.Service.Repository
{
    public class CertificateRepo:ICertificateRepo
    {
        private readonly AppDbContext _context;

        public CertificateRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Certificate> AddCertificateAsync(Certificate cft)
        {
            _context.Certificates.Add(cft);
            await _context.SaveChangesAsync();
            return cft;
        }

        public async Task DeleteCertificateAsync(int id)
        {
            var cft = await _context.Certificates.FindAsync(id);
            if (cft != null)
            {
                _context.Certificates.Remove(cft);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Certificate> GetCertificateByIdAsync(int id)
        {
            return await _context.Certificates.FindAsync(id);
        }

        public async Task<IEnumerable<Certificate>> GetCertificatesAsync()
        {
            return await _context.Certificates.ToListAsync();
        }

        public async Task UpdateCertificateAsync(Certificate cft)
        {
            _context.Entry(cft).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
