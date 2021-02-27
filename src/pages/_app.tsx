import React from 'react'
import { DarkModeProvider } from '../contexts/DarkModeContext'
import '../styles/global.css'

function MyApp({ Component, pageProps }) {
  return (
     <Component {...pageProps} />
  )
}

export default MyApp
