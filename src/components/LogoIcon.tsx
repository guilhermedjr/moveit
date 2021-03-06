import { useContext } from "react"
import { AuthContext } from "../contexts/AuthContext"

export function LogoIcon() {
  const { logOutDisplayed, setLogOutDisplayed } = useContext(AuthContext)

  function handleLogOutButton() {
    if (!logOutDisplayed) {
      setLogOutDisplayed(true)
    } else {
      setTimeout(() => {
        setLogOutDisplayed(false)
      }, 2500)
    }
  }

  return (
    <img className='logo-icon' 
    src='favicon.png' 
    onMouseOver={handleLogOutButton}
    onMouseOut={handleLogOutButton}
    />
  )
}