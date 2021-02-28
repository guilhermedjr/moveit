import React from 'react'
import { DarkModeButton } from '../components/DarkModeButton'
import { AuthProvider } from '../contexts/AuthContext'
import { DarkModeProvider } from '../contexts/DarkModeContext'
import '../styles/global.css'

function MyApp({ Component, pageProps }) {
  return (
    <>
      <AuthProvider>
        <DarkModeProvider>
          <DarkModeButton />
        </DarkModeProvider>
        <Component {...pageProps} />
      </AuthProvider>
    </>
  )
}

export default MyApp
