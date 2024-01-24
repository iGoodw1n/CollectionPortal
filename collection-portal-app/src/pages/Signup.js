import React from 'react'
import SignUpForm from '../components/SignUpForm'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'

const Signup = () => {
  const { t } = useTranslation()
  return (
    <>
      <h2 className="text-center text-2xl font-bold leading-tight">{t('Sign in to your account')}</h2>
      <p className="mt-2 text-center text-base text-black/60">
        {t('Already registered?')}&nbsp;
        <Link
          to="/login"
        >
          {t('Login')}
        </Link>
      </p>
      <SignUpForm />
    </>

  )
}

export default Signup