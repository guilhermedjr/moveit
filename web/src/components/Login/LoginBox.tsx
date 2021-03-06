import router from 'next/router'
import { useContext, useState } from 'react'
import { AuthContext } from '../../contexts/AuthContext'
import styles from '../../styles/components/Login/LoginBox.module.css' 

export function LoginBox() {
  const { user, login } = useContext(AuthContext)

  const [userName, setUserName] = useState('')

  async function signIn() : Promise<void> {
    await login(userName)
  }

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
          <form onSubmit={(event) => {event.preventDefault()}}>
            <input 
              id='txtUsername' 
              type="text" 
              placeholder="Digite seu username"
              value={userName}
              onChange={event => setUserName(event.target.value)}
            />
            <button 
              disabled={userName.length == 0} 
              type="submit"
              onClick={signIn}
            >
              <img src="/icons/right-arrow.svg" alt="entrar" />
            </button>
          </form>
        </div>
        
        { Object.keys(user).length !== 0 && (
             <button 
             className={styles.continueButton}
             disabled={userName.length == 0} 
             type="button"
             onClick={() => router.push('/home')}
           >
             Continuar como {user.username}
           </button>
        ) }
      </section>
    </div>
  )
}