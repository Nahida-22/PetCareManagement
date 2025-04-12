using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ApiClient
{
    private readonly HttpClient _httpClient = new();
    private const string BaseUrl = "https://localhost:5001/api/hashtable";

    public async Task<Dictionary<string, string>> LoadInitialDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<Dictionary<string, string>>($"{BaseUrl}") ?? new();
    }

    public async Task<bool> SaveChangesAsync(Dictionary<string, string> data)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/sync", data);
        return response.IsSuccessStatusCode;
    }
}