using Homakers.Applications.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult> GetCustomersAsync()
        {
            var customerList = await _customerService.GetCustomersAsync();
            return Ok(customerList);
        }

        [HttpGet("GetCustomerByUsername")]
        public async Task<ActionResult> GetCustomerByUsername([FromQuery] string username)
        {
            var customer = await _customerService.GetCustomerByUsername(username);
            return Ok(customer);
        }

        [HttpGet("GetCustomerByName")]
        public async Task<ActionResult> GetCustomerByName([FromQuery] string customerName)
        {
            var customerList = await _customerService.GetCustomerByName(customerName);
            return Ok(customerList);
        }

        [HttpGet("ValidateCustomer")]
        public async Task<ActionResult> ValidateCustomer([FromQuery] string username, [FromQuery] string password)
        {
            var customerList = await _customerService.ValidateCustomer(username, password);
            return Ok(customerList);
        }
    }
}
