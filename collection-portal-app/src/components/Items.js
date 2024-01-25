import React, { useEffect, useState } from 'react'
import apiService from '../services/apiService'
import { Col, Container, Row } from 'react-bootstrap'
import ItemCard from './ItemCard'

const Items = ({ pagesize, orderBy, orderType }) => {
  const [items, setItems] = useState([])
  useEffect(() => {
    apiService
      .getAllItems({ pagesize, orderBy, orderType })
      .then(res => {
        setItems(res.entities)
      })
  }, [])
  return (
    <>
      <Container>
        <Row xs={1} sm={2} md={3} lg={6}>
          {items.map((item, i) => (
            <Col key={i}>
              <ItemCard item={item} />
            </Col>
          ))}
        </Row>
      </Container>
    </>
  )
}

export default Items