import axios from "axios";

export function LoginService(userName: string, password: string) {
    return axios.post('api/Auth/login', {userName, password })
}
export function UserInfoService() {
    return axios.get('api/User/info')
}
export function UserInfoServiceOutInterceptor( token = localStorage.getItem('token') ) {
    return axios.get('api/User/info', { headers: { Authorization: `Bearer ${token}` } })
}