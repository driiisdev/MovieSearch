using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MovieSearch.Server.Services
{
    public class OMDbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly string _apiKey;

        public OMDbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["OMDbApi:BaseUrl"];
            _apiKey = configuration["OMDbApi:Key"];
        }

        public async Task<string> SearchMovieAsync(string title)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}?apikey={_apiKey}&t={title}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to search movie: {ex.Message}");
            }
        }
    }
}
