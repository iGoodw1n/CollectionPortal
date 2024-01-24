import React, { useEffect, useState } from 'react'
import { Button, Table } from 'react-bootstrap'
import apiService from '../services/apiService'
import toast, { Toaster } from 'react-hot-toast'
import { useAuth } from '../hooks/AuthProvider'

const TableWithUsers = () => {
  const [users, setUsers] = useState([])
  const [params, setParams] = useState({})
  const [checkedUsers, setCheckedUsers] = useState([])
  const auth = useAuth()

  useEffect(() => {
    apiService.getAllUsers()
      .then(res => {
        setUsers(res.items)

      })
      .catch(err => console.log(err))
  }, [params])

  const handleChange = (e) => {
    if (e.target.checked) {
      setCheckedUsers(prev => [...prev, +e.target.value])
    } else {
      setCheckedUsers(prev => prev.filter(id => id !== +e.target.value))
    }
  }

  const switchAllCheckboxes = (e) => {
    const selectedUsers = e.target.checked ? users.map(user => +user.id) : []
    setCheckedUsers(selectedUsers)
  }

  const blockCurrentUser = () => {
    if (checkedUsers.includes(auth.authData.id)) {
      auth.logOut()
    }
  }

  const blockUsers = () => {
    apiService.blockUsers(checkedUsers)
      .then(res => {
        if (res) {
          toast.success("Users are successfully blocked")
          blockCurrentUser()
          setCheckedUsers([])
          setParams(prev => ({ ...prev }))
        } else {
          toast.error("Something goes wrong. Try again")
        }
      })
      .catch(err => console.log(err))
  }

  const unblockUsers = () => {
    apiService.unblockUsers(checkedUsers)
      .then(res => {
        if (res) {
          toast.success("Users are successfully unblocked")
          setCheckedUsers([])
          setParams(prev => ({ ...prev }))
        } else {
          toast.error("Something goes wrong. Try again")
        }
      })
      .catch(err => console.log(err))
  }

  const setAdmin = () => {
    apiService.setAdmin(checkedUsers)
      .then(res => {
        if (res) {
          toast.success("Users are successfully set as admin")
          setCheckedUsers([])
          setParams(prev => ({ ...prev }))
        } else {
          toast.error("Something goes wrong. Try again")
        }
      })
      .catch(err => console.log(err))
  }

  const removeAdmin = () => {
    apiService.removeAdmin(checkedUsers)
      .then(res => {
        if (res) {
          toast.success("Users are successfully removed from admin")
          setCheckedUsers([])
          if (users.includes(auth.authData)) {
            auth.setAuthData(prev => ({...prev, isAdmin: false}))
          }
          setParams(prev => ({ ...prev }))
        } else {
          toast.error("Something goes wrong. Try again")
        }
      })
      .catch(err => console.log(err))
  }

  const deleteUsers = () => {
    apiService.deleteUsers(checkedUsers)
      .then(res => {
        if (res) {
          toast.success("Users are successfully deleted")
          blockCurrentUser()
          setCheckedUsers([])
          setParams(prev => ({ ...prev }))
        } else {
          toast.error("Something goes wrong. Try again")
        }
      })
      .catch(err => console.log(err))
  }

  return (
    <>
      <Toaster />
      <div>
        <Button variant='warning' onClick={blockUsers}>Block</Button>{' '}
        <Button variant='success' onClick={unblockUsers}>Unblock</Button>{' '}
        <Button variant='info' onClick={setAdmin}>Give admin</Button>{' '}
        <Button variant='secondary' onClick={removeAdmin}>Revoke admin</Button>{' '}
        <Button variant='danger' onClick={deleteUsers}>Delete</Button>
      </div>
      <Table responsive hover>
        <thead>
          <tr>
            <th>
              <input
                checked={checkedUsers.length === users.length}
                onChange={(e) => switchAllCheckboxes(e)}
                type="checkbox"
                className="form-check-input"
              />
            </th>
            <th>Email</th>
            <th>Role</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, i) => {
            return (
              <tr key={i}>
                <td>
                  <input
                    checked={checkedUsers.includes(user.id)}
                    onChange={(e) => handleChange(e)}
                    type="checkbox"
                    className="form-check-input"
                    value={user.id}
                  />
                </td>
                <td>{user.userName}</td>
                <td>{user.isAdmin ? 'Admin' : 'User'}</td>
                <td>{user.isBlocked ? 'Blocked' : ''}</td>
              </tr>
            )
          })}
        </tbody>
      </Table>
    </>
  )
}

export default TableWithUsers