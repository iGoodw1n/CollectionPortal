import { useField } from 'formik';
import React from 'react'

const MyRadioGroup = ({ label, options, ...props }) => {
  const [field] = useField({ ...props, type: "radio" });
  return (
    <>
      <div id="my-radio-group">{label}</div>
      <div role="group" aria-labelledby="my-radio-group">
        {options.map(option => (
          <label key={option}>
            <input type="radio" {...field} value={option} />
            {option}
          </label>
        ))}
      </div>
    </>

  )
}

export default MyRadioGroup

