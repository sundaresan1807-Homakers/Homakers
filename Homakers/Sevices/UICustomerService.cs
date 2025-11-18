using Homakers.Applications.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homakers.Sevices
{
    public class UICustomerService
    {

        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };
        private string? apiAddress = GlobalConstants.BaseAPIAddress;
        public UICustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Customer/GetCustomers";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetCustomersAsync: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<CustomerDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetCustomersAsync: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetCustomersAsync: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetCustomersAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<CustomerDto?> GetCustomerByUsername(string username)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Customer/GetCustomerByUsername?username={username}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                CustomerDto? result = new CustomerDto();
                if (responseBody != null)
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.Error.WriteLine($"HTTP error in GetCustomerByUsername: StatusCode={response.StatusCode}, Body={responseBody}");
                        throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                    }
                    try
                    {
                        result = JsonSerializer.Deserialize<CustomerDto?>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result;
                    }
                    catch (JsonException ex)
                    {
                        Console.Error.WriteLine($"JSON error in GetCustomerByUsername: {ex.Message}\nRaw response: {responseBody}");
                        throw;
                    }
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetCustomerByUsername: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetCustomerByUsername: {ex.Message}");
                throw;
            }
        }

        public async Task<List<CustomerDto>> GetCustomerByName(string customerName)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Customer/GetCustomerByName?customerName={customerName}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetCustomerByName: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<CustomerDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetCustomerByName: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetCustomerByName: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetCustomerByName: {ex.Message}");
                throw;
            }
        }

        public async Task<CustomerDto?> ValidateCustomer(string username, string password)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Customer/ValidateCustomer?username={username}&password={password}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                CustomerDto? result = new CustomerDto();
                if (responseBody != "")
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.Error.WriteLine($"HTTP error in ValidateCustomer: StatusCode={response.StatusCode}, Body={responseBody}");
                        throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                    }
                    try
                    {
                        result = JsonSerializer.Deserialize<CustomerDto?>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result;
                    }
                    catch (JsonException ex)
                    {
                        Console.Error.WriteLine($"JSON error in ValidateCustomer: {ex.Message}\nRaw response: {responseBody}");
                        throw;
                    }
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in ValidateCustomer: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in ValidateCustomer: {ex.Message}");
                throw;
            }
        }
    }
}
