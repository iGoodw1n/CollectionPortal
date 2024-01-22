import React from 'react'
import MyTagCloud from '../components/myTagCloud/MyTagCloud'
import { Container } from 'react-bootstrap'
import Collections from '../components/Collections'

const Home = () => {
  return (
    <Container>
      <MyTagCloud />
      <Collections pagesize={5} orderBy='items.count' orderType='desc' />
    </Container>
  )
}

export default Home