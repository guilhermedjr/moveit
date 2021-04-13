import { createContext, ReactNode, SetStateAction, useEffect, useState } from "react"
import { useRouter } from 'next/router'
import Cookies from "js-cookie"

import { Serotonina } from '../services/Serotonina'
import { UserController } from '../services/controllers/UserController'
import { AccountController } from '../services/controllers/AccountController'
import * as IUserUpdateData from '../contracts/IUser'

type IUser = {
  name: string;
  username: string;
  avatar_url: string;
  bio: string;
}

interface AuthContextData {
  login: (userName: string) => Promise<boolean>
  signIn: (userName: string) => Promise<void>
  //logout: () => Promise<void>
  user: IUser
  logOutDisplayed: Boolean
  setLogOutDisplayed: any
}

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthContext = createContext({} as AuthContextData)

export function AuthProvider({children}: AuthProviderProps) {
  const router = useRouter()
  const [user, setUser] = useState<IUser>({} as IUser)
  const [logOutDisplayed, setLogOutDisplayed] = useState(false)

  async function loadUserCookie(): Promise<void> {
    const userCookie = Cookies.get('user')
    if (typeof(userCookie) !== 'undefined') {
      const userCookieParse = JSON.parse(userCookie) as IUser;
      const userParams = {
        name: userCookieParse.name,
        username: userCookieParse.username,
        avatar_url: userCookieParse.avatar_url,
        bio: userCookieParse.bio
      };
      setUser(userParams)
    }
  }

  useEffect(() => {
    loadUserCookie()
  }, [])

  async function login(userName: string): Promise<boolean> {
    const user = await new AccountController().Login(userName)

    if (user.data === null)
      return false

    const userData : IUser = {
      username: user.username,
      name: user.name,
      avatar_url: user.avatar_url,
      bio: user.bio
    }
    Cookies.set('user', JSON.stringify(userData))
    setUser(userData)
    router.push('/home')
    return true
  }

  async function signIn(userName: string) : Promise<any> {
    try {
      const data = 
        await new Serotonina().httpGet(`https://api.github.com/users/${userName}`)
      
      const user = {
        name: data.name,
        username: data.login,
        email: data.email,
        avatar_url: data.avatar_url,
        bio: data.bio
      }

      const addedUser =
        await new UserController().Add(user)

      if (addedUser !== null) {
        Cookies.set('user', JSON.stringify(user))
        setUser(user)
        router.push('/home')
      }  
    } catch (err) {
        alert('Github ou API não responde')
    }
  }

  /*async function logout() : Promise<void> {
    const userCookie = Cookies.get('user')
    const userCookieParse = JSON.parse(userCookie) as IUser
    //const userId = Number(Cookies.get('userId'))
    const level = Number(Cookies.get('level'))
    const currentExperience = Number(Cookies.get('currentExperience'))

    Cookies.remove('user')
    //Cookies.remove('userId')
    Cookies.remove('level')
    Cookies.remove('currentExperience')
    Cookies.remove('challengesCompleted')

    const user : IUserUpdateData.IUser = {
      username: userCookieParse.username,
      name: userCookieParse.name,
      email: 'guilhermedjrdjrjan@gmail.com'
    }

    const response = await new UserController().Update(1, user, level, currentExperience)
    console.log(response);
    //router.push('/index')
  }*/

  return (
    <AuthContext.Provider
      value={{
        login,
        signIn,
        //logout,
        user,
        logOutDisplayed,
        setLogOutDisplayed
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}