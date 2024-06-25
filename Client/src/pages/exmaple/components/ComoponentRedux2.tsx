import { useSelector } from "react-redux"


function ComoponentRedux2() {


    const UserState = useSelector((store : any) => store.user)
    return (
        <div>
            <h3>
                ComoponentRedux2
            </h3>
            <h3>Usuario global</h3>
            <p><b>Nombre:</b> {UserState.name}</p>
            <p><b>Email:</b> {UserState.email}</p>
        </div>
    )
}

export default ComoponentRedux2