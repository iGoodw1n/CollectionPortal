import { useEffect, useState } from 'react'
import { TagCloud } from 'react-tagcloud'
import apiService from '../../services/apiService'
import './myTagCloud.scss'
import { useNavigate } from 'react-router-dom'

const data = [
  { value: 'JavaScript', count: 38 },
  { value: 'React', count: 30 },
  { value: 'Nodejs', count: 28 },
  { value: 'Express.js', count: 25 },
  { value: 'HTML5', count: 33 },
  { value: 'MongoDB', count: 18 },
  { value: 'CSS3', count: 20 },
]

const MyTagCloud = () => {
  const [tags, setTags] = useState([])
  const navigate = useNavigate()

  useEffect(() => {
    apiService.getAllTagsWithCount()
      .then(res => {
        setTags(res.map(tagWithCount => (
          {
            value: tagWithCount.tag.name,
            count: tagWithCount.count,
            id: tagWithCount.tag.id
          }
        )))
      })
      .catch(err => console.log(err))
  }, [])
  return (
    <TagCloud
      minSize={12}
      maxSize={35}
      tags={tags}
      onClick={tag => navigate(`/itemswithtag/:${tag.id}`)}
    />
  )
}

export default MyTagCloud