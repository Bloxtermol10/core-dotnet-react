import { sharingCounterService } from "../../services/sharing-counter.service";

function CounterButton() {

    
    
    const handleIncrease = () => {
        sharingCounterService.setSubject(true);
    }
    const handleDecrease = () => {
        sharingCounterService.setSubject(false);
    }



    return (
        <div>
            <button onClick={handleIncrease}>
                <span>Aumentar +</span>
            </button>

            <button onClick={handleDecrease}>
                <span>Disminiur -</span>
            </button>
        </div>
    )
}

export default CounterButton