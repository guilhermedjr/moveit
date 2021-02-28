import { useContext, useEffect, useState } from 'react';
import { ChallengesContext } from '../../contexts/ChallengesContext';
import styles from '../../styles/components/Home/ExperienceBar.module.css';

export function ExperienceBar() {
  const { currentExperience, experienceToNextLevel } = useContext(ChallengesContext);

  const [percentToNextLevel, setPercentToNextLevel] = useState(0); 

  useEffect(() => {
    setTimeout(() => {
      setPercentToNextLevel(Math.round(currentExperience * 100) / experienceToNextLevel);
    }, 100)
  }, [])

  const percentBySecond = percentToNextLevel / 4;

  return (
    <header className={styles.experienceBar}>
      <span>0 xp</span>
      <div>
        <div style={{ width: `${percentToNextLevel}%`}}/>

        <span className={styles.experienceBar} style={{left: `${percentToNextLevel}%`}}>
          {currentExperience} xp
        </span>
      </div>
      <span>{experienceToNextLevel} xp</span>
    </header>
  )
}