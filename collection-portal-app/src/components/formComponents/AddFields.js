import React, { useState } from 'react'

const AddFields = ({ fields, setFields }) => {
  const [name, setName] = useState('')
  const [type, setType] = useState('')
  const [addedFields, setAddedFields] = useState([])
  const [options, setOptions] = useState([
    { value: 'int', text: 'Number' },
    { value: 'string', text: 'String' },
    { value: 'text', text: 'Text' },
    { value: 'date', text: 'Date' },
    { value: 'checkbox', text: 'Radio Button' },
  ])
  const [fieldsCounter, setFieldsCounter] = useState(
    {
      int: 0,
      string: 0,
      text: 0,
      date: 0,
      checkbox: 0
    }
  )

  const updateOptions = (type) => {
    const newFieldsCounter = { ...fieldsCounter }
    newFieldsCounter[type] = newFieldsCounter[type] + 1
    setFieldsCounter(newFieldsCounter)
    setOptions(prev => {
      return prev.filter(option => newFieldsCounter[option.value] < 3)
    })
  }

  const createFieldData = (name, type) => {
    const fieldName = `Custom${type}${fieldsCounter[type] + 1}Name`
    const fieldStatusName = `Custom${type}${fieldsCounter[type] + 1}State`
    const data = {}
    data[fieldName] = name
    data[fieldStatusName] = true
    return data
  }

  const onClickHandle = () => {
    const nameInput = document.querySelector('#newFieldName')
    const typeSelect = document.querySelector('#newFieldType')
    if (nameInput.value
      && Object.values(fields).every(name => name !== nameInput.value)
      && options.map(option => option.value).some(value => value === typeSelect.value)) {
      const fieldData = createFieldData(name, type)
      setFields(prev => ({ ...prev, ...fieldData }))
      setAddedFields(prev => [...prev, { name, type }])
      updateOptions(type)
    }
  }
  return (
    <>
      <div className='d-flex flex-wrap m-3 justify-content-center align-items-center gap-3'>
        <div className='form-group'>
          <label className='fs-4' htmlFor='newFieldName'>Name of field:</label>
        </div>
        <div className='form-group'>
          <input className='form-control' id='newFieldName' value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <label className='fs-4 m-1 d-block' htmlFor='newFieldType'>Type of field:</label>
        <div className='form-group'>
          <select className='form-control' id='newFieldType' value={type} onChange={(e) => setType(e.target.value)} required>
            <option hidden>Select type of field</option>
            {options.map(option => (<option value={option.value} key={option.value}>{option.text}</option>))}
          </select>
        </div>
        <div className='text-center'>
          <button className='btn btn-primary' onClick={onClickHandle} type='button'>Add field</button>
        </div>
      </div>

      {
        Object.keys(fields).length &&
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
              {addedFields.map((field, i) => (
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