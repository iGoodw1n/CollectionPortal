import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import apiService from '../services/apiService'
import { Container, Image } from 'react-bootstrap'
import MyPagination from './MyPagination'
import TableView from './TableView'
import AddItemForm from './AddItemForm'
import getFieldWithNames from '../services/fieldService'
import cardImage from '../card-image.svg'
import { useTranslation } from 'react-i18next'
import { useAuth } from '../hooks/AuthProvider'

const Collection = () => {
  const [params, setParams] = useState({})
  const [collecion, setCollection] = useState()
  const [itemsPerPage, setItemsPerPage] = useState(10)
  const [showAddForm, setShowAddForm] = useState(false)
  const [customFields, setCustomFields] = useState({})
  const [item, setItem] = useState({});
  const { id } = useParams()
  const { t } = useTranslation()
  const navigate = useNavigate()
  const user = useAuth()


  const showButtons = user.authData && (user.authData.isAdmin || +user.authData.id === +collecion.userId)

  const deleteCollection = () => {
    apiService.deleteCollection(collecion.id)
      .then(res => res && navigate("/"))
  }

  const editItem = (i) => {
    setItem(collecion.paginatedItems.items[i])
    setShowAddForm(true)
  }

  const deleteItem = (id) => {
    apiService.deleteItem(id)
      .then(res => res && setParams(prev => ({ ...prev })))
  }

  useEffect(() => {
    if (id) {
      console.log(id);
      apiService.getCollection(id, params)
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
    console.log(page);
    setParams(prev => ({ ...prev, pageNumber: page }))
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
              {showButtons &&
                <>
                  <button className='btn btn-primary btn-sm' onClick={() => setShowAddForm(true)}>{t('Add item')}</button>
                  <button className='btn btn-primary btn-sm' onClick={() => navigate(`/edit/collection/${collecion.id}`)}>{t('Edit Collection')}</button>
                  <button className='btn btn-danger btn-sm' onClick={() => deleteCollection}>{t('Delete Collection')}</button>
                </>
              }
            </div>
          </div>
          {showAddForm &&
            <>
              <AddItemForm item={item} fieldNames={customFields} collectionId={id} onCancelHandle={() => {setShowAddForm(false); setItem({})}} />
            </>}
          
          {collecion.paginatedItems &&
            <>
              <TableView
                items={collecion.paginatedItems.items}
                customFields={customFields}
                showButtons={showButtons}
                editItem={editItem}
                deleteItem={deleteItem}
              />
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