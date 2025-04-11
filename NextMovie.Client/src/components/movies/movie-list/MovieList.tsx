import { Alert, Col, Row } from 'react-bootstrap';
import { Movie } from '../../../interfaces/movies/movie.interface';
import MovieCard from '../movie-card/MovieCard';
import { Messages } from '../../../Messages';

interface MovieListProps {
  movies: Movie[];
}

function MovieList(props: MovieListProps) {
  return (
    <>
      {props.movies.length == 0 ? (
        <Alert variant="warn">{Messages.NoMoviesInfo}</Alert>
      ) : (
        <Row className="g-4 justify-content-center">
          {props.movies.map((x) => {
            return (
              <Col className="g-1" key={x.id} xs={12} sm={6} md={4} lg={3}>
                <MovieCard movie={x} />
              </Col>
            );
          })}
        </Row>
      )}
    </>
  );
}

export default MovieList;
