using Homakers.Applications.DTOs;
using System.Text.Json;

namespace Homakers.Sevices
{
    public class UIProfessionsServices
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };
        private string? apiAddress = GlobalConstants.BaseAPIAddress;
        public UIProfessionsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProfessionsDto>> GetProfessionsAsync()
        {
            try
            {
                var url = $"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/Profession/GetProfessionsAsync";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionsAsync: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionsAsync: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionsAsync: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionsAsync: {ex.Message}");
                throw;
            }
        }
        public async Task<List<ProfessionsDto>> GetProfessionsByName(string name)
        {
            try
            {
                var url = $"https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/api/Profession/GetProfessionsByUsername?name={name}";
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"HTTP error in GetProfessionsByName: StatusCode={response.StatusCode}, Body={responseBody}");
                    throw new HttpRequestException($"Request failed with status {response.StatusCode}");
                }
                try
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<List<ProfessionsDto>>(responseBody, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return result;
                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.Error.WriteLine($"JSON error in GetProfessionsByName: {ex.Message}\nRaw response: {responseBody}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.Error.WriteLine($"HTTP request error in GetProfessionsByName: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetProfessionsByName: {ex.Message}");
                throw;
            }
        }
    }
}
