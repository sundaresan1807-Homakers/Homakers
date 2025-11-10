using Homakers.Applications.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalsController : ControllerBase
    {
        private IProfessionalsService _professionalService;
        public ProfessionalsController(IProfessionalsService professionalService)
        {
            _professionalService = professionalService;
        }

        [HttpGet("GetProfessionalsAsync")]
        public async Task<ActionResult> GetProfessionalsAsync()
        {
            var customerList = await _professionalService.GetProfessionalsAsync();
            return Ok(customerList);
        }

        [HttpGet("GetProfessionalsByUsername")]
        public async Task<ActionResult> GetProfessionalsByUsername([FromQuery] string username)
        {
            var customer = await _professionalService.GetProfessionalsByUsername(username);
            return Ok(customer);
        }

        [HttpGet("GetProfessionalsByName")]
        public async Task<ActionResult> GetProfessionalsByName([FromQuery] string professionalName)
        {
            var customerList = await _professionalService.GetProfessionalsByName(professionalName);
            return Ok(customerList);
        }

        [HttpGet("ValidateProfessional")]
        public async Task<ActionResult> ValidateProfessional([FromQuery] string username, [FromQuery] string password)
        {
            var customerList = await _professionalService.ValidateProfessional(username, password);
            return Ok(customerList);
        }
    }
}
