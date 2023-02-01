using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly CertificateService certificateService;

        public CertificateController(CertificateService certificateService)
        {
            this.certificateService = certificateService;
        }

        [HttpGet("/Cert/Get/{ID}")]
        public IActionResult Get(int id)
        {
            var cert = certificateService.GetService(id);
                return Ok(cert);
        }

        [HttpPost("/Cert/Add")]
        public IActionResult Add(CertificateDTO certificate)
        {
            if (ModelState.IsValid)
            {
                var cert = certificateService.AddService(certificate);
                return Ok(cert);
            }
            return BadRequest(ModelState);
        }
    }
}
