import { Alert, Button, Modal } from 'react-bootstrap';
import ImagesCarousel from '../../images-carousel/ImagesCarousel';
import Crew from '../crew/Crew';
import { Messages } from '../../../Messages';
import LoadingSpinner from '../../loading-spinner/LoadingSpinner';
import { Movie } from '../../../interfaces/movies/movie.interface';
import { MovieDetails } from '../../../interfaces/movies/movie-details.interface';
import MovieComments from '../movie-card/comments/movie-comments/MovieComments';

interface MovieDetailsProps {
  movie: Movie;
  errorMessage: string;
  isLoading: boolean;
  showModal: boolean;
  setShowModal: React.Dispatch<React.SetStateAction<boolean>>;
  movieDetails: MovieDetails | undefined;
}

function MovieDetailsModal(props: MovieDetailsProps) {
  const {
    movie,
    errorMessage,
    isLoading,
    movieDetails,
    showModal,
    setShowModal,
  } = props;

  const closeModal = () => {
    setShowModal(false);
  };
  return (
    <>
      <Modal show={showModal} onHide={closeModal} size="lg">
        <Modal.Header closeButton>
          <Modal.Title>{movie.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {isLoading ? (
            errorMessage ? (
              <Alert variant="danger">{errorMessage}</Alert>
            ) : (
              <LoadingSpinner />
            )
          ) : movieDetails ? (
            <>
              <ImagesCarousel
                imagesPaths={movieDetails?.backdropPaths}
                altString="Movie"
              />
              <h5>Overview:</h5>
              <p>{movie.overview}</p>
              <h5>Release Date:</h5>
              <p>{movie.releaseDate}</p>
              <h5>Genres:</h5>
              <p>{movie.genres.join(', ')}</p>
              <h5>Original Language:</h5>
              <p>{movie.originalLanguage}</p>

              <Crew crew={movieDetails?.crew} />
              <MovieComments
                comments={movieDetails?.comments}
                movieId={movie.id}
              />
            </>
          ) : (
            <p>{Messages.NoMovieDetails}</p>
          )}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={closeModal}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default MovieDetailsModal;
