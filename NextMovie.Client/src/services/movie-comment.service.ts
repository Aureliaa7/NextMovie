import { MovieCommentCreation } from '../interfaces/movies/movie-comment-creation.interface';
import { ApiService } from './api.service';

const save = (data: MovieCommentCreation) => {
  return ApiService.post('moviecomments', data);
};

export const MovieCommentService = {
  save,
};
