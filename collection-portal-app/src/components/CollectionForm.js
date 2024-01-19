import React, { useEffect, useRef, useState } from 'react'
import { Formik, Form } from 'formik';
import MyTextInput from './formComponents/MyTextInput';
import validationForCollection from '../validations/validationForCollection';
import MarkdownEditor from './MarkdownEditor';
import MySelect from './formComponents/MySelect';
import apiService from '../services/apiService';
import AddFields from './formComponents/AddFields';
import toast, { Toaster } from 'react-hot-toast';


const CollectionForm = () => {
  const ref = useRef(null)
  const [categories, setCategories] = useState([])
  const [customFields, setCustomFields] = useState({})
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
          }}
          validationSchema={validationForCollection}
          onSubmit={async (values, { setSubmitting }) => {
            const description = ref?.current.getMarkdown()
            await console.log({...values, customFields, description})
            const success = await apiService.addCollection({...values, description,  ...customFields})
            toast(success ? "Successfully create new collection" : "There is some error. Try again")
            setSubmitting(false)
          }}
        >
          {({ isSubmitting }) => (
            <>
            <Toaster />
              <Form>
                <MyTextInput name='name' label='Collection name'/>
                <MySelect name='categoryId' label='Collection category' options={categories} />
                <label className='d-block text-center m-3 fs-3'>Description</label>
                <MarkdownEditor innerRef={ref} text='' />
                <label className='d-block text-center m-3 fs-3'>Add additional fields</label>
                <AddFields fields={customFields} setFields={setCustomFields}/>
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