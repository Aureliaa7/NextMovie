import { Container } from 'react-bootstrap';
import classes from './Home.module.css';
import LatestMovies from '../../components/movies/latest-movies/LatestMovies';

function Home() {
  return (
    <Container className={`${classes.movies} mt-5`}>
      <LatestMovies />
    </Container>
  );
}

export default Home;
