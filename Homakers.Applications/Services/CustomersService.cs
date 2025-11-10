using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Applications.Repositories.RepoInterfaces;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications.Services
{
    public class CustomersService : ICustomerService
    {
        private ICustomersRepository _customersRepository;
        private IMapper _mapper;
        public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            List<CustomerDto> customerDtoList = new List<CustomerDto>();
            List<Customers> customerList = new List<Customers>();
            try
            {
                customerList = await _customersRepository.GetCustomersAsync();
                customerDtoList = _mapper.Map<List<CustomerDto>>(customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerDtoList;
        }
        public async Task<CustomerDto?> GetCustomerByUsername(string username)
        {
            CustomerDto? customerDto = new CustomerDto();
            Customers? customer = new Customers();
            try
            {
                customer = await _customersRepository.GetCustomerByUsername(username);
                customerDto = _mapper.Map<CustomerDto?>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerDto;
        }
        public async Task<List<CustomerDto>> GetCustomerByName(string customerName)
        {
            List<CustomerDto> customerDtoList = new List<CustomerDto>();
            List<Customers> customerList = new List<Customers>();
            try
            {
                customerList = await _customersRepository.GetCustomerByName(customerName);
                customerDtoList = _mapper.Map<List<CustomerDto>>(customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerDtoList;
        }
        public async Task<CustomerDto?> ValidateCustomer(string username, string password)
        {
            CustomerDto? customerDto = new CustomerDto();
            Customers? customer = new Customers();
            try
            {
                customer = await _customersRepository.ValidateCustomer(username, password);
                customerDto = _mapper.Map<CustomerDto?>(customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return customerDto;
        }
    }
}
