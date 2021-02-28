import { useContext } from 'react'
import { LoginContext } from '../../contexts/LoginContext'
import styles from '../../styles/components/Login/LoginBox.module.css'

export function LoginBox() {
  const { username, name, login, logout } = useContext(LoginContext)

  return (
    <div className={styles.container}>
      <div>
        <img src="/icons/rectangles.svg" alt="rectangles" />
      </div>

      <section className={styles.section}>
        <img src="/logo-full.svg" alt="move.it" />
        <strong>Bem-vindo</strong>
        <div>
          <img src="/icons/github.svg" alt="github" />
          <p>Faça login com seu Github para começar</p>
        </div>
        <div>
          <form onSubmit={() => {}}>
            <input type="text" placeholder="Digite seu username" />
            <button disabled type="submit">
              <img src="/icons/right-arrow.svg" alt="entrar" />
            </button>
          </form>
        </div>
      </section>
    </div>
  )
}