import { useEffect, useState } from 'react';
import { MoviePagedRespose } from '../../../interfaces/movies/movie-paged-response.interface';
import { Messages } from '../../../Messages';
import { MovieService } from '../../../services/movie.service';
import MovieList from '../movie-list/MovieList';
import { Alert } from 'react-bootstrap';

function LatestMovies() {
  const [moviesPagedResponse, setMovies] = useState<MoviePagedRespose | null>();
  const [errorMessage, setErrorMessage] = useState<string>('');

  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchMovies = async () => {
    try {
      const response: MoviePagedRespose = await MovieService.getLatest();
      setMovies(response);
    } catch {
      setErrorMessage(Messages.MoviesRetrievalError);
      setMovies(null);
    }
  };

  return (
    <>
      {errorMessage ? (
        <Alert variant="danger">{errorMessage}</Alert>
      ) : (
        <MovieList
          movies={!moviesPagedResponse ? [] : moviesPagedResponse.movies}
        />
      )}
    </>
  );

  //TODO: use pagination
}

export default LatestMovies;
