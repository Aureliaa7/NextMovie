import { Movie } from './movie.interface';

export interface MoviePagedRespose {
  currentPage: number;
  totalPages: number;
  movies: Movie[];
}
