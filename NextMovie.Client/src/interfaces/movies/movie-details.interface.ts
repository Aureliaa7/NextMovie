import { PersonCrew } from './person-crew.interface';

export interface MovieDetails {
  id: string;
  backdropPaths: string[];
  crew: PersonCrew[];
}
