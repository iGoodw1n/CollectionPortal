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
  const [items, setItems] = useState(null)
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
      apiService.getCollection(id)
        .then(res => {
          if (res) {
            setCustomFields(getFieldWithNames(res))
            setCollection(res)
          }
        })
    }
  }, [id])

  useEffect(() => {
    if (id) {
      apiService.getItemsByCollection(id, params)
        .then(res => {
          if (res) {
            setItems(res)
          }
        })
    }
  }, [params, showAddForm])

  const updateParams = (page) => {
    setParams(prev => ({ ...prev, pageNumber: page }))
  }

  const capitalize = (text) => {
    return text.slice(0, 1).toUpperCase() + text.slice(1)
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
              <AddItemForm item={item} fieldNames={customFields} collectionId={id} onCancelHandle={() => { setShowAddForm(false); setItem({}) }} />
            </>}
          {items &&
            <>
              <div className='d-flex mt-3 gap-3'>
                <h3>{t('Sorting by:')}</h3>
                <div>
                  <select className="form-select" onChange={(e) => setParams(prev => ({ ...prev, orderBy: capitalize(e.target.value) }))}>
                    <option hidden value=''></option>
                    <option value='name'>{t('Name')}</option>
                    {Object.entries(customFields).map(([field, fieldData], i) => (
                      <option key={i} value={field}>{fieldData.name}</option>
                    ))}
                  </select>
                </div>

                <h3>{t('Order:')}</h3>
                <div>
                  <select className="form-select" onChange={(e) => setParams(prev => ({ ...prev, orderType: e.target.value }))}>
                    <option hidden value=''></option>
                    <option value='asc'>{t('Ascending')}</option>
                    <option value='desc'>{t('Descending')}</option>
                  </select>
                </div>
              </div>
              <TableView
                items={items.items}
                customFields={customFields}
                showButtons={showButtons}
                editItem={editItem}
                deleteItem={deleteItem}
              />
              {items.totalPages > 1 && <MyPagination
                pages={items.totalPages}
                active={items.currentPage}
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