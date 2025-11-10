using Homakers.Domain.DataModels;

namespace Homakers.Applications.Repositories.RepoInterfaces
{
    public interface ICustomersRepository
    {
        public Task<List<Customers>> GetCustomersAsync();
        public Task<Customers?> GetCustomerByUsername(string username);
        public Task<List<Customers>> GetCustomerByName(string customerName);
        public Task<Customers?> ValidateCustomer(string username, string password);
    }
}
