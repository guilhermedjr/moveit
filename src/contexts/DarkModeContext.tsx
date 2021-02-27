import { createContext, useState, ReactNode, useEffect } from "react";
import Cookies from "js-cookie";
import { GetServerSideProps } from "next";

interface DarkModeContextData {
  isActive: boolean;
  activateDarkMode: () => void;
  deactivateDarkMode: () => void;
}

interface DarkModeProviderProps {
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
    console.log('A')
    setIsActive(true)
    console.log('Dark theme ativado. Valor de isActive - ' + isActive)
  }

  function deactivateDarkMode() {
    console.log('B')
    setIsActive(false)
    console.log('Dark theme desativado. Valor de isActive - ' + isActive)
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
