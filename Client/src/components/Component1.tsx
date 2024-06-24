import { useState } from "react"
import { sharingInformationService } from "../services/sharing-information.sevice"

function Component1() {
  const [data, SetData] = useState("")
  const handleClick = () => {
    sharingInformationService.setSubject(data)
  }
  const handleChange = (e : any) => {  
    sharingInformationService.setSubject(e.currentTarget.value)
  }

  return (
    <div>
      <h2>Componente 1</h2>
      <input type="text"  onChange={(e) => SetData(e.currentTarget.value) }/>
      <button onClick={handleClick}>Enviar información</button>
    </div>
  )
}

export default Component1