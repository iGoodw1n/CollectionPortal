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
      return (await instance.get('api/collection', params)).data
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
}

const apiService = new ApiService()
export default apiService