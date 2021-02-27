import { createContext, ReactNode, useEffect, useState } from "react";

interface DarkModeContextData {
  isActive: boolean;
  activateDarkMode: () => void;
  deactivateDarkMode: () => void;
}

interface DarkModeProviderProps {
  children: ReactNode;
}

export const DarkModeContext = createContext({} as DarkModeContextData)

export function DarkModeProvider({children}: DarkModeProviderProps) {
  const [isActive, setIsActive] = useState(false)

  function activateDarkMode() {
    setIsActive(true)
  }

  function deactivateDarkMode() {
    setIsActive(false)
    // mudar cores
  }

  useEffect(() => {
    console.log('O modo escuro está ativado? ' + isActive)
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