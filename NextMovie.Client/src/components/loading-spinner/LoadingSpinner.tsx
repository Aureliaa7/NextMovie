import { Spinner } from 'react-bootstrap';

function LoadingSpinner() {
  return (
    <div className="d-flex justify-content-center">
      <Spinner animation="border" role="status" className="me-2" />
      <span>Loading...</span>
    </div>
  );
}

export default LoadingSpinner;
