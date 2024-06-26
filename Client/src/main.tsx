import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import AxiosInterceptor from './interceptors/axios.interceptor.tsx'
import { Provider } from 'react-redux'
import store from './redux/store.ts'

const Root = () => {
  return (
    <>
      <Provider store={store}>

        <AxiosInterceptor />
        <App />
      </Provider>
    </>
  )
}

ReactDOM.createRoot(document.getElementById('root')!).render(
  <Root />
)