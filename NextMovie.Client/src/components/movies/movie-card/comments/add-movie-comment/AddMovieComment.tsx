import React from 'react';
import { useState } from 'react';
import { Alert, Button, Col, Form, Row } from 'react-bootstrap';
import { Messages } from '../../../../../Messages';
import { MovieCommentService } from '../../../../../services/movie-comment.service';

interface AddMovieCommentProps {
  movieId: string;
}

function AddMovieComment(props: AddMovieCommentProps) {
  const { movieId } = props;
  const [comment, setComment] = useState<string>('');
  const [error, setError] = useState<string>('');
  const [isSaving, setIsSaving] = useState<boolean>(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsSaving(true);
    setError('');
    try {
      await MovieCommentService.save({
        tmdbMovieId: movieId,
        comment: comment,
      });
      setComment('');
    } catch {
      setError(Messages.SaveMovieCommentError);
    }
    setIsSaving(false);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setComment(e.target.value);
  };

  return (
    <>
      <Row className="justify-content-center">
        <Col className="p-5" xs={12} sm={10} md={6} lg={9}>
          <Form onSubmit={handleSubmit}>
            <div className="d-flex align-items-center gap-2">
              <Form.Control
                value={comment}
                onChange={handleChange}
                as="textarea"
                rows={3}
                placeholder="Write your comment..."
                required
                style={{ flex: 1 }}
              />
              <Button
                className="mt-2"
                type="submit"
                disabled={isSaving}
                variant="primary"
              >
                Save
              </Button>
            </div>
            {error && <Alert variant="danger">{error}</Alert>}
          </Form>
        </Col>
      </Row>
    </>
  );
}

export default AddMovieComment;
