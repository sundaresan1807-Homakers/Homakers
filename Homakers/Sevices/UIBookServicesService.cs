using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homakers.Sevices
{
    public class UIBookServicesService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };


        public UIBookServicesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookServiceDto>> GetBookingServiceByCustomerId(string customerId)
        {
            try
            {
                var url = $"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/BookService/GetBookingServiceByCustomerId?customerId={customerId}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetBookingServiceByCustomerId: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<BookServiceDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetBookingServiceByCustomerId: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetBookingServiceByCustomerId: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetBookingServiceByCustomerId: {ex.Message}");
                throw;
            }
        }

        public async Task<List<BookServiceDto>> GetBookingServiceByProfessionalsID(string professionalId)
        {
            try
            {
                var url = $"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/BookService/GetBookingServiceByProfessionalsID?professionalId={professionalId}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetBookingServiceByProfessionalsID: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<BookServiceDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetBookingServiceByProfessionalsID: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetBookingServiceByProfessionalsID: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetBookingServiceByProfessionalsID: {ex.Message}");
                throw;
            }
        }
        public async Task<BookServiceDto?> GetBookingServiceByUniqueKey(BookServicesUniqueKeysDto bookServiceDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/BookService/GetBookingServiceByUniqueKey", bookServiceDto);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetBookingServiceByUniqueKey: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<BookServiceDto>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetBookingServiceByUniqueKey: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetBookingServiceByUniqueKey: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetBookingServiceByUniqueKey: {ex.Message}");
                throw;
            }
        }


        public async Task<BookServiceDto?> BookServiceByCustomer(BookServiceDto bookServiceDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/BookService/BookServiceByCustomer", bookServiceDto);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetBookingServiceByProfessionalsID: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<BookServiceDto>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetBookingServiceByProfessionalsID: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetBookingServiceByProfessionalsID: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetBookingServiceByProfessionalsID: {ex.Message}");
                throw;
            }
        }
    }
}
