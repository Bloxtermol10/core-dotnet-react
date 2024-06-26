
import './App.css'

import { MessageBand } from './components/MessageBand';
import { Provider } from 'react-redux';
import store from './redux/store';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LabPage from './pages/lab/LabPage';
import Login from './pages/login/Login';
import NotFond from './pages/notFound/NotFond';
import Dashboard from './pages/dashboard/Dashboard';

function App() {

    
  



  return (
    <>
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/lab" element={<LabPage />} />
            <Route path='/dashboard' element={<Dashboard />} />
            <Route path="*" element={<NotFond />} />
          </Routes>
        </BrowserRouter>
      </Provider>

    </>
  )
}

export default App

