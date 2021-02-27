import { useContext } from 'react'
import { LoginContext } from '../../contexts/LoginContext'
import styles from '../../styles/components/Login/LoginBox.module.css'

export function LoginBox() {
  const { username, name, login, logout } = useContext(LoginContext)

  return (
    <div className={styles.LoginBoxContainer}>
      <input></input>
      <button type="button" onClick={login}>Ir para a home</button>
    </div>
  )
}