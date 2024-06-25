import axios from "axios";

export function LoginService(userName: string, password: string) {
    return axios.post('api/Auth/login', {userName, password })
}
export function UserInfoService() {
    return axios.get('api/User/info')
}