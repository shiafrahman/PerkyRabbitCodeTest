using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCertificateManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly  IDepartRepo _departRepository;

        public DepartmentController(IDepartRepo departRepository)
        {
            _departRepository = departRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            var dept = await _departRepository.GetDepartmentsAsync();
            return Ok(dept);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Getdptbyid(int id)
        {
            var dpt = await _departRepository.GetDepartmentByIdAsync(id);
            if (dpt == null)
            {
                return NotFound();
            }

            return Ok(dpt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department dpt)
        {
            if (id != dpt.Id)
            {
                return BadRequest();
            }

            await _departRepository.UpdateDepartmentAsync(dpt);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department dpt)
        {
            var createddpt = await _departRepository.AddDepartmentAsync(dpt);

            return CreatedAtAction("GetDepartment", new { id = createddpt.Id }, createddpt);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departRepository.DeleteDepartmentAsync(id);

            return NoContent();
        }
    }
}
