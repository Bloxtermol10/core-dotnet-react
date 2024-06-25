
import ComponentContex1 from "./components/ComponentContex1"
import ComponentContex2 from "./components/ComponentContex2"
import { ExampleProvider } from "./context/example.context"


function Example() {
  
  
  return (

    <div>
       <ExampleProvider>
        <ComponentContex2 />
        <ComponentContex1 />
      </ExampleProvider>
      
    </div>
  )
}

export default Example