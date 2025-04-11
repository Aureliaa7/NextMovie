import { MovieComment } from './movie-comment.interface';
import { PersonCrew } from './person-crew.interface';

export interface MovieDetails {
  id: string;
  backdropPaths: string[];
  crew: PersonCrew[];
  comments: MovieComment[];
}
