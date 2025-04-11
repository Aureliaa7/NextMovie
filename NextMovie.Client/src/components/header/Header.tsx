import Nav from 'react-bootstrap/Nav';
import useAuth from '../../hooks/use-auth.hook';
import { Navbar } from 'react-bootstrap';
import './Header.css';

function Header() {
  const { isAuthenticated } = useAuth();

  return (
    <header className="bg-dark text-white">
      <Navbar expand="lg" className="navbar-dark fixed-top w-100">
        <div className="container-fluid">
          <Navbar.Brand href="/">Next Movie</Navbar.Brand>
          <Navbar.Toggle aria-controls="navbarNav" />
          <Navbar.Collapse id="navbarNav">
            <Nav className="ml-auto">
              <Nav.Item>
                <Nav.Link href="/">Home</Nav.Link>
              </Nav.Item>
              {isAuthenticated ? (
                <Nav.Item>
                  <Nav.Link href="/">Logout</Nav.Link>
                </Nav.Item>
              ) : (
                <>
                  <Nav.Item>
                    <Nav.Link href="/register">Register</Nav.Link>
                  </Nav.Item>
                  <Nav.Item>
                    <Nav.Link href="/login">Login</Nav.Link>
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
