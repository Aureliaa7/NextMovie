import { useEffect, useState } from 'react';
import { MoviePagedRespose } from '../../../interfaces/movies/movie-paged-response.interface';
import { Messages } from '../../../Messages';
import { MovieService } from '../../../services/movie.service';
import MovieList from '../movie-list/MovieList';
import { Alert } from 'react-bootstrap';
import LoadingSpinner from '../../loading-spinner/LoadingSpinner';
import SearchBar from '../../search-bar/SearchBar';

function LatestMovies() {
  const [moviesPagedResponse, setMovies] = useState<MoviePagedRespose | null>();
  const [errorMessage, setErrorMessage] = useState<string>('');
  const [isLoading, setIsLoading] = useState<boolean>(false);

  useEffect(() => {
    getLatestMovies();
  }, []);

  const getMovies = async (data: Promise<MoviePagedRespose>) => {
    try {
      setIsLoading(true);
      const response: MoviePagedRespose = await data;
      setMovies(response);
    } catch {
      setErrorMessage(Messages.MoviesRetrievalError);
      setMovies(null);
    }
    setIsLoading(false);
  };

  const getLatestMovies = () => {
    getMovies(MovieService.getLatest());
  };

  const searchMovies = (query: string) => {
    getMovies(MovieService.search({ query: query, page: 1 }));
  };

  return (
    <>
      <SearchBar onSearch={searchMovies} onReset={getLatestMovies} />
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
