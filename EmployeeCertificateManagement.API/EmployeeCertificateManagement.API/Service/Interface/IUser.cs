using EmployeeCertificateManagement.Library.Domain;

namespace EmployeeCertificateManagement.API.Service.Interface
{
    public interface IUser
    {
        User AddUser(User user);
        User GetUserByUsername(string username);
    }
}
