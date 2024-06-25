import { useEffect, useState } from "react";
import { sharingInformationService } from "../RxJS/sharing-information.sevice"

function Component2() {
  const [data, SetData] = useState("")
  

  const subcription$ = sharingInformationService.getSubject();

  useEffect(() => {
    subcription$.subscribe((sbj : any) => {
      SetData(sbj)
      console.log(sbj)
    })
  })
  return (
    <div>Component2
      <p>{data}</p>
    </div>
  )
}

export default Component2