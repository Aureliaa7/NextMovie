import { MovieDetails } from '../interfaces/movies/movie-details.interface';
import { MoviePagedRespose } from '../interfaces/movies/movie-paged-response.interface';
import { SearchDetails } from '../interfaces/movies/search-details.interface';
import { ApiService } from './api.service';

const getLatest = (): Promise<MoviePagedRespose> => {
  return ApiService.get('movies/latest');
};

const getDetails = (id: string): Promise<MovieDetails> => {
  return ApiService.get(`movies/details/${id}`);
};

const search = (data: SearchDetails): Promise<MoviePagedRespose> => {
  return ApiService.post('movies/search', data);
};

export const MovieService = {
  getLatest,
  getDetails,
  search,
};
