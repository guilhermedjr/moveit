import { Serotonina } from "../Serotonina";

export class AccountController extends Serotonina {
  constructor() {
    super()
    this.base_url += 'Account'
  }

  public async Login(username: string) : Promise<any> 
  {
    const data = {
      username: username
    }
    const user = await this.httpPost(`${this.base_url}`, data)
    return user
  }
}