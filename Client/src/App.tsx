
import academicsLogo from './assets/academics.svg'
import './App.css'
import {  useEffect, useState } from 'react'

import { ComunesService } from './services/Comunes.service';
import { MessageBand } from './components/MessageBand';
import Component1 from './components/Component1';
import Component2 from './components/Component2';
import Counter from './components/Counter/Counter';
import Example from './pages/exmaple/Example';
import { Provider } from 'react-redux';
import store from './redux/store';
import ComoponentRedux2 from './pages/exmaple/components/ComoponentRedux2';
import ComponentRedux1 from './components/Redux/ComponentRedux1';

function App() {
  const [id, setId] = useState("");
  const [data, SetData] = useState([])
  
  const fetchData = async () => {
    const {data} = await ComunesService(id)
    console.log(data)
    SetData(data)
  }

  useEffect(() => {
    fetchData()
    
  },[])
    
  



  return (
    <>
    <Provider store={store}>

      <div>
        <img src={academicsLogo} className="logo" alt="Academics logo" />
      </div>
      <h1>Academics Labs</h1>
      <div className="card">
        <input type="text" placeholder="id" onChange={(e) => setId(e.currentTarget.value) } />
        <button onClick={() => fetchData() }>
          count is 
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
        
        <select name="Ciudades" id="">
          {data && data.map((item: any) => <option value={item.id}>{item.nombre}</option>)}
        </select>
      </div>
      <p className="read-the-docs">
        
      </p>

      <h2>RxJS</h2>
      <p>Recomendado para disparar eventos entre componentes o pasar informacion entre dos componentes</p>
      <Component1 />
      <Component2 />
      <Counter  />
      <h2>Context</h2>
      <p>Recomendado para compartir informacion entre componentes de una misma pagina</p>
      <Example />
      <h2>Redux</h2>
      <p>Informacion global de la aplicaion</p>
      <ComponentRedux1 />
      <ComoponentRedux2 />
    </Provider>
    </>
  )
}

export default App
