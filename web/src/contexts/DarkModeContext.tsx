import { createContext, useState, ReactNode, useEffect } from "react";
import Cookies from "js-cookie";
import {} from '../components/DarkModeButton'

type DarkModeContextData = {
  isActive: boolean;
  activateDarkMode: () => void;
  deactivateDarkMode: () => void;
}

type DarkModeProviderProps = {
  children: ReactNode;
}

export const DarkModeContext = createContext({} as DarkModeContextData)

export function DarkModeProvider({
  children
}: DarkModeProviderProps) {
  const [isActive, setIsActive] = useState(false)

  useEffect(() => {
    Cookies.set('isDarkThemeActive', String(isActive))
  }, [])

  function activateDarkMode() {
    setIsActive(true)
  }

  function deactivateDarkMode() {
    setIsActive(false)
  }

  useEffect(() => {
    Cookies.set('isDarkThemeActive', String(isActive))
    document.body.classList.toggle('dark-mode')
  }, [isActive])

  return (
    <DarkModeContext.Provider
      value={{
        isActive,
        activateDarkMode,
        deactivateDarkMode
      }}
    >
      {children}
    </DarkModeContext.Provider>
  )
}

/*export const getServerSideProps : GetServerSideProps = async(ctx) => {
  const { isDarkThemeActive } = ctx.req.cookies;

  return {
    props: {
      isActive: Boolean(isDarkThemeActive)
    }
  }
}*/
