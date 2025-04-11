import { Messages } from '../../Messages';
import { UserService } from '../../services/user.service';
import { LoginData } from '../../interfaces/account/login-data.interface';
import { useNavigate } from 'react-router-dom';
import { Alert, Button, Col, Container, Form, Row } from 'react-bootstrap';
import { AuthResult } from '../../interfaces/account/auth-result.interface';
import { AuthContextData } from '../../interfaces/auth-context-data.interface';
import useAuth from '../../hooks/use-auth.hook';
import { useState } from 'react';

const FormFields = {
  email: 'email',
  password: 'password',
} as const;

function Login() {
  const [formData, setFormData] = useState<LoginData>({
    email: '',
    password: '',
  });

  const [error, setError] = useState<string>('');
  const navigate = useNavigate();
  const authContext: AuthContextData = useAuth();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
      const authResult: AuthResult = await UserService.login(formData);
      authContext?.storeTokenToLocalStorage(authResult.token);
      navigate('/');
    } catch {
      setError(Messages.LoginError);
    }
  };

  return (
    <Container className="mt-5">
      <Row className="justify-content-center">
        <Col className="form-container p-5" xs={12} sm={10} md={6} lg={4}>
          <h2 className="mb-4">Login</h2>
          <Form onSubmit={handleSubmit}>
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

            {error && <Alert variant="danger">{error}</Alert>}

            <Button variant="primary" type="submit" className="w-100">
              Login
            </Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
}

export default Login;
