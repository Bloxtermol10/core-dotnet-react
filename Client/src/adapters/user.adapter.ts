import { UserInfo } from "../models/user.model";


export const userAdapter = (user : any) : UserInfo => ({
    id: user.data.idUsuario,
    name: `${user.data.nombre1} ${user.data.nombre2} ${user.data.apellido1} ${user.data.apellido2}`,
    email: user.data.dominio,
    role: user.data.rol[0].nombre
})