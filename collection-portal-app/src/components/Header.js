import React, { useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useAuth } from '../hooks/AuthProvider';

const Header = () => {
  const auth = useAuth()
  useEffect(() => {
    auth.checkAuth()
    // eslint-disable-next-line
  }, [])
  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary">
      <div className="container-fluid">
        <Link className="navbar-brand" to="/">Navbar</Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div className="navbar-nav">
            <Link className="nav-link active" aria-current="page" to="#">Home</Link>
            <Link className="nav-link" to="/dashboard">Collection</Link>
            <Link className="nav-link" to="#">Items</Link>
            {auth.isAuth ? <Link className="nav-link" to="/mypage">My Collections</Link> : <Link className="nav-link" to="/login">Login</Link>}
          </div>
        </div>
      </div>
    </nav>
  )
}

export default Header