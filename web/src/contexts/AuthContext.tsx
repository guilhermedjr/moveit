import { createContext, ReactNode, SetStateAction, useEffect, useState } from "react"
import { useRouter } from 'next/router'
import Cookies from "js-cookie"

import axios from 'axios'

interface IUser {
  name: string;
  username: string;
  avatar_url: string;
  bio: string;
}

interface AuthContextData {
  login: (userName: string) => Promise<void>;
  logout: () => Promise<void>;
  user: IUser;
  logOutDisplayed: Boolean;
  setLogOutDisplayed: any;
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

  async function login(userName: string): Promise<void> {
    try {
      const response = await axios.get(
        `https://api.github.com/users/${userName}`)

      const data = response.data
      console.log(data)
      
      const user = {
        name: data.name,
        username: data.login,
        avatar_url: data.avatar_url,
        bio: data.bio
      }
      
      Cookies.set('user', JSON.stringify(user))
      setUser(user)
      router.push('/home')
        
    } catch (err) {
        alert('Github não responde')
    }
  }

  async function logout() : Promise<void> {
    /*Cookies.remove('user')
    Cookies.remove('level')
    Cookies.remove('currentExperience')
    Cookies.remove('challengesCompleted')*/
    router.push('/index')
  }

  return (
    <AuthContext.Provider
      value={{
        login,
        logout,
        user,
        logOutDisplayed,
        setLogOutDisplayed
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}