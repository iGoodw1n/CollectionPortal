export class AuthService {

  async createAccount({ email, password, name }) {
    try {
      const userAccount = await this.account.create(email, password, name)
      if (userAccount) {
        return this.login({ email, password })
      } else {
        return userAccount
      }
    } catch (error) {
      console.log(error)
      throw error
    }
  }
  async login(data) {
    try {
      console.log(data);
      const res = await fetch('/account/login', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      })
      console.log(res.ok)
      console.log(res)
    } catch (error) {
      console.log(error)
      throw error
    }
  }
  async getCurrentUser() {
    try {
      return await this.account.get()
    } catch (error) {
      console.log('Appwrite service :: getCurrentUser() :: ', error);
    }
    return null
  }
  async logout() {
    try {
      await this.account.deleteSessions()
    } catch (error) {
      console.log('Appwrite service :: logout() :: ', error);
    }
  }
}

const authService = new AuthService()

export default authService