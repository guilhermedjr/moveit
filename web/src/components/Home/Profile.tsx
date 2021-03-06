import { useSession } from 'next-auth/client'
import { useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';
import { ChallengesContext } from '../../contexts/ChallengesContext';
import styles from '../../styles/components/Home/Profile.module.css';

export function Profile() {
  const [session] = useSession()
  const { level } = useContext(ChallengesContext)
  const { user } = useContext(AuthContext)

  return (
    <div className={styles.profileContainer}>
      <img src={user.avatar_url} alt={user.name}></img>
      <div>
        <strong>{user.name}</strong>
        <p>
        <img src="icons/level.svg" alt="Level" />
        Level {level}
        </p>
        <p>{user.bio}</p>
      </div>
    </div>
  )
}