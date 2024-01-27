using Microsoft.AspNetCore.Mvc;

namespace EmployeeCertificateManagement.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
