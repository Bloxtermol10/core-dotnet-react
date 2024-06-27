import { useSelector } from "react-redux"
import { AppStore } from "../redux/store"
import { Navigate, Outlet } from "react-router-dom"
import { PrivateRoutes, PublicRoutes } from "../models/routes"

export const AuthGuard = () => {
    const userState = useSelector((store : AppStore) => store.user)
    
    const validateRoute = () => {
        let isValid = false
        if(!userState) return false
        userState.routes?.forEach(route => {
           if(route.path === window.location.pathname ) isValid = true
        })
        return isValid
    }
    console.log(validateRoute())
    return validateRoute() ? <Outlet /> : <Navigate to={PublicRoutes.LOGIN} />
}