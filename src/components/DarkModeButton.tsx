import { useContext } from 'react'
import { DarkModeContext } from '../contexts/DarkModeContext'

export function DarkModeButton() {
  const { isActive, activateDarkMode, deactivateDarkMode } = useContext(DarkModeContext)

  console.log('Botão renderizado. Valor de isActive: ' + isActive) //isActive dá undefined

    // Não são reconhecidas como funções
    //activateDarkMode();
    //deactivateDarkMode();

  return (
    <div>
      <button 
        className='color-theme-btn'
        background-color= { isActive ? '#FFD700' : '#808080' } 
        onClick= { isActive ? deactivateDarkMode : activateDarkMode }
      >
        { isActive ? (
          <img src='icons/sun.svg' alt='Light mode' />
        ) : (
          <img src='icons/moon.svg' alt='Dark mode'/>
        ) }
      </button>
    </div>
  )
}