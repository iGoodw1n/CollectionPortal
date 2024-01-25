import React, { useEffect, useState } from 'react'
import apiService from '../services/apiService'
import { Col, Container, Row } from 'react-bootstrap'
import CollectionCard from './CollectionCard'
import MyPagination from './MyPagination'

const Collections = ({ pagesize, orderBy, orderType, userId, showPages = true }) => {
  const [collectionsData, setCollecectionsData] = useState(null)
  const [params, setParams] = useState({ pagesize, orderBy, orderType })
  useEffect(() => {
    apiService
      .getAllCollections({ ...params, userId })
      .then(res => {
        setCollecectionsData(res)
      })
  }, [params, userId])

  const updateParams = (page) => {
    setParams(prev => ({ ...prev, pageNumber: page }))
  }
  return (
    <>
      <Container>
        <Row xs={1} sm={2} md={3} lg={6}>
          {collectionsData && collectionsData.items.map((collection, i) => (
            <Col key={i}>
              <CollectionCard {...collection} />
            </Col>
          ))}

          {showPages && collectionsData && collectionsData.totalPages > 1 && <MyPagination
            pages={collectionsData.totalPages}
            active={collectionsData.currentPage}
            onClickHandle={updateParams}
          />}
        </Row>
      </Container>
    </>
  )
}

export default Collections