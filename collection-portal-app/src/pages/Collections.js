import React, { useEffect, useState } from 'react'
import apiService from '../services/apiService'
import { Col, Container, Row } from 'react-bootstrap'
import CollectionCard from '../components/CollectionCard'

const Collections = () => {
  const [collections, setCollecections] = useState([])
  useEffect(() => {
    apiService
      .getAllCollections()
      .then(res => {
        console.log(res)
        setCollecections(res.items)
      })
  }, [])
  return (
    <>
      <Container>
        <Row xs={1} sm={2} md={3} lg={6}>
          {collections.map((collection, i) => (
            <Col key={i}>
              <CollectionCard {...collection} />
            </Col>
          ))}
        </Row>
      </Container>
    </>
  )
}

export default Collections