using System.Net.Http.Json;
using PawfectCareLtd.Models;

namespace PawfectCareLtd.Services
{
    /// <summary>
    /// This service handles all API calls related to veterinarians.
    /// It communicates with the backend API to fetch vet data.
    /// </summary>
   
    public class VetService
    {
        // HTTP client to send requests to the API.
        private readonly HttpClient _httpClient;

        // Constructor to inject HttpClient dependency.
        public VetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches all vets from the API.
        /// </summary>
        /// <returns>A list of Vet objects if successful; otherwise, an empty list.</returns>
        public async Task<List<Vet>> GetAllVets()
        {
            try
            {
                // Send a GET request to the API endpoint "api/vet".
                var response = await _httpClient.GetAsync("api/vet");

                // Check if the request was successful.
                if (!response.IsSuccessStatusCode)
                {
                    // Log error if the API returns a failure status code.
                    Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

                    // Return an empty list 
                    return new List<Vet>();
                }

                // Deserialize the JSON response into a list of Vet objects.
                return await response.Content.ReadFromJsonAsync<List<Vet>>() ?? new List<Vet>();
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the API call.
                Console.WriteLine($"Exception: {ex.Message}");

                // Return an empty list to handle errors gracefully.
                return new List<Vet>();
            }
        }

    }
}
