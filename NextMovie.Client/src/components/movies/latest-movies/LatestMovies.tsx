import { useEffect, useState } from 'react';
import { MoviePagedRespose } from '../../../interfaces/movies/movie-paged-response.interface';
import { Messages } from '../../../Messages';
import { MovieService } from '../../../services/movie.service';
import MovieList from '../movie-list/MovieList';
import { Alert } from 'react-bootstrap';
import LoadingSpinner from '../../loading-spinner/LoadingSpinner';

function LatestMovies() {
  const [moviesPagedResponse, setMovies] = useState<MoviePagedRespose | null>();
  const [errorMessage, setErrorMessage] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);

  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchMovies = async () => {
    try {
      setIsLoading(true);
      const response: MoviePagedRespose = await MovieService.getLatest();
      setMovies(response);
    } catch {
      setErrorMessage(Messages.MoviesRetrievalError);
      setMovies(null);
    }
    setIsLoading(false);
  };

  return (
    <>
      {isLoading ? (
        <LoadingSpinner />
      ) : errorMessage ? (
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
