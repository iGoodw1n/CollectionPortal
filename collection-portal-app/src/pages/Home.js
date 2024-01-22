import React from 'react'
import MyTagCloud from '../components/myTagCloud/MyTagCloud'
import { Container } from 'react-bootstrap'
import Collections from '../components/Collections'
import Items from '../components/Items'

const Home = () => {
  return (
    <Container>
      <h2>Tags cloud</h2>
      <MyTagCloud />
      <h2>Biggest collections</h2>
      <Collections pagesize={5} orderBy='items.count' orderType='desc' />
      <h2>Last added items</h2>
      <Items pagesize={5} orderBy='creationdate' orderType='desc'  />
    </Container>
  )
}

export default Home