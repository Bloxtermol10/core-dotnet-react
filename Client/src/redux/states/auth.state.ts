import { createSlice } from "@reduxjs/toolkit";
import { Auth } from "../../models/auth";

export const AuthEmptyState : Auth = {
    token: null,
}

export const authSlice = createSlice({
    name: 'auth',
    initialState: AuthEmptyState,
    reducers: {
        setAuth: (state, action) => action.payload,
        clearAuth: () => AuthEmptyState,
        }
    },
)
export const { setAuth, clearAuth } = authSlice.actions
