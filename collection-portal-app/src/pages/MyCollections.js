import React from 'react'
import { useTranslation } from 'react-i18next'
import { useAuth } from '../hooks/AuthProvider'
import Collections from '../components/Collections'
import { Container } from 'react-bootstrap'

const MyCollections = () => {
  const { t } = useTranslation()
  const user = useAuth()
  return (
    <Container>
      <div>{t('MyCollections')}</div>
      <Collections userId={user.authData.id} />
    </Container>
  )
}

export default MyCollections