import { useDispatch } from "react-redux"
import { createUser } from "../../redux/states/user"


function ComponentRedux1() {
  const dispatcher = useDispatch()
  const handleClick = () => {

    dispatcher(createUser({name: 'test', email: 'test'}))
  }
  const handleSubmit = (e : any) => {
    e.preventDefault()
    
      const fields = Object.fromEntries(new FormData(e.target))
      const newUser = {
        name: fields?.userName,
        email: fields?.userEmail
      }
      console.log(newUser)
      dispatcher(createUser(newUser))
  }
  return (
    <div>
        <h3>
            ComponentRedux1
        </h3>
        <form action="" onSubmit={handleSubmit}>

        <label htmlFor="userName"> User Name</label>
        <input type="text" id="userName" name="userName"/>

        <label htmlFor="userEmail">Email</label>
        
        <input type="text" id="userEmail" name="userEmail"/>
        <button >Crear usuario global</button>
    </form>
    </div>
  )
}

export default ComponentRedux1