import React from 'react'
import { DarkModeButton } from '../components/DarkModeButton'
import { DarkModeProvider } from '../contexts/DarkModeContext'
import '../styles/global.css'

function MyApp({ Component, pageProps }) {
  return (
    <>
      <DarkModeProvider>
        <DarkModeButton />
      </DarkModeProvider>
      <Component {...pageProps} />
    </>
  )
}

export default MyApp
