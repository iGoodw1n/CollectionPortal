import { useField } from 'formik';
import React from 'react'

const MyImageUpload = ({label, innerRef, ...props}) => {
  const [, , helpers] = useField('image');
  return (
    <div className='d-flex flex-column justify-content-center align-items-center form-group'>
      <label htmlFor={props.name}  className="m-3 fs-3">{label}</label>
      <input ref={innerRef} id={props.name} className='form-control' type='file' accept='image/*' onChange={(e) => helpers.setValue(e.currentTarget.files[0])} />
    </div>
  )
}

export default MyImageUpload