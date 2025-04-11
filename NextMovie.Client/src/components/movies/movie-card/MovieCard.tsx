import { Button, Card } from 'react-bootstrap';
import { Messages } from '../../../Messages';
import { useState } from 'react';
import { MovieService } from '../../../services/movie.service';
import { MovieDetails } from '../../../interfaces/movies/movie-details.interface';
import { Movie } from '../../../interfaces/movies/movie.interface';
import MovieDetailsModal from '../movie-details-modal/MovieDetailsModal';

interface MovieCardProps {
  movie: Movie;
}

function MovieCard(props: MovieCardProps) {
  const { movie } = props;
  const [areDetailsLoading, setAreDetailsLoading] = useState<boolean>(false);
  const [errorMessage, setErrorMessage] = useState<string>('');
  const [additionalMovieDetails, setAdditionalMovieDetails] =
    useState<MovieDetails>();
  const [showMovieDetailsModal, setShowMovieDetailsModal] =
    useState<boolean>(false);

  const getDetails = async () => {
    setShowMovieDetailsModal(true);
    setAreDetailsLoading(true);
    setErrorMessage('');
    try {
      const response: MovieDetails = await MovieService.getDetails(movie.id);
      setAdditionalMovieDetails(response);
    } catch {
      setErrorMessage(Messages.GetMovieDetailsError);
    }
    setAreDetailsLoading(false);
  };
  return (
    <>
      <Card className="h-100" style={{ width: '18rem' }}>
        <Card.Img
          variant="top"
          src={movie.backdropPath}
          alt={`${movie.title} Poster`}
        />
        <Card.Body>
          <Card.Title
            style={{
              overflow: 'hidden',
              textOverflow: 'ellipsis',
              whiteSpace: 'nowrap',
              height: '40px',
            }}
          >
            {movie.title}
          </Card.Title>
          <Card.Text
            style={{
              height: '60px',
              overflow: 'hidden',
              textOverflow: 'ellipsis',
              whiteSpace: 'nowrap',
            }}
          >
            {movie.overview ? movie.overview : Messages.NoDescriptionAvailable}
          </Card.Text>
          <Button onClick={getDetails} variant="primary" className="me-2">
            <i
              className="bi bi-info-circle"
              style={{ fontSize: '20px', marginRight: '8px' }}
            ></i>
            See More
          </Button>
        </Card.Body>
      </Card>

      <MovieDetailsModal
        movie={props.movie}
        errorMessage={errorMessage}
        isLoading={areDetailsLoading}
        showModal={showMovieDetailsModal}
        setShowModal={setShowMovieDetailsModal}
        movieDetails={additionalMovieDetails}
      />
    </>
  );
}

export default MovieCard;
