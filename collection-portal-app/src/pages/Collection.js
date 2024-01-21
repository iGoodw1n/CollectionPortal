import React, { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import apiService from '../services/apiService'
import { Container, Image } from 'react-bootstrap'
import MyPagination from '../components/MyPagination'
import TableView from '../components/TableView'
import AddItemForm from '../components/AddItemForm'
import getFieldWithNames from '../services/fieldService'

const Collection = () => {
  const [params, setParams] = useState({})
  const [collecion, setCollection] = useState()
  const [itemsPerPage, setItemsPerPage] = useState(10)
  const [showAddForm, setShowAddForm] = useState(false)
  const [fieldNames, setFieldNames] = useState({})
  const { id } = useParams()
  useEffect(() => {
    if (id) {
      console.log(id);
      apiService.getCollection(id)
        .then(res => {
          if (res) {
            setFieldNames(getFieldWithNames(res))
            setCollection(res)
          }
          console.log(res);
        })
    }
  }, [id, params, showAddForm])
  return (
    <Container >
      {collecion &&
        <>
          <div className='d-flex align-items-end flex-wrap gap-2'>
            <Image thumbnail width='100' height='100' src={collecion.imageUrl} alt={collecion.name} />
            <div>
              <h2>{collecion.name}</h2>
              <span>{collecion.description}</span>
            </div>
            <div className='d-flex flex-column gap-1'>
              <button className='btn btn-primary btn-sm' onClick={() => setShowAddForm(true)}>Add item</button>
              <button className='btn btn-primary btn-sm' to=''>Edit Collection</button>
              <button className='btn btn-danger btn-sm' to=''>Delete Collection</button>
            </div>
          </div>
          {showAddForm &&
            <>
              <AddItemForm fieldNames={fieldNames} />
              <button className='btn btn-primary mt-2' onClick={() => setShowAddForm(false)}>Cancel</button>
            </>}
          {collecion.paginatedItems &&
            <>
              <TableView items={collecion.paginatedItems.Items} fieldNames={fieldNames} />
              <MyPagination />
            </>
          }
        </>
      }
    </Container>
  )
}

export default Collection