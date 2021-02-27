import { useSession } from 'next-auth/client'
import { LoginProvider } from '../../contexts/LoginContext'
import { useContext } from 'react';
import { ChallengesContext } from '../../contexts/ChallengesContext';
import styles from '../../styles/components/Home/Profile.module.css';

export function Profile() {
  const [session] = useSession()
  const { level } = useContext(ChallengesContext)

  return (
    <div className={styles.profileContainer}>
      <img src="https://github.com/guilhermedjr.png" alt='DJ'></img>
      <div>
        <strong>Guilherme Djrdjrjan</strong>
        <p>
        <img src="icons/level.svg" alt="Level" />
        Level {level}
        </p>
      </div>
    </div>
  )
}