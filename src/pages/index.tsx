import Head from 'next/head'
import { LoginProvider } from '../contexts/LoginContext'

export default function Index() {

  return (
    <LoginProvider>
      <Head>
        <title>Login | move.it</title>
      </Head>
      <img className='logo-full' src='logo-full.svg' />
    </LoginProvider>
  )
}