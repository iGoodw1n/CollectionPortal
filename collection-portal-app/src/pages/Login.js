import React from 'react'
import LoginForm from '../components/LoginForm'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'

const Login = () => {
  const { t } = useTranslation()
  return (
    <>
      <h2 className="text-center text-2xl font-bold leading-tight">{t('Sign in to your account')}</h2>
      <p className="mt-2 text-center text-base text-black/60">
        {t("Don't have any account?")}&nbsp;
        <Link
          to="/signup"
          className="font-medium text-primary transition-all duration-200 hover:underline"
        >
          {t('Sign Up')}
        </Link>
      </p>
      <LoginForm />
    </>
  )
}

export default Login