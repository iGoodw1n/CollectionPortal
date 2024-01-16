import React from 'react'
import LoginForm from '../components/LoginForm'
import { Link } from 'react-router-dom'

const Login = () => {
  return (
    <>
      <h2 className="text-center text-2xl font-bold leading-tight">Sign in to your account</h2>
      <p className="mt-2 text-center text-base text-black/60">
        Don&apos;t have any account?&nbsp;
        <Link
          to="/signup"
          className="font-medium text-primary transition-all duration-200 hover:underline"
        >
          Sign Up
        </Link>
      </p>
      <LoginForm />
    </>
  )
}

export default Login