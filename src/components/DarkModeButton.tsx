import { useContext } from 'react'
import { DarkModeContext } from '../contexts/DarkModeContext'
import styles from '../styles/components/DarkModeButton.module.css'

export function DarkModeButton() {
  const { isActive, activateDarkMode, deactivateDarkMode } = useContext(DarkModeContext)

  return (
    <div>
      <input 
        className='lamp dark-mode-btn' 
        type='checkbox' 
        aria-label='Dark mode'
        onClick= { isActive ? deactivateDarkMode : activateDarkMode }
      />
    </div>
  )
}