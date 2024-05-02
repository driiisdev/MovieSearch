using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MovieSearch.Server.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private List<string> _searchHistory = new List<string>();

        [HttpGet]
        public IActionResult GetHistory()
        {
            return Ok(_searchHistory);
        }

        [HttpPost]
        public IActionResult AddToHistory([FromBody] string searchQuery)
        {
            _searchHistory.Add(searchQuery);
            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult RemoveFromHistory(int index)
        {
            if (index < 0 || index >= _searchHistory.Count)
            {
                return BadRequest("Invalid index");
            }

            _searchHistory.RemoveAt(index);
            return Ok();
        }
    }
}
