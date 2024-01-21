import { Field, Form, Formik } from 'formik';
import React from 'react'
import { FIELD_TYPE_CHECKBOX, FIELD_TYPE_DATE, FIELD_TYPE_NUMBER, FIELD_TYPE_STRING, FIELD_TYPE_TEXT } from '../constants';
import MyTextInput from './formComponents/MyTextInput';
import MarkdownEditor from './MarkdownEditor';
import MyCheckBox from './formComponents/MyCheckBox';

const AddItemForm = ({ fieldNames }) => {
  const getInitialValues = () => {
    const initialValues = {}
    Object.keys(fieldNames).forEach(element => {
      initialValues.element = ''
    })
    return initialValues
  }
  return (
    <div>
      <Formik
        initialValues={{ ...getInitialValues(), name: '', tags: [] }}
        onSubmit={async (values, { setSubmitting }) => {
          const result = await console.log(values);
          setSubmitting(false);
        }}
      >
        {({ isSubmitting }) => (
          <div>
            <Form >
              <div className='d-flex flex-wrap'>
              <MyTextInput name='name' label='Enter name:'/>
              {Object.values(fieldNames).map(field => {
                const props = {required: true}
                switch (field.type) {
                  case FIELD_TYPE_STRING:
                    return <MyTextInput {...props} name={field.name}/>
                  case FIELD_TYPE_TEXT:
                    return <MarkdownEditor />
                  case FIELD_TYPE_NUMBER:
                    return <Field type='number' {...props} name={field.name}/>
                  case FIELD_TYPE_DATE:
                    return <Field type='date' {...props} name={field.name}/>
                  case FIELD_TYPE_CHECKBOX:
                    return <MyCheckBox />
                  default:
                    throw new Error(`This type ${field.type} is not supported`)
                }
              })}
              </div>
              
              <button className='btn btn-primary' type="submit" disabled={isSubmitting}>
                Add Item
              </button>
            </Form>
          </div>
        )}
      </Formik>
    </div>
  )
}

export default AddItemForm