import React, { useState } from 'react'

const AddFields = ({ fields, setFields }) => {
  const [name, setName] = useState('')
  const [type, setType] = useState('')
  const [options, setOptions] = useState([
    { value: 'number', text: 'Number' },
    { value: 'string', text: 'String' },
    { value: 'text', text: 'Text' },
    { value: 'date', text: 'Date' },
    { value: 'radio', text: 'Radio Button' },
  ])
  const [fieldsCounter, setFieldsCounter] = useState(
    {
      number: 3,
      string: 3,
      text: 3,
      date: 3,
      radio: 3
    }
  )

  const updateOptions = (type) => {
    const newFieldsCounter = { ...fieldsCounter }
    newFieldsCounter[type] = newFieldsCounter[type] - 1
    setFieldsCounter(newFieldsCounter)
    setOptions(prev => {
      return prev.filter(option => newFieldsCounter[option.value])
    })
  }

  const onClickHandle = () => {
    const nameInput = document.querySelector('#newFieldName')
    const typeSelect = document.querySelector('#newFieldType')
    if (nameInput.value
      && fields.map(field => field.name).every(name => name !== nameInput.value)
      && options.map(option => option.value).some(value => value === typeSelect.value)) {
      setFields(prev => [...prev, { name, type }])
      updateOptions(type)
    }
  }
  return (
    <>
      <div className='d-flex flex-wrap m-3 justify-content-center'>
        <label className='fs-4 m-1 d-block' htmlFor='newFieldName'>Name of field:</label>
        <div className='form-group'>
          <input className='form-control m-1' id='newFieldName' value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <label className='fs-4 m-1 d-block' htmlFor='newFieldType'>Type of field:</label>
        <div className='form-group'>
          <select className='form-control m-1' id='newFieldType' value={type} onChange={(e) => setType(e.target.value)} required>
            <option hidden>Select type of field</option>
            {options.map(option => (<option value={option.value} key={option.value}>{option.text}</option>))}
          </select>
        </div>
        <div className='text-center'>
          <button className='btn btn-primary' onClick={onClickHandle} type='button'>Add field</button>
        </div>
      </div>

      {
        fields.length > 0 &&
        <>
          <h3>Added custom fields</h3>
          <table className="table">
            <thead>
              <tr>
                <th scope="col">Field Name</th>
                <th scope="col">Field Type</th>
              </tr>
            </thead>
            <tbody>
              {fields.map((field, i) => (
                <tr key={i}>
                  <th scope="col">{field.name}</th>
                  <th scope="col">{field.type}</th>
                </tr>
              ))}
            </tbody>
          </table>
        </>

      }
    </>

  )
}

export default AddFields