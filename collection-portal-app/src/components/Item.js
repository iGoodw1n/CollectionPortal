import { Card } from 'react-bootstrap'
import getFieldWithNames from '../services/fieldService'
import { useCallback } from 'react'
import { useTranslation } from 'react-i18next';

const Item = ({ item }) => {
  const { t } = useTranslation();
  const fieldNames = useCallback(
    () => {
      getFieldWithNames(item.collection)
    },
    [item],
  )
  
  return (
    <Card >
      <Card.Body>
        <Card.Title>{t('Item name: ')}{item.name}</Card.Title>
        <Card.Text>
          {t('Collection: ')}{item.collection.name}
        </Card.Text>
      </Card.Body>
      <Card.Body>
        {Object.keys(fieldNames).map(name => <Card.Text>{fieldNames[name].name}: {item[name]}</Card.Text>)}
      </Card.Body>
    </Card>
  )
}

export default Item