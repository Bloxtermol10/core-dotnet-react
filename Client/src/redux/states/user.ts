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
    initialState:UserEmptyState,
    reducers: {
        createUser: (_state, action) => action.payload,
        updateUser: (state, action ) => ({...state, ... action.payload}),
        resetUser: () => UserEmptyState
    }
})

export const { createUser, updateUser, resetUser } = userSlice.actions