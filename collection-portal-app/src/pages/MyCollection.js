import React from 'react'
import { useTranslation } from 'react-i18next'

const MyCollection = () => {
  const {t} = useTranslation()
  return (
    <div>{t('MyCollection')}</div>
  )
}

export default MyCollection