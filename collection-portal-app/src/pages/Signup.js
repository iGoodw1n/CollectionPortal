import React from 'react'
import SignUpForm from '../components/SignUpForm'
import { Link } from 'react-router-dom'

const Signup = () => {
  return (
    <>
      <h2 className="text-center text-2xl font-bold leading-tight">Sign in to your account</h2>
      <p className="mt-2 text-center text-base text-black/60">
        Already registered?&nbsp;
        <Link
          to="/login"
        >
          Login
        </Link>
      </p>
      <SignUpForm />
    </>

  )
}

export default Signup