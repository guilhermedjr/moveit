import Head from 'next/head'
import { LoginBox } from '../components/Login/LoginBox'
import { LoginProvider } from '../contexts/LoginContext'

export default function Index() {

  return (
    <LoginProvider>
      <Head>
        <title>Login | move.it</title>
      </Head>
      <LoginBox />
    </LoginProvider>
  )
}