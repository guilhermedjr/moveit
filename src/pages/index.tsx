import Head from 'next/head'
import { LoginBox } from '../components/Login/LoginBox'
import { AuthProvider } from '../contexts/AuthContext'

export default function Index() {
  return (
    <AuthProvider>
      <Head>
        <title>Login | move.it</title>
      </Head>
      <LoginBox />
    </AuthProvider>
  )
}