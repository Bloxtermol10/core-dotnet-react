import { UserInfo, UserRoutes } from "../models/user.model";
import userMock from "../mocks/user.mock.json";

type userMockType = typeof userMock

type userApiType = {
    data : userMockType
}

const userRoutesAdapter = (user : userApiType) => {
    const routes : UserRoutes[] = []
    user.data.formulario.forEach((formulario : typeof userMock.formulario[0]) => {
        routes.push({
            id: formulario.idFormulario ,
            name: formulario.nomFormulario,
            path: formulario.direccion,
            parentId: formulario.idPadre,
            visible: formulario.visible
        })
    })
    return routes
}
export const userAdapter = (user : userApiType) : UserInfo => ({
    id: user.data.idUsuario,
    name: `${user.data.nombre1} ${user.data.nombre2} ${user.data.apellido1} ${user.data.apellido2}`,
    email: user.data.dominio,
    role: user.data.rol[0].nombre,
    routes: userRoutesAdapter(user)
})