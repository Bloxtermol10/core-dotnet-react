
import academicsLogo from './assets/academics.svg'
import './App.css'
import { useEffect, useState } from 'react'

import { ComunesService } from './services/Comunes.service';
import { SnackbarProvider } from './providers/Snackbar.provider';
import { SnackbarUtilitiesConfig } from './utilities/snackbar-manage';

function App() {
  const [id, setId] = useState("");
  const [data, SetData] = useState([])
  
  const fetchData = async () => {
    const {data} = await ComunesService(id)
    const newData = JSON.stringify(data)
    console.log(data)
    SetData(data)
  }

  useEffect(() => {
    fetchData()
    SnackbarUtilitiesConfig();
  },[])
    
  



  return (
    <>
      <SnackbarProvider>
        <div>
          <img src={academicsLogo} className="logo" alt="Academics logo" />
        </div>
        <h1>Academics Labs</h1>
        <div className="card">
          <input type="text" placeholder="id" onChange={(e) => setId(e.currentTarget.value)} />
          <button onClick={() => fetchData()}>
            count is
          </button>
          <p>
            Edit <code>src/App.tsx</code> and save to test HMR
          </p>
          <select name="Ciudades" id="">
            {data && data.map((item: any) => <option key={item.id} value={item.id}>{item.nombre}</option>)}
          </select>
        </div>
        <p className="read-the-docs">
          {/* {data &&data} */}
        </p>
      </SnackbarProvider>

    </>
  )
}

export default App
