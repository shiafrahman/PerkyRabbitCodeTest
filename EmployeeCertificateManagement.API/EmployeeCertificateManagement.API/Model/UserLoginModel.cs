using System.ComponentModel.DataAnnotations;

namespace EmployeeCertificateManagement.API.Model
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
