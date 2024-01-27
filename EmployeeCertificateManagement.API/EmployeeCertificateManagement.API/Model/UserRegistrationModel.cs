using System.ComponentModel.DataAnnotations;

namespace EmployeeCertificateManagement.API.Model
{
    public class UserRegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)] 
        public string Password { get; set; }
    }
}
