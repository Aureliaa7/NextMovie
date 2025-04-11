import { useState } from 'react';
import { Alert, Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Messages } from '../../Messages';
import { UserCreationData } from '../../interfaces/account/user-creation-data.interface';
import { UserService } from '../../services/user.service';
import { useNavigate } from 'react-router-dom';

const FormFields = {
  email: 'email',
  firstName: 'firstName',
  lastName: 'lastName',
  password: 'password',
  confirmPassword: 'confirmPassword',
} as const;

function Register() {
  const [formData, setFormData] = useState<UserCreationData>({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });

  const [error, setError] = useState<string>('');
  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (!isFormValid()) {
      return;
    }

    try {
      await UserService.register(formData);
      navigate('/login');
    } catch {
      setError(Messages.UserRegistrationError);
    }
  };

  const isFormValid = () => {
    if (formData.password !== formData.confirmPassword) {
      setError(Messages.UnmatchedPassword);
      return false;
    }
    return true;
  };

  return (
    <Container className="mt-5">
      <Row className="justify-content-center">
        <Col className="form-container p-5" xs={12} sm={10} md={6} lg={4}>
          <h2 className="mb-4">Register</h2>
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId={FormFields.firstName} className="mb-3">
              <Form.Label className="d-flex text-start">First Name</Form.Label>
              <Form.Control
                type="text"
                name={FormFields.firstName}
                value={formData.firstName}
                onChange={handleChange}
                placeholder="Enter first name"
                required
              />
            </Form.Group>

            <Form.Group controlId={FormFields.lastName} className="mb-3">
              <Form.Label className="d-flex text-start">Last Name</Form.Label>
              <Form.Control
                type="text"
                name={FormFields.lastName}
                value={formData.lastName}
                onChange={handleChange}
                placeholder="Enter last name"
                required
              />
            </Form.Group>

            <Form.Group controlId={FormFields.email} className="mb-3">
              <Form.Label className="d-flex text-start">
                Email address
              </Form.Label>
              <Form.Control
                type="email"
                name={FormFields.email}
                value={formData.email}
                onChange={handleChange}
                placeholder="Enter email"
                required
              />
            </Form.Group>

            <Form.Group controlId={FormFields.password} className="mb-4">
              <Form.Label className="d-flex text-start">Password</Form.Label>
              <Form.Control
                type="password"
                name={FormFields.password}
                value={formData.password}
                onChange={handleChange}
                placeholder="Password"
                required
              />
            </Form.Group>

            <Form.Group controlId={FormFields.confirmPassword} className="mb-4">
              <Form.Label className="d-flex text-start">
                Confirm Password
              </Form.Label>
              <Form.Control
                type="password"
                name={FormFields.confirmPassword}
                value={formData.confirmPassword}
                onChange={handleChange}
                placeholder="Confirm Password"
                required
              />
            </Form.Group>

            {error && <Alert variant="danger">{error}</Alert>}

            <Button variant="primary" type="submit" className="w-100">
              Register
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
}

export default Register;
