import { Serotonina } from "../Serotonina";
import { IUser } from '../../contracts/IUser'

export class UserController extends Serotonina {
  constructor() {
    super()
    this.base_url += 'Users'
  }

  public async GetAll() : Promise<any>
  {
    const users = await this.httpGet(`${this.base_url}`)
    return users
  }

  public async ById(id: number) : Promise<any>
  {
    const user = await this.httpGet(`${this.base_url}/ById?id=${id}`)
    return user
  }

  public async ByUsername(username: number) : Promise<any>
  {
    const user = await this.httpGet(`${this.base_url}/ByUsername?username=${username}`)
    return user
  }

  public async Search(s: string): Promise<any>
  {
    const users = await this.httpGet(`${this.base_url}/Search?s=${s}`)
    return users
  }

  public async Add(user: IUser) : Promise<any>
  {
     const data = {
       username: user.username,
       name: user.name,
       email: user.email,
       roleId: 1,
       level: 1,
       levelExperience: 0,
       avatar_url: user.avatar_url,
       bio: user.bio
     }

     const response = await this.httpPost(`${this.base_url}`, data)
     return response
  }

  public async Update(id: number, user:  IUser, level: number, currentXP: number) 
    : Promise<any>
  {
    const data = {
      userId: id,
      username: user.username,
      name: user.name,
      email: user.email,
      roleId: 1,
      level: level,
      levelExperience: currentXP
     }

     return await this.httpPatch(`${this.base_url}`, data)
  }
}