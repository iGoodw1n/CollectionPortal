import React, { useEffect, useRef, useState } from 'react'
import { Formik, Form } from 'formik';
import MyTextInput from './formComponents/MyTextInput';
import validationForCollection from '../validations/validationForCollection';
import MarkdownEditor from './MarkdownEditor';
import MySelect from './formComponents/MySelect';
import apiService from '../services/apiService';

const CollectionForm = () => {
  const ref = useRef(null)
  const [categories, setCategories] = useState([])
  useEffect(() => {
    apiService.getAllCategories()
      .then(categories => {
        if (categories) {
          console.log(categories);
          setCategories(categories)
        }
    })
  }, [])
  return (
    <div className='row justify-content-center'>
      <div className='col-md-8'>
        <Formik
          initialValues={{
            name: '',
            description: '',
            theme: ''
          }}
          validationSchema={validationForCollection}
          onSubmit={async (values, { setSubmitting }) => {
            await console.log(values)
            console.log(ref?.current.getMarkdown())
            setSubmitting(false)
          }}
        >
          {({ isSubmitting }) => (
            <>
              <Form>
                <MyTextInput name='name' label='Collection name' />
                <label className='d-block text-center m-3 fs-3'>Description</label>
                <MySelect name='theme' label='Collection category' options={categories} />
                <MarkdownEditor innerRef={ref} text='dfsfdsf' />
                <div className='text-center mt-3'>
                  <button className='btn btn-primary btn-lg' type="submit" disabled={isSubmitting}>
                    Create collection
                  </button>
                </div>

              </Form>
            </>

          )}
        </Formik>
      </div>
    </div>
  )
}

export default CollectionForm