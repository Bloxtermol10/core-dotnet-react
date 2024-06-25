import { useDispatch } from "react-redux"
import { LoginService, UserInfoService } from "../../services/User.service"
import { createUser } from "../../redux/states/user"
import { userAdapter } from "../../adapters/user.adapter"
import { useSelector } from "react-redux"
import { loginAdapter } from "../../adapters/login.adapter"


function Login() {
  const UserState = useSelector((store : any) => store.user)
  const dispatch = useDispatch()
  const login = async (userName: string, password: string ) => {
    try {
      const token = loginAdapter(await LoginService(userName,password))
      localStorage.setItem('token', token.token)

      const user = userAdapter(await UserInfoService())
      console.log(" user", user)
      
      
      dispatch(createUser(user))
    } catch (error) {
      console.log(error)
    }
    
    
  }

  const handleClick = () => {
    login('admon@can.edu.co','fb766744b5b5da07db345cfb0f810f81c7417c72')
  }
  return (
    <div>
      <h1>Login</h1>
      
      <button onClick={handleClick}>Login</button>

      <h2>User Info</h2>
      <p><b>Name:</b> {UserState.name}</p>
      <p><b>Email:</b> {UserState.role}</p>

    </div>
  )
}

export default Login