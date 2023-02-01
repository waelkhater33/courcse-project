using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCertificateController : ControllerBase
    {
        private readonly StudentCertificateService studentCertificateService;

        public StudentCertificateController(StudentCertificateService studentCertificateService)
        {
            this.studentCertificateService = studentCertificateService;
        }

        [HttpGet]
        public IActionResult GetByID(string id)
        {
            var cert = studentCertificateService.GetService(id);
            return Ok(cert);
        }

        [HttpPost]
        public IActionResult AddCert(UserCertDTO stdC)
        {
            if (ModelState.IsValid)
            {
                var stdCert = studentCertificateService.AddService(stdC);
                return Ok(stdCert);
            }
            return BadRequest(ModelState);
        }
    }
}
