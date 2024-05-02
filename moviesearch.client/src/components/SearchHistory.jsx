import React from 'react';
import { useStore } from '../store';

function SearchHistory() {
    const { searchHistory } = useStore();

    return (
        <div>
            <h2>Search History</h2>
            <ul>
                {searchHistory.map((query, index) => (
                    <li key={index}>{query}</li>
                ))}
            </ul>
        </div>
    );
}

export default SearchHistory;
