import { instance } from "../api.config";

export class Service {

  async getAllCategories() {
    try {
      return (await instance.get('/collection/categories')).data
    } catch (error) {
      console.log("APIService :: getAllCategories() :: ", error)
    }
    return false
  }
}

const service = new Service()
export default service