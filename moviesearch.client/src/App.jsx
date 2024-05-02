import React from 'react';
import SearchBar from './components/SearchBar';
import SearchHistory from './components/SearchHistory';
import MovieList from './components/MovieList';
import MovieDetails from './components/MovieDetails';
import { useStore } from './store';

function App() {
    const { fetchMovieDetails } = useStore();

    return (
        <div className="App">
            <SearchBar />
            <SearchHistory />
            <MovieList />
            {fetchMovieDetails && <MovieDetails />}
        </div>
    );
}

export default App;
