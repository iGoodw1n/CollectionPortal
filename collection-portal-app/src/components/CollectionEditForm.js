import React, { useEffect, useRef, useState } from 'react'
import { Formik, Form } from 'formik';
import MyTextInput from './formComponents/MyTextInput';
import validationForCollection from '../validations/validationForCollection';
import MarkdownEditor from './MarkdownEditor';
import MySelect from './formComponents/MySelect';
import apiService from '../services/apiService';
import toast, { Toaster } from 'react-hot-toast';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';


const CollectionEditForm = ({ collection }) => {
  const ref = useRef(null)
  const [categories, setCategories] = useState([])
  const { t } = useTranslation();
  const navigate = useNavigate()
  useEffect(() => {
    apiService.getAllCategories()
      .then(categories => {
        if (categories) {
          setCategories(categories)
        }
      })
  }, [])
  
  return (
    <div className='container'>
      <div className='row justify-content-center'>
        <div className='col-md-8'>
          <Formik
            initialValues={{
              name: collection.name ?? '',
              description: collection.description ?? '',
              categoryId: collection.categoryId ?? '',
            }}
            validationSchema={validationForCollection}
            onSubmit={async (values, { setSubmitting }) => {
              const description = ref?.current.getMarkdown()
              const success = await apiService.updateCollection(collection.id, { ...values, description })
              toast(success ? "Successfully create new collection" : "There is some error. Try again")
              success && navigate('/mypage')
              setSubmitting(false)
            }}
          >
            {({ isSubmitting }) => (
              <>
                <Toaster />
                <Form>
                  <MyTextInput name='name' label={t('Collection name')} />
                  <MySelect name='categoryId' label={t('Collection category')} options={categories} />
                  <MarkdownEditor innerRef={ref} text='' label={t('Description')} />
                  <div className='text-center mt-3'>
                    <button className='btn btn-primary btn-lg' type="submit" disabled={isSubmitting}>
                      {t('Update collection')}
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

export default CollectionEditForm