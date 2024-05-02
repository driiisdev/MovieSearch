using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieSearch.Server.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public SearchController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> SearchMovie(string title)
        {
            try
            {
                var baseUrl = _configuration["OMDbApi:BaseUrl"];
                var apiKey = _configuration["OMDbApi:Key"];

                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync($"{baseUrl}?apikey={apiKey}&t={title}");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
