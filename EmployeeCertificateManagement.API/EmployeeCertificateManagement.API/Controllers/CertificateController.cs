using EmployeeCertificateManagement.API.Service.Interface;
using EmployeeCertificateManagement.Library.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCertificateManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateRepo _cftRepository;

        public CertificateController(ICertificateRepo cftRepository)
        {
            _cftRepository = cftRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> GetCertificate()
        {
            var cft = await _cftRepository.GetCertificatesAsync();
            return Ok(cft);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> Getcftbyid(int id)
        {
            var cft = await _cftRepository.GetCertificateByIdAsync(id);
            if (cft == null)
            {
                return NotFound();
            }

            return Ok(cft);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(int id, Certificate cft)
        {
            if (id != cft.Id)
            {
                return BadRequest();
            }

            await _cftRepository.UpdateCertificateAsync(cft);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> PostCertificate(Certificate cft)
        {
            var createdcft = await _cftRepository.AddCertificateAsync(cft);

            return CreatedAtAction("GetCertificate", new { id = createdcft.Id }, createdcft);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            await _cftRepository.DeleteCertificateAsync(id);

            return NoContent();
        }



    }
}
