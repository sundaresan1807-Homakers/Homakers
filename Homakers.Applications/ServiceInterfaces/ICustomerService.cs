using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;

namespace Homakers.Applications.ServiceInterfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerDto>> GetCustomersAsync();
        public Task<CustomerDto?> GetCustomerByUsername(string username);
        public Task<List<CustomerDto>> GetCustomerByName(string customerName);
        public Task<CustomerDto?> ValidateCustomer(string username, string password);
    }
}
