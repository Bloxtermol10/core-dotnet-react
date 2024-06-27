import { useDispatch } from "react-redux"
import { LoginService, UserInfoService } from "../../services/User.service"
import { createUser, resetUser } from "../../redux/states/user"
import { userAdapter } from "../../adapters/user.adapter"
import { useSelector } from "react-redux"
import { loginAdapter } from "../../adapters/login.adapter"
import { Link } from "react-router-dom"
import { PrivateRoutes } from "../../models/routes"
import { AppStore } from "../../redux/store"
import { MessageBandType } from "../../models/message-band.model"
import { setMessageBand } from "../../redux/states/message-band.state"


function Login() {
  const UserState = useSelector((store : AppStore) => store.user)
  const dispatch = useDispatch()
  const login = async (userName: string, password: string ) => {
   
      const token = loginAdapter(await LoginService(userName,password))
      
      if(token) {
       dispatch(setMessageBand({ title: "Login", message: "Login", type: MessageBandType.Success }))
      }
      localStorage.setItem('token', token.token)
      const user = userAdapter(await UserInfoService())
      console.log(" user", user)
      dispatch(createUser(user))
  }

  const handleClick = () => {
    login('admon@can.edu.co','fb766744b5b5da07db345cfb0f810f81c7417c72')
  }
  const handleSubmit = (e : any) => {
    e.preventDefault()

    const fields = Object.fromEntries(new FormData(e.target))

    login(fields?.userName.toString(), fields?.password.toString())

  }
  const handleLogout = () => {
    localStorage.removeItem('token')
    dispatch(resetUser())
    dispatch(setMessageBand({ title: "Logout", message: "Logout", type: MessageBandType.Warning }))

  }
  return (
    <div>
      <h1>Login</h1>
      <form action="" onSubmit={handleSubmit}>

      <label htmlFor="userName">User Name</label>
      <input type="text" id="userName" name="userName"/>
      <label htmlFor="password">Password</label>
      <input type="password" id="password" name="password"/>

      <button>Login</button>
      
      </form>



      <h2>User Info</h2>
      <button onClick={handleClick}>Login default</button>
      <p><b>Name:</b> {UserState.name}</p>
      <p><b>Email:</b> {UserState.role}</p>

      
      <div>
      <button>
        <Link to={`/private${PrivateRoutes.LAB}`}>Laboratorio</Link>

      </button>
      </div>
      <div>

        <button>

          <Link to={`/priv`}>404</Link>
        </button>
      </div>
      <button>

        <Link to={`/private${PrivateRoutes.DASHBOARD}`}>Dahsboard</Link>
      </button>

      <div>
        <button onClick={handleLogout}>
          Cerrar Sesion
        </button>
      </div>
    </div>
  )
}

export default Login