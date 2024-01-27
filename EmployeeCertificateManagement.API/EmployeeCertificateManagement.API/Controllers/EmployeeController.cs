using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using EmployeeCertificateManagement.Library.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCertificateManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _empRepo;

        public EmployeeController(IEmployee empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee requestModel)
        {
            try
            {
                var emp = await _empRepo.CreateEmployeeAsync(requestModel.EmpName, requestModel.Salary, requestModel.DeptId, requestModel.CertificateId);
                return CreatedAtAction("GetEmployee", new { id = emp.Id }, emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee requestModel)
        {
            try
            {
                var emp = await _empRepo.UpdateEmployeeAsync(id, requestModel.EmpName, requestModel.Salary, requestModel.DeptId, requestModel.CertificateId);
                if (emp == null) 
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _empRepo.GetEmployeeByIdAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        [HttpGet]
        public async Task<ActionResult<List<CertificateDto>>> GetAllEmployee()
        {
            var emp = await _empRepo.GetAllEmployeeAsync();
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _empRepo.DeleteEmployeeAsync (id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
