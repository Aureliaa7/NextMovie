import Nav from 'react-bootstrap/Nav';
import { Navbar } from 'react-bootstrap';
import './Header.css';
import { Link } from 'react-router-dom';
import { AuthContextData } from '../../interfaces/auth-context-data.interface';
import useAuth from '../../hooks/use-auth.hook';

function Header() {
  const authContext: AuthContextData = useAuth();

  return (
    <header className="bg-dark text-white">
      <Navbar expand="lg" className="navbar-dark fixed-top w-100">
        <div className="container-fluid">
          <Navbar.Brand as={Link} to="/">
            Next Movie
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarNav" />
          <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
              <Nav.Item>
                <Nav.Link as={Link} to="/">
                  Home
                </Nav.Link>
              </Nav.Item>
              {authContext?.isAuthenticated ? (
                <Nav.Item>
                  <Nav.Link
                    as={Link}
                    onClick={() => authContext.storeTokenToLocalStorage('')}
                    to="/"
                  >
                    Logout
                  </Nav.Link>
                </Nav.Item>
              ) : (
                <>
                  <Nav.Item>
                    <Nav.Link as={Link} to="/register">
                      Register
                    </Nav.Link>
                  </Nav.Item>
                  <Nav.Item>
                    <Nav.Link as={Link} to="/login">
                      Login
                    </Nav.Link>
                  </Nav.Item>
                </>
              )}
            </Nav>
          </Navbar.Collapse>
        </div>
      </Navbar>
    </header>
  );
}

export default Header;
