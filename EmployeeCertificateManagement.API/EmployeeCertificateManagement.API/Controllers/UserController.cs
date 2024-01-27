using EmployeeCertificateManagement.API.Model;
using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.API.Service.Repository;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCertificateManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationModel registrationModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid registration data");
                }

                

                var newUser = new User
                {
                    Username = registrationModel.Username,
                    Email = registrationModel.Email,
                    Password = registrationModel.Password
                };

                _userRepository.AddUser(newUser);

                return Ok(new { Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid login data");
            }

            var user = _userRepository.GetUserByUsername(loginModel.Username);

            if (user == null || user.Password != loginModel.Password)
            {
                return Unauthorized("Invalid username or password");
            }

            

            return Ok(new { Message = "User login successfully" });
        }
    }
}
