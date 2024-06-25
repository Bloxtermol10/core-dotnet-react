import { useExampleContext } from "../context/example.context"

function ComponentContex2() {
  const {value} = useExampleContext()
  return (

    <div>
      ComponentContex2
    
      <p>{value && value}</p>
    </div>
  )
}

export default ComponentContex2