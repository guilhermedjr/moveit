import styles from '../styles/components/RankingButton.module.css'

export function RankingButton() {
  return (
      <div>
        <button
          className={styles.rankingButton}
          > 
            Ranking
          </button>
      </div>
  )
}