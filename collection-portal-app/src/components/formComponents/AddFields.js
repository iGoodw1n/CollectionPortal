import React, { useState } from 'react'

const AddFields = ({ label, fields, setFields, initialState, innerRef }) => {
  const [name, setName] = useState(initialState.name)
  const [type, setType] = useState(initialState.type)
  const [addedFields, setAddedFields] = useState(initialState.addedFields)
  const [options, setOptions] = useState(initialState.options)
  const [fieldsCounter, setFieldsCounter] = useState(initialState.filedsCounter)

  const updateOptions = (type) => {
    const newFieldsCounter = { ...fieldsCounter }
    newFieldsCounter[type] = newFieldsCounter[type] + 1
    setFieldsCounter(newFieldsCounter)
    setOptions(prev => {
      return prev.filter(option => newFieldsCounter[option.value] < 3)
    })
  }

  const resetData = () => {
    setName(initialState.name)
    setType(initialState.type)
    setAddedFields(initialState.addedFields)
    setOptions(initialState.options)
    setFieldsCounter(initialState.fieldsCounter)

  }

  innerRef.current = resetData

  const createFieldData = (name, type) => {
    const fieldName = `Custom${type}${fieldsCounter[type] + 1}Name`
    const fieldStatusName = `Custom${type}${fieldsCounter[type] + 1}State`
    const data = {}
    data[fieldName] = name
    data[fieldStatusName] = true
    return data
  }

  const onClickHandle = () => {
    
    if (name
      && Object.values(fields).every(n => n !== name)
      && options.map(option => option.value).some(value => value === type)) {
      const fieldData = createFieldData(name, type)
      setFields(prev => ({ ...prev, ...fieldData }))
      setAddedFields(prev => [...prev, { name, type }])
      updateOptions(type)
      setName('')
      setType('')
    }
  }
  return (
    <>
      <label className='d-block text-center m-3 fs-3'>{label}</label>
      <div className='d-flex flex-wrap m-3 justify-content-center align-items-center gap-1'>
        <div className='form-group'>
          <label className='fs-4' htmlFor='newFieldName'>Name of field:</label>
        </div>
        <div className='form-group'>
          <input className='form-control' id='newFieldName' value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <div>
          <label className='fs-4 m-1 d-block' htmlFor='newFieldType'>Type of field:</label>
        </div>
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
        Object.keys(fields).length > 0 &&
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