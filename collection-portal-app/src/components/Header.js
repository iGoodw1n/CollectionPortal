import React, { useContext } from 'react'
import { NavLink } from 'react-router-dom'
import { useAuth } from '../hooks/AuthProvider';
import { Helmet, HelmetProvider } from 'react-helmet-async';
import ThemeContext from '../contexts/ThemeContext';
import { Button, Container, Nav, NavDropdown, Navbar } from 'react-bootstrap';
import { useTranslation } from 'react-i18next';

const Header = () => {
  const auth = useAuth()
  const [theme, switchTheme] = useContext(ThemeContext)
  const { t, i18n } = useTranslation()
  const setLanguage = (lang) => {
    localStorage.setItem('lang', lang)
    i18n.changeLanguage(lang)
  }

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
              <Nav.Link eventKey='1' as={NavLink} aria-current="page" to="/">{t('Home')}</Nav.Link>
              <Nav.Link eventKey='2' as={NavLink} to="/collections">{t('Collections')}</Nav.Link>
              {auth.authData
                ? <>
                  <Nav.Link eventKey='4' as={NavLink} to="/dashboard">{t('My Collections')}</Nav.Link>
                  <Nav.Link eventKey='3' as={NavLink} to="/collection/new">{t('Create Collection')}</Nav.Link>
                  {auth.authData.isAdmin && <Nav.Link eventKey='8' as={NavLink} to="/admin">{t('Admin Panel')}</Nav.Link>}
                  <NavDropdown title={auth.authData.userName}>
                    <NavDropdown.Item onClick={() => auth.logOut()}>
                      {t('Log out')}
                    </NavDropdown.Item>
                  </NavDropdown>
                </>
                : <Nav.Link eventKey='6' as={NavLink} to="/login">{t('Login')}</Nav.Link>}
              <NavDropdown title={t('Change language')}>
                <NavDropdown.Item onClick={() => setLanguage('en')}>
                  {t('English')}
                </NavDropdown.Item>
                <NavDropdown.Item onClick={() => setLanguage('ru')}>
                  {t('Russian')}
                </NavDropdown.Item>
              </NavDropdown>
              <Button variant={theme === 'dark' ? 'light' : 'dark'} onClick={switchTheme}>{t('Switch Theme')}</Button>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  )
}

export default Header