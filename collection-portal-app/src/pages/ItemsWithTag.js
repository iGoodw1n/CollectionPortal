import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import apiService from '../services/apiService'
import { Table } from 'react-bootstrap'

const ItemsWithTag = () => {
  const [items, setItems] = useState()
  const { tagId } = useParams()

  useEffect(() => {
    apiService.getItemsByTag(tagId)
      .then(res => {
        setItems(res)
      })
  })

  return (
    <>
      {items &&
      <Table>
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
        {items.map(item => <tr><td>{item.name}</td></tr> )}
        </tbody>
        </Table>
}
    </>

  )
}

export default ItemsWithTag