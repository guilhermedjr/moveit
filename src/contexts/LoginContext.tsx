import { createContext, ReactNode } from "react";
import { useSession, signIn, signOut } from 'next-auth/client'

interface LoginContextData {
  username: string;
  name: string;
  login: () => Promise<void>;
  logout: () => Promise<void>;
}

interface LoginProviderProps {
  children: ReactNode;
}

export const LoginContext = createContext({} as LoginContextData)

export function LoginProvider({children}: LoginProviderProps) {
  const [session] = useSession()
  const username = null
  const name = null

  const login = async() : Promise<void> => {
    return signIn()
  }

  const logout = async() : Promise<void> => {
    return signOut()
  }

  return (
    <LoginContext.Provider
      value={{
        username,
        name,
        login,
        logout
      }}
    >
      {children}
    </LoginContext.Provider>
  )
}