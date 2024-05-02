import React from 'react';

function MovieDetails({ movie }) {
    console.log(movie)
    if (!movie) {
        return <div>No movie selected</div>;
    }

    return (
        <div>
            <h2>Movie Details</h2>
            <div>
                <img src={movie.Poster} alt={movie.Title} />
                <h3>{movie.Title}</h3>
                <p>{movie.Plot}</p>
                <p>IMDB Rating: {movie.imdbRating}</p>
            </div>
        </div>
    );
}

export default MovieDetails;
