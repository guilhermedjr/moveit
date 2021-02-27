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
  isActive: boolean;
}

export const DarkModeContext = createContext({} as DarkModeContextData)

export function DarkModeProvider({
  children,
  ...rest
}: DarkModeProviderProps) {
  const [isActive, setIsActive] = useState(rest.isActive ?? false)

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

export const getServerSideProps : GetServerSideProps = async(ctx) => {
  const { isDarkThemeActive } = ctx.req.cookies;

  return {
    props: {
      isActive: Boolean(isDarkThemeActive)
    }
  }
}
