import { createSlice } from "@reduxjs/toolkit";
import { UserInfo } from "../../models/user.model";

export const UserEmptyState : UserInfo = {
    name: '',
    role: '',
    id : 0,
    email : '',
}


export const userSlice = createSlice({
    name: 'user',
    initialState: UserEmptyState,
    reducers: {
        createUser: (state, action) => {
            return action.payload
        },
        updateUser: (state, action ) => {
            return {...state, ... action.payload}
        },
        resetUser: () => {
            return UserEmptyState
        }
    }
})

export const { createUser, updateUser, resetUser } = userSlice.actions