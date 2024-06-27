
import './App.css'

import { BrowserRouter, Navigate, Route} from 'react-router-dom';
import { PrivateRoutes, PublicRoutes } from './models/routes';
import { AuthGuard } from './guards/auth.guard';
import RoutesWhitNotFound from './utilities/routes-whit-not-found';
import { Suspense, lazy } from 'react';
import AxiosInterceptor from './interceptors/axios.interceptor';
import { Provider } from 'react-redux';
import store from './redux/store';
import { Root } from './Root';

const Login = lazy(() => import('./pages/login/Login'))
const Private = lazy(() => import('./pages/private/Private'))

function App() {
  return (
    <>

      <Suspense fallback={<div>Loading...</div>}>
        <Provider store={store}>
          <AxiosInterceptor />
          <Root>
            <BrowserRouter>
              <RoutesWhitNotFound>
                <Route path="/" element={<Navigate to={PrivateRoutes.PRIVATE} />} />
                <Route path={PublicRoutes.LOGIN} element={<Login />} />
                <Route element={<AuthGuard />}>
                  <Route path={`${PrivateRoutes.PRIVATE}/*`} element={<Private />} />
                </Route>
              </RoutesWhitNotFound>
            </BrowserRouter>
          </Root>
        </Provider>
      </Suspense>


    </>
  )
}

export default App



