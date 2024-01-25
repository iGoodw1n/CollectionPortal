import { useContext, useEffect, useState } from 'react'
import CreatableSelect from 'react-select/creatable';
import apiService from '../../../services/apiService';
import ThemeContext from '../../../contexts/ThemeContext';
import './myTagSelect.scss'
import { useTranslation } from 'react-i18next';

const MyTagSelect = ({ tags, setTags }) => {
  const [theme] = useContext(ThemeContext)
  const [isLoading, setIsLoading] = useState(false)
  const [options, setOptions] = useState([])
  const { t } = useTranslation()

  const handleResult = (res => {
    const tags = res.map(tag => ({ value: tag.id, label: tag.name }))
    setOptions(tags)
  })
  useEffect(() => {
    apiService.getAllTags()
      .then(res => {
        handleResult(res)
      })
      .catch(err => console.log(err))
    // eslint-disable-next-line
  }, [])

  const handleCreate = (inputValue) => {
    setIsLoading(true);
    apiService.addTag({ name: inputValue })
      .then(res => {
        setOptions(prev => [...prev, { value: res.id, label: res.name }])
        setTags((prev) => [...prev, { value: res.id, label: res.name }]);
        setIsLoading(false);
      })
  };

  const onChangeHandle = (newValue) => {
    setTags(newValue)
  }

  return (
    <div className='w-100'>
      <label className='form-group fs-4'>{t('Select Tags')}</label>
      <CreatableSelect
        className={theme === 'dark' ? 'react-select-container' : null}
        classNamePrefix={theme === 'dark' ? 'react-select' : null}
        isMulti
        isClearable
        isDisabled={isLoading}
        isLoading={isLoading}
        onCreateOption={handleCreate}
        options={options}
        value={tags}
        onChange={onChangeHandle}
      />
    </div>

  )
}

export default MyTagSelect