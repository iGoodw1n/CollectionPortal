import React from 'react'
import MyTagCloud from '../components/myTagCloud/MyTagCloud'
import { Container } from 'react-bootstrap'
import Collections from '../components/Collections'
import Items from '../components/Items'
import { useTranslation } from 'react-i18next'

const Home = () => {
  const { t } = useTranslation()
  return (
    <Container>
      <h2>{t('Tags cloud')}</h2>
      <MyTagCloud />
      <h2>{t('Biggest collections')}</h2>
      <Collections pagesize={5} orderBy='items.count' orderType='desc' />
      <h2>{t('Last added items')}</h2>
      <Items pagesize={5} orderBy='creationdate' orderType='desc' />
    </Container>
  )
}

export default Home