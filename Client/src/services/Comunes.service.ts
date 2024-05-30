import axios from "axios";

export function ComunesService(name: string) {
    return axios.get(`api/BasicasLista/${name}`)
}