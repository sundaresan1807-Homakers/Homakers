using Homakers.Applications.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private IUtilitiesService _utilityServices;
        public UtilityController(IUtilitiesService utilityServices)
        {
            _utilityServices = utilityServices;
        }

        [HttpGet("GetDistrictsAsync")]
        public async Task<ActionResult> GetDistrictsAsync()
        {
            var districts = await _utilityServices.GetDistrictsAsync();
            return Ok(districts);
        }
    }
}
