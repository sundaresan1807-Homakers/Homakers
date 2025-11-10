using Homakers.Applications.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private IProfessionService _professionService;
        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }

        [HttpGet("GetProfessionsAsync")]
        public async Task<ActionResult> GetProfessionsAsync()
        {
            var customerList = await _professionService.GetProfessionsAsync();
            return Ok(customerList);
        }

        [HttpGet("GetProfessionsByName")]
        public async Task<ActionResult> GetProfessionsByName([FromQuery] string professionName)
        {
            var customer = await _professionService.GetProfessionsByName(professionName);
            return Ok(customer);
        }
    }
}
