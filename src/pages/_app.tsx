import { Provider } from 'next-auth/client'
import { DarkModeButton } from '../components/DarkModeButton'
import '../styles/global.css'

function MyApp({ Component, pageProps }) {
  return (
    <Provider session={pageProps.session}>
      <Component {...pageProps} />
      <DarkModeButton />
    </Provider>
  )
}

export default MyApp
