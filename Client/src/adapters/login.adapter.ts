export const loginAdapter = (data: any) => {

    
    return {

        token: data.data.value.token,
    }
}