import { useContext } from "react"
import { AuthContext } from "../contexts/AuthContext"
import styles from '../styles/components/LogOutButton.module.css'

export function LogOutButton() {
  const { logOutDisplayed } = useContext(AuthContext)

  return (
    <div>
      { logOutDisplayed ? (
        <button
          className={styles.logOutButton}
          style={{display: 'block'}}
          // onClick={logout}
        >
          Sair
        </button>
      ) : (
        <button
          className={styles.logOutButton}
          style={{display: 'none'}}
          // onClick={logout}
        > 
          Sair
        </button>
      ) }
    </div>
  )
}