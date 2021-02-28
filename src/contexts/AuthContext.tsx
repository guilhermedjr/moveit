import { createContext, ReactNode, useEffect, useState } from "react"
import { useSession, signIn, signOut } from 'next-auth/client'
import { useRouter } from 'next/router'
import Cookies from "js-cookie"

import axios from 'axios'
import oauth from 'axios-oauth-client'


interface IUser {
  name: string;
  username: string;
  avatar_url: string;
}

interface AuthContextData {
  login: (userName: string) => Promise<void>;
  logout: () => Promise<void>;
  user: IUser;
}

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthContext = createContext({} as AuthContextData)

export function AuthProvider({children}: AuthProviderProps) {
  const router = useRouter()
  const [user, setUser] = useState<IUser>({} as IUser)

  async function loadUserCookie(): Promise<void> {
    const userCookie = Cookies.get('user')
    if (typeof(userCookie) !== 'undefined') {
      const userCookieParse = JSON.parse(userCookie) as IUser;
      const userParams = {
        name: userCookieParse.name ?? '',
        username: userCookieParse.username ?? '',
        avatar_url: userCookieParse.avatar_url ?? ''
      };
      setUser(userParams)
    }
  }

  useEffect(() => {
    loadUserCookie()
  }, [])

  async function login(userName: string): Promise<void> {
    try {

      await axios.get(
              `https://api.github.com/users/${userName}`)
        .then(res => {
          const data = res.data.json()
          
          if (data.message) {
            alert(`${data.message === 'Not Found' 
              ? 'Seu usuário não foi encontrado' 
              : data.message}`);
            return;
          }
          const userData = {
            name: data.name,
            username: data.login,
            avatar_url: data.avatar_url
          }
          Cookies.set('user', JSON.stringify(userData))
          router.push('/')
        })
    } catch (err) {
        alert('Github não responde')
    }
  }

  async function logout() : Promise<void> {}

  return (
    <AuthContext.Provider
      value={{
        login,
        logout,
        user,
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}