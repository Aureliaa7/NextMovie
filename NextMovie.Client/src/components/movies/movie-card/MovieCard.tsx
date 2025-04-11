import { Button, Card } from 'react-bootstrap';
import { Messages } from '../../../Messages';

interface MovieCardProps {
  id: string;
  title: string;
  overview: string;
  backdropPath: string;
}

function MovieCard(props: MovieCardProps) {
  return (
    <Card className="h-100" style={{ width: '18rem' }}>
      <Card.Img
        variant="top"
        src={props.backdropPath}
        alt={`${props.title} Poster`}
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
          {props.title}
        </Card.Title>
        <Card.Text
          style={{
            height: '60px',
            overflow: 'hidden',
            textOverflow: 'ellipsis',
            whiteSpace: 'nowrap',
          }}
        >
          {props.overview ? props.overview : Messages.NoDescriptionAvailable}
        </Card.Text>
        <Button variant="primary">View More</Button>
      </Card.Body>
    </Card>
  );
}

export default MovieCard;
