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
import { useTranslation } from 'react-i18next';

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
  const { t } = useTranslation();
  useEffect(() => {
    apiService.getAllCategories()
      .then(categories => {
        if (categories) {
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
                  <MyTextInput name='name' label={t('Collection name')} />
                  <MySelect name='categoryId' label={t('Collection category')} options={categories} />
                  <MyImageUpload innerRef={refImage} name='image' label={t('Image for collection')} />
                  <MarkdownEditor innerRef={ref} text='' label={t('Description')} />
                  <AddFields innerRef={refFields} initialState={initialState} fields={customFields} setFields={setCustomFields} label={t('Add additional fields')} />
                  <div className='text-center mt-3'>
                    <button className='btn btn-primary btn-lg' type="submit" disabled={isSubmitting}>
                      {t('Create collection')}
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