import { Card, ListGroup } from 'react-bootstrap';
import { MovieComment } from '../../../../../interfaces/movies/movie-comment.interface';
import AddMovieCommentModal from '../add-movie-comment/AddMovieComment';
import useAuth from '../../../../../hooks/use-auth.hook';
import { AuthContextData } from '../../../../../interfaces/auth-context-data.interface';

interface MovieCommentsProps {
  comments: MovieComment[];
  movieId: string;
}

function MovieComments({ comments, movieId }: MovieCommentsProps) {
  const authState: AuthContextData = useAuth();

  return (
    <>
      <Card style={{ maxHeight: '300px', overflowY: 'auto' }}>
        <ListGroup variant="flush">
          {comments.map((comment) => (
            <ListGroup.Item key={comment.id}>
              <div className="fw-bold">{comment.authorFullName}</div>
              <small className="text-muted">{comment.createdAt}</small>
              <div>{comment.comment}</div>
            </ListGroup.Item>
          ))}
        </ListGroup>
        {authState.isAuthenticated && (
          <AddMovieCommentModal movieId={movieId} />
        )}
      </Card>
    </>
  );
}

export default MovieComments;
