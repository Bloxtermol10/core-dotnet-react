import { useState } from "react"
import { useExampleContext } from "../context/example.context"

function ComponentContex1() {
  const [formValue, setFormValue] = useState('')
  const { setValue } = useExampleContext()
  return (
    <div>
      <div>ComponentContex1</div>
      <input type="text" onChange={e => setFormValue(e.target.value)}/>
      <button onClick={() => setValue(formValue)}>Enviar info por un context</button>

    </div>
  )
}

export default ComponentContex1