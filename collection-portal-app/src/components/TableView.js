import React from 'react'
import { Table } from 'react-bootstrap'
import { FIELD_TYPE_CHECKBOX } from '../constants';

const TableView = ({ items, customFields }) => {
  return (
    <Table responsive="md">
      <thead>
        <tr>
          <th>
            Name
          </th>
          {Object.values(customFields).map(field => (<th>{field.name}</th>))}
          <th>
            Tags
          </th>
        </tr>
      </thead>
      <tbody>
        {items.map(item => (
          <tr>
            <td>
              {item.name}
            </td>
            {Object.keys(customFields).map(field => {
              if (customFields[field].type === FIELD_TYPE_CHECKBOX) {
                return <td><input type='checkbox' className='form-check-input' checked={item[field]} disabled /></td>
              } else {
                return <td>{item[field]}</td>
              }
            })}
            <td>
              {item.tags.map(tag => tag.name).join(', ')}
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  )
}

export default TableView