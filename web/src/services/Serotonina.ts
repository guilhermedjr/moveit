import axios from 'axios'

export class Serotonina {
  constructor() {}

  public async httpGet(url: string, config?: []) : Promise<any> {
    try {
      const response = await axios.get(url, config = null)
      return response.data
    } catch (err) {
        return err
    }
  }

  public async httpPost(url: string, data: any, config?: []) : Promise<any> {
    try {
      const response = await axios.post(url, data, config = null)
      return response.data
    } catch (err) {
        return err
    }
  }

  public async httpPut(url: string, data: any, config?: []) : Promise<any> {
    try {
      const response = await axios.put(url, data, config = null)
      return response.data
    } catch (err) {
        return err
    }
  }

  public async httpPatch(url: string, data: any, config?: []) : Promise<any> {
    try {
      const response = await axios.patch(url, data, config = null)
      return response.data
    } catch (err) {
        return err
    }
  }

  public async httpDelete(url: string, config?: []) : Promise<any> {
    try {
      const response = await axios.delete(url, config = null)
      return response.data
    } catch (err) {
        return err
    }
  }
}