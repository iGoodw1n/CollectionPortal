import React, { useEffect, useRef, useState } from 'react'
import { Formik, Form } from 'formik';
import MyTextInput from './formComponents/MyTextInput';
import validationForCollection from '../validations/validationForCollection';
import MarkdownEditor from './MarkdownEditor';
import MySelect from './formComponents/MySelect';
import apiService from '../services/apiService';
import AddFields from './formComponents/AddFields';
import toast, { Toaster } from 'react-hot-toast';
import MyImageUpload from './formComponents/MyImageUpload';

const initialState = {
  name: '',
  type: '',
  addedFields: [],
  options: [
    { value: 'int', text: 'Number' },
    { value: 'string', text: 'String' },
    { value: 'text', text: 'Text' },
    { value: 'date', text: 'Date' },
    { value: 'checkbox', text: 'Radio Button' },
  ],
  filedsCounter: {
    int: 0,
    string: 0,
    text: 0,
    date: 0,
    checkbox: 0
  },
}


const CollectionForm = () => {
  const ref = useRef(null)
  const refImage = useRef(null)
  const refFields = useRef(null)
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
  const resetData = (resetForm) => {
    resetForm()
    ref?.current.setMarkdown('')
    setCustomFields({})
    refImage.current.value = null
    refFields?.current()
  }
  return (
    <div className='container'>
      <div className='row justify-content-center'>
        <div className='col-md-8'>
          <Formik
            initialValues={{
              name: '',
              description: '',
              categoryId: '',
              image: null,
            }}
            validationSchema={validationForCollection}
            onSubmit={async (values, { setSubmitting, resetForm }) => {
              const description = ref?.current.getMarkdown()
              await console.log({ ...values, customFields, description })
              const success = await apiService.addCollection({ ...values, description, ...customFields })
              toast(success ? "Successfully create new collection" : "There is some error. Try again")
              success && resetData(resetForm)
              setSubmitting(false)
            }}
          >
            {({ isSubmitting }) => (
              <>
                <Toaster />
                <Form>
                  <MyTextInput name='name' label='Collection name' />
                  <MySelect name='categoryId' label='Collection category' options={categories} />
                  <MyImageUpload innerRef={refImage} name='image' label='Image for collection' />
                  <MarkdownEditor innerRef={ref} text='' label='Description' />
                  <AddFields innerRef={refFields} initialState={initialState} fields={customFields} setFields={setCustomFields} label='Add additional fields' />
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
    </div>
  )
}

export default CollectionForm