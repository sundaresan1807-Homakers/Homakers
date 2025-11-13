using Homakers.Applications.DTOs;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Domain.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookServiceController : ControllerBase
    {
        private IBookServicesService _bookServicesService;
        public BookServiceController(IBookServicesService bookServicesService)
        {
            _bookServicesService = bookServicesService;
        }

        [HttpGet("GetBookingServiceByCustomerId")]
        public async Task<ActionResult> GetBookingServiceByCustomerId([FromQuery] string customerId)
        {
            var customer = await _bookServicesService.GetBookingServiceByCustomerId(customerId);
            return Ok(customer);
        }

        [HttpGet("GetBookingServiceByProfessionalsID")]
        public async Task<ActionResult> GetBookingServiceByProfessionalsID([FromQuery] string professionalId)
        {
            var customer = await _bookServicesService.GetBookingServiceByProfessionalsID(professionalId);
            return Ok(customer);
        }

        [HttpPost("BookServiceByCustomer")]
        public async Task<ActionResult> BookServiceByCustomer([FromBody] BookServiceDto bookService)
        {
            var customerBookedService = await _bookServicesService.BookServiceByCustomer(bookService);
            return Ok(customerBookedService);
        }

        [HttpPost("GetBookingServiceByUniqueKey")]
        public async Task<ActionResult> GetBookingServiceByUniqueKey([FromBody] BookServicesUniqueKeysDto bookService)
        {
            var customerBookedService = await _bookServicesService.GetBookingServiceByUniqueKey(bookService);
            return Ok(customerBookedService);
        }
    }
}
