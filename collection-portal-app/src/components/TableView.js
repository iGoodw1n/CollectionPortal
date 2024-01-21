import React from 'react'
import { Table } from 'react-bootstrap'

const TableView = ({items, fieldNames}) => {
  return (
    <Table>
      <tr>
        <thead>
          {Object.values(fieldNames).map(name => (<th>{name}</th>))}
        </thead>
      </tr>
      {items.map(item => (
        <tr>
          <td>
            {item}
          </td>
        </tr>
      ))}
    </Table>
  )
}

export default TableView