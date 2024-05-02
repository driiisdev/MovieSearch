using System;
using System.Collections.Generic;

namespace MovieSearch.Server.Services
{
    public class SearchHistoryService
    {
        private List<string> _searchHistory = new List<string>();

        public IEnumerable<string> GetSearchHistory()
        {
            return _searchHistory;
        }

        public void AddToHistory(string searchQuery)
        {
            _searchHistory.Add(searchQuery);
        }

        public void RemoveFromHistory(int index)
        {
            if (index < 0 || index >= _searchHistory.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
            }

            _searchHistory.RemoveAt(index);
        }
    }
}
