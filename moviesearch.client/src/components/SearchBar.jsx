import React, { useState } from 'react';
import { useStore } from '../store';

function SearchBar() {

    const [searchTerm, setSearchTerm] = useState('');
    const { fetchSearchResults } = useStore();

    const handleSearch = async () => {
        console.log(searchTerm);
        await fetchSearchResults(searchTerm);
        console.log("done");
    };

    return (
        <div>
            <input
                type="text"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <button onClick={handleSearch}>Search</button>
        </div>
    );
}

export default SearchBar;
