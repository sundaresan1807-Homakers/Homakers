using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homakers.Sevices
{
    public class UIProfessionalService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };

        private string? apiAddress = GlobalConstants.BaseAPIAddress;

        public UIProfessionalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProfessionalsDto>> GetProfessionalsSummary
            (
            int pageNumber = 1
             , int pageSize = 20
             , string? districtName = null
             , string? professionName = null
             , string? professionalName = null
            )
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsSummary?pageNumber={pageNumber}&pageSize={pageSize}&districtName={districtName}&professionName={professionName}&professionalName={professionalName}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionalsAsync: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionalsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionalsAsync: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsAsync: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsAsync: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ProfessionalsDto>> GetProfessionalsAsync()
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsAsync";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionalsAsync: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionalsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionalsAsync: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsAsync: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfessionalsDto?> GetProfessionalsByUsername(string username)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsByUsername?username={username}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                ProfessionalsDto? result = new ProfessionalsDto();
                if (responseBody != null)
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.Error.WriteLine($"HTTP error in GetProfessionalsByUsername: StatusCode={response.StatusCode}, Body={responseBody}");
                        throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                    }
                    try
                    {
                        result = JsonSerializer.Deserialize<ProfessionalsDto?>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result;
                    }
                    catch (JsonException ex)
                    {
                        Console.Error.WriteLine($"JSON error in GetProfessionalsByUsername: {ex.Message}\nRaw response: {responseBody}");
                        throw;
                    }
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsByUsername: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsByUsername: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProfessionalsDto>> GetProfessionalsByName(string professionalName)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsByName?professionalName={professionalName}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionalsByName: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionalsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionalsByName: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsByName: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsByName: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfessionalsDto?> ValidateProfessional(string username, string password)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/ValidateProfessional?username={username}&password={password}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                ProfessionalsDto? result = new ProfessionalsDto();
                if (responseBody != "")
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.Error.WriteLine($"HTTP error in ValidateProfessional: StatusCode={response.StatusCode}, Body={responseBody}");
                        throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                    }
                    try
                    {
                        result = JsonSerializer.Deserialize<ProfessionalsDto?>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        return result;
                    }
                    catch (JsonException ex)
                    {
                        Console.Error.WriteLine($"JSON error in ValidateProfessional: {ex.Message}\nRaw response: {responseBody}");
                        throw;
                    }
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in ValidateProfessional: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in ValidateProfessional: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProfessionalsDto>> GetProfessionalsByProfessionID(string professionID)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsByProfessionID?professionID={professionID}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionalsByProfessionID: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionalsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionalsByProfessionID: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsByProfessionID: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsByProfessionID: {ex.Message}");
                throw;
            }
        }

        public async Task<ProfessionalsDto> GetProfessionalsByProfessionalID(string professionalID)
        {
            try
            {
                var url = GlobalConstants.BaseAPIAddress+$"/api/Professionals/GetProfessionalsByProfessionalID?professionalID={professionalID}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionalsByProfessionalID: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<ProfessionalsDto>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionalsByProfessionalID: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionalsByProfessionalID: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionalsByProfessionalID: {ex.Message}");
                throw;
            }
        }
    }
}
