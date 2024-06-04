import axios from "axios"
import { getValidationError } from "../utilities/get-validation-error"
import { SnackbarProvider, useSnackbar } from "../providers/Snackbar.provider"
import { SnackbarUtilities } from "../utilities/snackbar-manage"

export function AxiosInterceptor () {
    const updateHeader = (request : any) => {
        const token = 'asjflaskjflñaskjflacxvzxcskj'
        const newHeader = {
            ...request.headers,
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json"
        }
        request.headers = newHeader
        return request
    }
    
    axios.interceptors.request.use((request ) => {
        if(request.url?.includes('api')) {
            console.log(request.url)
            return request
        }
        return updateHeader(request)
    })

    axios.interceptors.response.use((response) => {
        console.log("response",response)
        return response
    }, (error) => {
        SnackbarUtilities.error((error.code))
        return Promise.reject(error)}
    )
}