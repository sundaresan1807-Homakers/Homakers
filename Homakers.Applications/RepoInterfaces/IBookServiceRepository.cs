using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.RepoInterfaces
{
    public interface IBookServiceRepository
    {
        public Task<List<BookService>> GetBookingServiceByCustomerId(Guid customerId);
        public Task<List<BookService>> GetBookingServiceByProfessionalsID(Guid professionalsID);
        public Task<BookService> BookServiceByCustomer(BookServiceDto bookService);
        public Task<BookService> GetBookingServiceByUniqueKey(BookServicesUniqueKeysDto bookService);
    }
}
