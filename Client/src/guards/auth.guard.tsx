import { useSelector } from "react-redux"
import { AppStore } from "../redux/store"
import { Navigate, Outlet } from "react-router-dom"
import { PublicRoutes } from "../models/routes"
import { useDispatch } from "react-redux"
import { setMessageBand } from "../redux/states/message-band.state"
import { MessageBandType } from "../models/message-band.model"
export const AuthGuard = () => {
    const dispatcher = useDispatch()
    const userState = useSelector((store : AppStore) => store.user)
    
    const validateRoute = () => {
        let isValid = false
              
        if(!userState.id) {
            dispatcher(setMessageBand({ title: "Error", message: "No ha iniciado sesion", type: MessageBandType.Error }))
            return false
        }
        userState.routes?.forEach(route => {
           if(route.path === window.location.pathname ) {
              isValid = true
        }
        })
        if(!isValid) {
            dispatcher(setMessageBand({ title: "Error", message: "No tiene acceso a esta ruta", type: MessageBandType.Error }))
        }
        return isValid
    }
    
    


    return validateRoute() ? <Outlet /> : <Navigate to={PublicRoutes.LOGIN} />
}