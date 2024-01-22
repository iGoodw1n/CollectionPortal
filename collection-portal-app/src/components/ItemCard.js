import Card from 'react-bootstrap/Card';
import { Link } from 'react-router-dom';
import cardImage from '../card-image.svg'
import Markdown from 'react-markdown';
import React from 'react';

const ItemCard = ({ item }) => {
  return (
    <Card className='h-100'>
      <Card.Body>
        <Card.Title>{item.name}</Card.Title>
        <Card.Subtitle>{item.collection.user.userName}</Card.Subtitle>
        <Card.Text>
          Collection: {item.collection.name}
        </Card.Text>
      </Card.Body>
      <Card.Body>
        <Card.Link as={Link} to={`/item/${item.id}`}>View item</Card.Link>
      </Card.Body>
    </Card>
  )
}

export default ItemCard