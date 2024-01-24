import React, { useEffect, useState } from 'react'
import Item from '../components/Item'
import apiService from '../services/apiService'
import { useParams } from 'react-router-dom'
import { Button, Container, InputGroup, Form } from 'react-bootstrap'
import { useAuth } from '../hooks/AuthProvider'
import toast from 'react-hot-toast'
import { useTranslation } from 'react-i18next'

const ItemPage = () => {
  const [item, setItem] = useState(null)
  const [comments, setComments] = useState([])
  const [queryParams, setQueryParams] = useState({})
  const [text, setText] = useState('')
  const { id } = useParams()
  const { t } = useTranslation()
  const auth = useAuth()

  const deleteComment = (id) => {
    apiService.deleteComment(id)
      .then(res => {
        if (res) {
          toast.success("Successfully deleted comment")
          setQueryParams(prev => ({ ...prev }))
        } else {
          toast.error("Something went wrong. Try again")
        }
      })
  }

  const addComment = () => {
    apiService.addComment({ itemId: id, text })
      .then(() => {
        setText('')
        setQueryParams(prev => ({ ...prev }))
      })
  }
  useEffect(() => {
    apiService.getItem(id)
      .then(res => {
        setItem(res)
      })
  }, [id])

  useEffect(() => {
    apiService.getAllCommentsByItem(id, queryParams)
      .then(res => {
        setComments(res.items)
      })
  }, [id, queryParams])
  return (
    <Container>
      {item && <Item item={item} />}
      <h2>{t('Comments')}</h2>
      {auth.authData &&
        <InputGroup className="mb-3">
          <Button variant="success" onClick={addComment}>
            {t('Add comment')}
          </Button>
          <Form.Control
            value={text}
            onChange={(e) => setText(e.target.value)}
          />
        </InputGroup>
      }
      <ul className="list-group">
        {comments.map((comment, i) => (
          <li key={i} className="list-group-item">
            <figure className="text-center">
              <blockquote className="blockquote">
                <p>{comment.text}</p>
              </blockquote>
              <figcaption className="blockquote-footer">
                {comment.userName}
              </figcaption>
              {(auth.isAdmin || +auth.authData.id === comment.userId) && <Button onClick={() => deleteComment(comment.id)} variant='danger'>{t('Delete')}</Button>}
            </figure>
          </li>
        ))}
      </ul>
    </Container>

  )
}

export default ItemPage