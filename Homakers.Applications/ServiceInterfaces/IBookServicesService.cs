using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;

namespace Homakers.Applications.ServiceInterfaces
{
    public interface IBookServicesService
    {
        public Task<List<BookServiceDto>> GetBookingServiceByCustomerId(string customerId);
        public Task<List<BookServiceDto>> GetBookingServiceByProfessionalsID(string professionalsID);
        public Task<BookServiceDto> BookServiceByCustomer(BookServiceDto bookService);
        public Task<BookServiceDto> GetBookingServiceByUniqueKey(BookServicesUniqueKeysDto bookServiceDto);
        public Task<BookServiceDto> AcceptServiceByProfessional(BookServiceDto bookServiceDto);
        public Task<BookServiceDto> RejectServiceByProfessional(BookServiceDto bookServiceDto);
    }
}
