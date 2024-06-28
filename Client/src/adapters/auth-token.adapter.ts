import { Auth } from "../models/auth"

export const AuthAdapter = (data: any): Auth => {
    return {
        token: data.data.value.token,
    }
}