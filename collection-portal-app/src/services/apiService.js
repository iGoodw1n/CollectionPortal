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
      return (await instance.get(`api/collection/${id}/`, params)).data
    } catch (error) {
      console.log("APIService :: getAllCollections() :: ", error)
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
}

const apiService = new ApiService()
export default apiService