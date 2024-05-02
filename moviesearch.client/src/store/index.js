import { create } from 'zustand';
import axios from 'axios';

const initialState = {
    searchResults: [],
    selectedMovie: null,
    searchHistory: [],
};

const fetchSearchResults = async (title, setState) => {
    try {
        const response = await axios.get(`https://localhost:7151/api/search/${title}`);
        const movieData = response.data;
        const SearchResults = Array.isArray(movieData) ? movieData : [movieData];
        setState((state) => ({ ...state, searchResults: SearchResults }));
    } catch (error) {
        console.error('Error fetching search results:', error);
    }
};

const updateSearchHistory = (title, setState) => {
    const timestamp = Date.now();
    setState((state) => ({
        ...state,
        searchHistory: [
            { title, timestamp },
            ...state.searchHistory.slice(0, 4), // Keep latest 5 searches
        ],
    }));
};

const fetchMovieDetails = async (title, setState) => {
    try {
        const response = await axios.get(`https://localhost:7151/api/search/${title}`);
        const movieData = response.data;
        const SearchResults = Array.isArray(movieData) ? movieData : [movieData];
        setState((state) => ({ ...state, searchResults: SearchResults }));
    } catch (error) {
        console.error('Error fetching movie details:', error);
        // Handle errors gracefully (e.g., display error message)
    }
};

export const useStore = create((set) => ({
    ...initialState,
    fetchSearchResults: (title) => fetchSearchResults(title, set),
    updateSearchHistory: (title) => updateSearchHistory(title, set),
    fetchMovieDetails: (title) => fetchMovieDetails(title, set),
}));
