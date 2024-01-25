import React from 'react'
import { Table } from 'react-bootstrap'
import { FIELD_TYPE_CHECKBOX } from '../constants';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../hooks/AuthProvider';
import { Link } from 'react-router-dom';

const TableView = ({ items, customFields, editItem, deleteItem, showButtons }) => {
  const { t } = useTranslation();
  return (
    <Table responsive="md">
      <thead>
        <tr>
          <th>
            {t('Name')}
          </th>
          {Object.values(customFields).map((field, i) => (<th key={i}>{field.name}</th>))}
          <th>
            {t('Tags')}
          </th>
        </tr>
      </thead>
      <tbody>
        {items.map((item, i) => (
          <tr key={i}>
            <td>
              <Link to={`/item/${item.id}`}>
                {item.name}
              </Link>
            </td>
            {Object.keys(customFields).map(field => {
              if (customFields[field].type === FIELD_TYPE_CHECKBOX) {
                return <td key={field}><input type='checkbox' className='form-check-input' checked={item[field]} disabled /></td>
              } else {
                return <td key={field}>{item[field]}</td>
              }
            })}
            <td>
              {item.tags.map(tag => tag.name).join(', ')}
            </td>
            <td>
              {showButtons &&
                <>
                  <button className='btn btn-primary btn-sm' onClick={() => editItem(i)}>{t('Edit Item')}</button>
                  <button className='btn btn-danger btn-sm' onClick={() => deleteItem(item.id)}>{t('Delete Item')}</button>
                </>
              }
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  )
}

export default TableView