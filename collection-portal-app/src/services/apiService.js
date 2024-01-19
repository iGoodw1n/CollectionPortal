import { instance } from "../api.config";

export class ApiService {

  async getAllCategories() {
    try {
      return (await instance.get('/collection/categories')).data
    } catch (error) {
      console.log("APIService :: getAllCategories() :: ", error)
    }
    return false
  }

  async addCollection(data) {
    try {
      const result = await instance.postForm('/collection', data)
      return result.status === 204
    } catch (error) {
      console.log("APIService :: addCollection() :: ", error)
    }
    return false
  }
}

const apiService = new ApiService()
export default apiService