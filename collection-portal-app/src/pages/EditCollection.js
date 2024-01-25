import React, { useEffect, useState } from 'react'
import apiService from '../services/apiService'
import { useParams } from 'react-router-dom'
import CollectionEditForm from '../components/CollectionEditForm'

const EditCollection = () => {
  const [data, setData] = useState(null)
  const { id } = useParams()
  useEffect(() => {
    apiService.getCollectionForEdit(id)
      .then(res => {
        console.log(res);
        setData(res)
      })
  })
  return (
    data && <CollectionEditForm collection={data} />
  )
}

export default EditCollection