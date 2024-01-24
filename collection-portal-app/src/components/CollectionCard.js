import Card from 'react-bootstrap/Card';
import { Link } from 'react-router-dom';
import cardImage from '../card-image.svg'
import Markdown from 'react-markdown';
import React from 'react';
import { useTranslation } from 'react-i18next';

const CollectionCard = ({ id, name, description, category: { name: categoryName }, imageUrl }) => {
  const { t } = useTranslation();
  return (
    <Card className='h-100'>
      <Card.Img variant="top" src={imageUrl || cardImage} />
      <Card.Body>
        <Card.Title>{name}</Card.Title>
        <Card.Subtitle>{categoryName}</Card.Subtitle>
        <Card.Text>
          <Markdown components={{
            p: React.Fragment
          }}>
            {description ? 
              description.length < 100 ?
                description : description.slice(100) + '...'
               : "There is no description for this collection"}
          </Markdown>
        </Card.Text>
      </Card.Body>
      <Card.Body>
        <Card.Link as={Link} to={`/collection/${id}`}>{t('View collection')}</Card.Link>
      </Card.Body>
    </Card>
  )
}

export default CollectionCard