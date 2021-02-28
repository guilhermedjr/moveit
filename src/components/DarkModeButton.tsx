import { useContext } from 'react'
import { DarkModeContext } from '../contexts/DarkModeContext'

/*<button 
className='color-theme-btn'
background-color= { isActive ? '#FFD700' : '#808080' } 
onClick= { isActive ? deactivateDarkMode : activateDarkMode }
>*/

export function DarkModeButton() {
  const { isActive, activateDarkMode, deactivateDarkMode } = useContext(DarkModeContext)

  return (
    <div>
      { isActive ? (
          <button 
          className='color-theme-btn'
          background-color='#808080'
          onClick={deactivateDarkMode}
          >
            <img src='icons/sun.svg' alt='Light mode' />
          </button>
      ) : (
          <button 
          className='color-theme-btn'
          background-color='#FFD700'
          onClick= {activateDarkMode}
          >
            <img src='icons/moon.svg' alt='Dark mode'/>
          </button>
      ) }
    </div>
  )
}