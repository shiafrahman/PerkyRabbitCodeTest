using EmployeeCertificateManagement.API.Data;
using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCertificateManagement.API.Service.Repository
{
    public class UserRepository:IUser
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
             _context.SaveChanges();
             return user;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        
    }
}
