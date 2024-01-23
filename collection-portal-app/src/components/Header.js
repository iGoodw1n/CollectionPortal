import React, { useContext, useEffect } from 'react'
import { NavLink } from 'react-router-dom'
import { useAuth } from '../hooks/AuthProvider';
import { Helmet, HelmetProvider } from 'react-helmet-async';
import ThemeContext from '../contexts/ThemeContext';
import { Button, Container, Nav, Navbar } from 'react-bootstrap';

const Header = () => {
  const auth = useAuth()
  const [theme, switchTheme] = useContext(ThemeContext)

  useEffect(() => {
    auth.checkAuth()
    // eslint-disable-next-line
  }, [])
  return (
    <>
      <HelmetProvider>
        <Helmet>
          <html data-bs-theme={theme}></html>
        </Helmet>
      </HelmetProvider>
      <Navbar expand="lg" className="bg-body-tertiary  mb-5" collapseOnSelect={true}>
        <Container>
          <Navbar.Brand to="/" as={NavLink}>Collection App</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link eventKey='1' as={NavLink} aria-current="page" to="/">Home</Nav.Link>
              <Nav.Link eventKey='2' as={NavLink} to="/my-collection">Collections</Nav.Link>
              <Nav.Link eventKey='3' as={NavLink} to="/collection/new">New Collection</Nav.Link>
              <Nav.Link eventKey='4' as={NavLink} to="/items">Items</Nav.Link>
              {auth.isAuth
                ? <>
                  <Nav.Link eventKey='6' as={NavLink} to="/mypage">My Collections</Nav.Link>
                  <Nav.Link eventKey='7' onClick={() => auth.logOut()}>Log out</Nav.Link>
                </>
                : <Nav.Link eventKey='6' as={NavLink} to="/login">Login</Nav.Link>}
              {auth.isAuth && auth.isAdmin && <Nav.Link eventKey='8' as={NavLink} to="/admin">Admin Panel</Nav.Link>}
              <Button variant={theme === 'dark' ? 'light' : 'dark'} onClick={switchTheme}>Switch Theme</Button>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>

  )
}

export default Header