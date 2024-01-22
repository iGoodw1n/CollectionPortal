import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import apiService from '../services/apiService'
import { Container, Image } from 'react-bootstrap'
import MyPagination from './MyPagination'
import TableView from './TableView'
import AddItemForm from './AddItemForm'
import getFieldWithNames from '../services/fieldService'
import cardImage from '../card-image.svg'

const Collection = () => {
  const [params, setParams] = useState({})
  const [collecion, setCollection] = useState()
  const [itemsPerPage, setItemsPerPage] = useState(10)
  const [showAddForm, setShowAddForm] = useState(false)
  const [customFields, setCustomFields] = useState({})
  const { id } = useParams()
  useEffect(() => {
    if (id) {
      console.log(id);
      apiService.getCollection(id)
        .then(res => {
          if (res) {
            setCustomFields(getFieldWithNames(res))
            setCollection(res)
          }
          console.log(res);
        })
    }
  }, [id, params, showAddForm])

  const updateParams = (page) => {
    setParams(prev => ({ ...prev, page }))
  }
  return (
    <Container >
      {collecion &&
        <>
          <div className='d-flex align-items-end flex-wrap gap-2'>
            <Image thumbnail width='100' height='100' src={collecion.imageUrl || cardImage} alt={collecion.name} />
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
              <AddItemForm fieldNames={customFields} collectionId={id} onCancelHandle={() => setShowAddForm(false)} />

            </>}
          {collecion.paginatedItems &&
            <>
              <TableView items={collecion.paginatedItems.items} customFields={customFields} />
              {collecion.paginatedItems.totalPages > 1 && <MyPagination
                pages={collecion.paginatedItems.totalPages}
                active={collecion.paginatedItems.currentPage}
                onClickHandle={updateParams}
              />}
            </>
          }
        </>
      }
    </Container>
  )
}

export default Collection