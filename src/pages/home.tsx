import Head from 'next/head';

import { CompletedChallenges } from "../components/Home/CompletedChallenges";
import { Countdown } from "../components/Home/Countdown";
import { ExperienceBar } from "../components/Home/ExperienceBar";
import { Profile } from '../components/Home/Profile';
import { ChallengeBox } from "../components/Home/ChallengeBox";
import {GetServerSideProps} from 'next';

import styles from '../styles/pages/Home.module.css';
import { CountdownProvider } from "../contexts/CountdownContext";
import { ChallengesProvider } from "../contexts/ChallengesContext";
import { LogOutButton } from '../components/LogOutButton';
import { LogoIcon } from '../components/LogoIcon';
import { RankingButton } from '../components/RankingButton';

interface HomeProps {
  level: number;
  currentExperience: number;
  challengesCompleted: number;
}

export default function Home(props : HomeProps) {
  return (
    <ChallengesProvider 
      level={props.level} 
      currentExperience={props.currentExperience}
      challengesCompleted={props.challengesCompleted}
    >
      <div className={styles.container}>
        <Head>
          <title>Início | move.it</title>
        </Head>

        <LogoIcon />
        <LogOutButton />

        <ExperienceBar />

        <CountdownProvider>
          <section>
            <div>
              <Profile />
              <CompletedChallenges />
              <Countdown />
            </div>
            <div>
              <ChallengeBox />
            </div>
          </section>
        </CountdownProvider>
      </div>
    </ChallengesProvider>
  )
}

export const getServerSideProps : GetServerSideProps = async (ctx) => {
  const { level, currentExperience, challengesCompleted } = ctx.req.cookies;

  return {
    props: {
      level: Number(level),
      currentExperience: Number(currentExperience),
      challengesCompleted: Number(challengesCompleted),
    }
  }
}