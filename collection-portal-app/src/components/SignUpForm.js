import React, { useState } from 'react'
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { useAuth } from '../hooks/AuthProvider';
import validationForSignUp from '../validations/validationForSignUp';
import { useTranslation } from 'react-i18next';

const SignUpForm = () => {
  const auth = useAuth();
  const [error, setError] = useState('')
  const { t } = useTranslation()
  return (
    <div>
      {error && <p className="text-danger  mt-8 text-center">{error}</p>}
      <Formik
        initialValues={{ email: '', password: '', confirm: '' }}
        validationSchema={validationForSignUp}
        onSubmit={async (values, { setSubmitting }) => {
          const result = await auth.signUpAction(values);
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
              <label htmlFor='confirm' className='form-label'>{t('Confirm Password')}</label>
              <Field id='confirm' type="password" name="confirm" className='form-control' />
              <ErrorMessage name="confirm" component="div" />
              <button className='btn btn-primary' type="submit" disabled={isSubmitting}>
                {t('Submit')}
              </button>
            </Form>
          </div>
        )}
      </Formik>
    </div>
  )
}

export default SignUpForm