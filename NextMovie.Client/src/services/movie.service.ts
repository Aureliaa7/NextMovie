import { MoviePagedRespose } from '../interfaces/movies/movie-paged-response.interface';
import { ApiService } from './api.service';

const getLatest = (): Promise<MoviePagedRespose> => {
  return ApiService.get('movies/latest');
};

export const MovieService = {
  getLatest,
};
