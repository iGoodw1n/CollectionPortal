import React, { useState } from 'react'
import { Formik, Form, Field, ErrorMessage } from 'formik';
import validationForLogin from '../validations/validationForLogin';
import { useAuth } from '../hooks/AuthProvider';
import { useTranslation } from 'react-i18next';

const LoginForm = () => {
  const auth = useAuth();
  const [error, setError] = useState('')
  const { t } = useTranslation()
  return (
    <div>
      {error && <p className="text-danger mt-8 text-center">{error}</p>}
      <Formik
        initialValues={{ email: '', password: '' }}
        validationSchema={validationForLogin}
        onSubmit={async (values, { setSubmitting }) => {
          const result = await auth.loginAction(values);
          setError(result)
          setSubmitting(false);
        }}
      >
        {({ isSubmitting }) => (
          <div className='d-flex justify-content-center'>
            <Form style={{ width: '300px' }}>
              <label htmlFor='email' className='form-label'>{t('Email')}</label>
              <Field id='email' type="email" name="email" className='form-control' />
              <ErrorMessage name="email" component="div" />
              <label htmlFor='password' className='form-label'>{t('Password')}</label>
              <Field id='password' type="password" name="password" className='form-control' />
              <ErrorMessage name="password" component="div" />
              <button className='btn btn-primary' type="submit" disabled={isSubmitting}>
                {t('Login')}
              </button>
            </Form>
          </div>
        )}
      </Formik>
    </div>
  )
}

export default LoginForm