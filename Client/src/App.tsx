
import './App.css'

import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';

import Login from './pages/login/Login';
import { PrivateRoutes, PublicRoutes } from './models/routes';
import { AuthGuard } from './guards/auth.guard';
import Private from './pages/private/Private';
import RoutesWhitNotFound from './utilities/routes-whit-not-found';
import { Suspense } from 'react';
import AxiosInterceptor from './interceptors/axios.interceptor';
import { Provider } from 'react-redux';
import store from './redux/store';

function App() {
  return (
    <>

    <Suspense   fallback={<div>Loading...</div>}>
       <Provider store={store}>
        <AxiosInterceptor />
        <BrowserRouter>
          <RoutesWhitNotFound>  
            <Route path="/" element={<Navigate to={PrivateRoutes.PRIVATE} />} />
            <Route path={PublicRoutes.LOGIN} element={<Login />} />
            <Route element={<AuthGuard />}>
              <Route path={`${PrivateRoutes.PRIVATE}/*`} element={<Private />} />
            </Route>
          </RoutesWhitNotFound>
        </BrowserRouter>
    </Provider>
    </Suspense>
    

    </>
  )
}

export default App

