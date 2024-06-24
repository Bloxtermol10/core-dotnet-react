import { useEffect, useState } from "react";
import { sharingCounterService } from "../../services/sharing-counter.service"


function CounterView() {
    const [count, setCount] = useState(0)


    const subject$ = sharingCounterService.getSubject();

    useEffect(() => {
        subject$.subscribe((sbj : any) => {
            sbj ? setCount(count + 1) : setCount(count - 1)
        })
    })

  return (
    <div>
        <h3>Rsult counter</h3>
        <p>{count}</p>
    </div>
  )
}

export default CounterView