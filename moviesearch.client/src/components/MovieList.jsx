import React from 'react';
import { useStore } from '../store';
import MovieDetails from './MovieDetails';

const MovieList = () => {
    const { searchResults } = useStore();

    return (
        <div>
            <h2>Search Results</h2>
            <ul>
                {Array.isArray(searchResults) ? (
                    searchResults.map((movie) => (
                        <MovieDetails key={movie.imdbID || movie.title} movie={movie} />
                    ))
                ) : (
                    <MovieDetails key={searchResults.imdbID || searchResults.title} movie={searchResults} />
                )}
            </ul>
        </div>
    );
};


export default MovieList;
