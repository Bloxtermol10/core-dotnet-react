
import academicsLogo from './assets/academics.svg'
import './App.css'
import { useEffect, useState } from 'react'

import { ComunesService } from './services/Comunes.service';

function App() {
  const [id, setId] = useState("");
  const [data, SetData] = useState("")
  
  const fetchData = async () => {
    const {data} = await ComunesService(id)
    const newData = JSON.stringify(data)
    SetData(newData)
  }

  useEffect(() => {
    fetchData()
  },[])
    
  

  return (
    <>
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
          {/* {data && data.map((item: any) => <option value={item.id}>{item.name}</option>)} */}
        </select>
      </div>
      <p className="read-the-docs">
        {data && JSON.stringify(data)}
      </p>
    </>
  )
}

export default App
