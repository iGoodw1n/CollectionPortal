import { Form, Formik } from 'formik';
import React, { createRef, useState } from 'react'
import { FIELD_TYPE_CHECKBOX, FIELD_TYPE_DATE, FIELD_TYPE_NUMBER, FIELD_TYPE_STRING, FIELD_TYPE_TEXT } from '../constants';
import MyTextInput from './formComponents/MyTextInput';
import MarkdownEditor from './MarkdownEditor';
import MyCheckBox from './formComponents/MyCheckBox';
import MyNumberInput from './formComponents/MyNumberInput';
import MyDateInput from './formComponents/MyDateInput';
import toast, { Toaster } from 'react-hot-toast';
import apiService from '../services/apiService';
import MyTagSelect from './formComponents/myTagSelect/MyTagSelect';
import { useTranslation } from 'react-i18next';

const AddItemForm = ({ fieldNames, collectionId, onCancelHandle, item = {} }) => {
  const [tags, setTags] = useState([])
  const { t } = useTranslation();
  const getInitialValues = () => {
    const initialValues = {}
    Object.keys(fieldNames).forEach(element => {
      initialValues[element] = item[element]
    })
    return initialValues
  }
  const refs = {}
  console.log("Item", item);
  const checkMarkupFields = () => {
    for (const ref of Object.values(refs)) {
      if (!ref?.current.getMarkdown()) {
        return false
      }
    }
    return true
  }
  const getDataFromMarkdownFields = () => {
    const data = {}
    for (const [name, ref] of Object.entries(refs)) {
      data[name] = ref?.current.getMarkdown()
    }
    return data
  }
  const resetData = (resetForm) => {
    resetForm()
    for (const ref of Object.values(refs)) {
      ref?.current.setMarkdown('')
    }
  }
  return (
    <Formik
      initialValues={{ ...getInitialValues(), name: item.name ?? '' }}
      onSubmit={async (values, { setSubmitting, resetForm }) => {
        if (checkMarkupFields()) {
          const data = { ...values, ...getDataFromMarkdownFields(), collectionId, tagIds: tags.map(tag => (tag.value)) }
          console.log(data)
          const success = await apiService.addItem(data)
          toast(success ? "Successfully create new item" : "There is some error. Try again")
          success && resetData(resetForm)
        } else {
          toast.error('Fill all fields')
        }
        setSubmitting(false);
      }}
    >
      {({ isSubmitting }) => (
        <>
          <Toaster />
          <Form >
            <div className='d-flex flex-wrap gap-3 justify-content-center align-items-start'>
              <MyTextInput name='name' label={t('Enter name:')} required />
              {Object.entries(fieldNames).map(([fieldName, field], i) => {
                const props = { required: true, name: fieldName, label: field.name, value: item[fieldName] }
                switch (field.type) {
                  case FIELD_TYPE_STRING:
                    return <MyTextInput key={i} {...props} />
                  case FIELD_TYPE_TEXT:
                    const ref = createRef()
                    refs[fieldName] = ref
                    return <MarkdownEditor innerRef={ref} key={i} {...props} text={item[fieldName] ?? ''} />
                  case FIELD_TYPE_NUMBER:
                    return <MyNumberInput key={i} {...props} />
                  case FIELD_TYPE_DATE:
                    return <MyDateInput key={i} type='date' {...props} />
                  case FIELD_TYPE_CHECKBOX:
                    return <MyCheckBox key={i} {...{ ...props, required: false }} />
                  default:
                    throw new Error(`This type ${field.type} is not supported`)
                }
              })}
              <MyTagSelect {...{ tags, setTags }} />
            </div>
            <div className='m-3'>
              <button className='btn btn-primary mx-3' type="submit" disabled={isSubmitting}>{t('Add Item')}</button>
              <button className='btn btn-secondary' onClick={onCancelHandle}>{t('Cancel')}</button>
            </div>
          </Form>
        </>
      )}
    </Formik>
  )
}

export default AddItemForm