import { instance } from "../api.config";

export class ApiService {

  async getAllCategories() {
    try {
      return (await instance.get('api/collection/categories')).data
    } catch (error) {
      console.log("APIService :: getAllCategories() :: ", error)
    }
    return false
  }

  async addCollection(data) {
    try {
      const result = await instance.postForm('api/collection', data)
      return result.status === 204
    } catch (error) {
      console.log("APIService :: addCollection() :: ", error)
    }
    return false
  }

  async updateCollection(id, data) {
    try {
      console.log(data);
      const result = await instance.postForm(`api/collection/update/${id}`, data)
      return result.status === 204
    } catch (error) {
      console.log("APIService :: updateCollection() :: ", error)
    }
    return false
  }

  async getAllCollections(params) {
    try {
      const response = await instance.get('api/collection', { params })
      console.log(response);
      return response.data
    } catch (error) {
      console.log("APIService :: getAllCollections() :: ", error)
    }
    return false
  }

  async getCollection(id, params) {
    try {
      return (await instance.get(`api/collection/${id}`, { params})).data
  } catch(error) {
    console.log("APIService :: getCollection() :: ", error)
  }
    return false
  }

  async getCollectionForEdit(id) {
  try {
    return (await instance.get(`api/collection/edit/${id}/`)).data
  } catch (error) {
    console.log("APIService :: getCollectionForEdit() :: ", error)
  }
  return false
}

  async getAllTags() {
  try {
    return (await instance.get('api/tags')).data
  } catch (error) {
    console.log("APIService :: getAllTags() :: ", error)
  }
  return false
}

  async getAllTagsWithCount() {
  try {
    return (await instance.get('api/tags/tagswithcount')).data
  } catch (error) {
    console.log("APIService :: getAllTagsWithCount() :: ", error)
  }
  return false
}

  async addItem(data) {
  try {
    const result = await instance.post('api/items/', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: addItem() :: ", error)
  }
  return false
}

  async addTag(data) {
  try {
    return (await instance.post('api/tags/', data)).data
  } catch (error) {
    console.log("APIService :: addTag() :: ", error)
  }
  return false
}

  async getAllItems(params) {
  try {
    const result = await instance.get('api/items/', { params })
    console.log(result);
    return result.data
  } catch (error) {
    console.log("APIService :: getAllItems() :: ", error)
  }
  return false
}

  async getItem(id) {
  try {
    const result = await instance.get(`api/items/${id}`)
    console.log(result);
    return result.data
  } catch (error) {
    console.log("APIService :: getItem() :: ", error)
  }
  return false
}

  async getAllCommentsByItem(id, params) {
  try {
    const result = await instance.get(`api/comments/byitem/${id}`, { params })
    console.log(result);
    return result.data
  } catch (error) {
    console.log("APIService :: getAllCommentsById() :: ", error)
  }
  return false
}

  async getAllUsers(params) {
  try {
    const result = await instance.get('api/account/', { params })
    console.log(result);
    return result.data
  } catch (error) {
    console.log("APIService :: getAllUsers() :: ", error)
  }
  return false
}

  async deleteUsers(data) {
  try {
    const result = await instance.delete('api/account/', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: deleteUsers() :: ", error)
  }
  return false
}

  async blockUsers(data) {
  try {
    const result = await instance.put('api/account/block', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: blockUsers() :: ", error)
  }
  return false
}

  async unblockUsers(data) {
  try {
    console.log('PutData', data)
    const result = await instance.put('api/account/unblock', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: unblockUsers() :: ", error)
  }
  return false
}

  async setAdmin(data) {
  try {
    const result = await instance.put('api/account/setAdmin', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: setAdmin() :: ", error)
  }
  return false
}

  async removeAdmin(data) {
  try {
    const result = await instance.put('api/account/removeAdmin', data)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: removeAdmin() :: ", error)
  }
  return false
}

  async deleteComment(id) {
  try {
    const result = await instance.delete(`api/comments/${id}`)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: deleteComment() :: ", error)
  }
  return false
}

  async addComment(data) {
  try {
    const result = await instance.post('api/comments/', data)
    console.log(result);
    return result.status === 204
  } catch (error) {
    console.log("APIService :: addComment() :: ", error)
  }
  return false
}

  async deleteCollection(id) {
  try {
    const result = await instance.delete(`api/collection/${id}`)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: deleteCollection() :: ", error)
  }
  return false
}

async deleteItem(id) {
  try {
    const result = await instance.delete(`api/items/${id}`)
    return result.status === 204
  } catch (error) {
    console.log("APIService :: deleteItem() :: ", error)
  }
  return false
}
}

const apiService = new ApiService()
export default apiService