using Homakers.Domain;
using Homakers.Domain.DataModels;
using Homakers.Applications.Repositories.RepoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Homakers.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        HomakerContext _dbContext;
        public CustomersRepository(HomakerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customers>> GetCustomersAsync()
        {
            List<Customers> customerList = new List<Customers>();
            try
            {
                customerList = await _dbContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerList;
        }

        public async Task<Customers?> GetCustomerByUsername(string username)
        {
            Customers? customer = new Customers();
            try
            {
                customer = await _dbContext.Customers.Where(cus => cus.Username == username).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customer;
        }

        public async Task<List<Customers>> GetCustomerByName(string customerName)
        {
            List<Customers> customerList = new List<Customers>();
            try
            {
                customerList = await _dbContext.Customers.Where(cus => cus.Name.Contains(customerName)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerList;
        }

        public async Task<Customers?> ValidateCustomer(string username, string password)
        {
            Customers? customer = new Customers();
            try
            {
                customer = await _dbContext.Customers.Where(cus => cus.Username == username && cus.Password == password).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customer;
        }
    }
}
