import React from 'react'
import { Table } from 'react-bootstrap'
import { FIELD_TYPE_CHECKBOX } from '../constants';
import { useTranslation } from 'react-i18next';
import { useAuth } from '../hooks/AuthProvider';

const TableView = ({ items, customFields, editItem, deleteItem, showButtons }) => {
  const { t } = useTranslation();
  return (
    <Table responsive="md">
      <thead>
        <tr>
          <th>
            {t('Name')}
          </th>
          {Object.values(customFields).map(field => (<th>{field.name}</th>))}
          <th>
            {t('Tags')}
          </th>
        </tr>
      </thead>
      <tbody>
        {items.map((item, i) => (
          <tr>
            <td>
              {item.name}
            </td>
            {Object.keys(customFields).map(field => {
              if (customFields[field].type === FIELD_TYPE_CHECKBOX) {
                return <td><input type='checkbox' className='form-check-input' checked={item[field]} disabled /></td>
              } else {
                return <td>{item[field]}</td>
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