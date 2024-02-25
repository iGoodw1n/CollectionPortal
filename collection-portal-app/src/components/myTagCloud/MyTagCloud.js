import { useEffect, useState } from 'react'
import { TagCloud } from 'react-tagcloud'
import apiService from '../../services/apiService'
import './myTagCloud.scss'
import { useNavigate } from 'react-router-dom'

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
      onClick={tag => navigate(`/itemswithtag/${tag.id}`)}
    />
  )
}

export default MyTagCloud