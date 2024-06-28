import { Reducer, combineReducers, configureStore } from "@reduxjs/toolkit";
import { userSlice } from "./states/user";
import { UserInfo } from "../models/user.model";
import { MessageBandProps } from "../models/message-band.model";
import { messageBandSlice } from "./states/message-band.state";
import storage from "redux-persist/lib/storage";
import { FLUSH, PAUSE, PERSIST, PURGE, REGISTER, REHYDRATE, persistReducer } from "redux-persist";
import { Auth } from "../models/auth";
import { authSlice } from "./states/auth.state";


export interface AppStore {
    user: UserInfo,
    messageBand: MessageBandProps,
    auth: Auth
}
const persistConfig = {
    key: 'root',
    storage,
    whitelist: ['user', 'auth'],
    version: 1

}

const rootStore = combineReducers({
    user: userSlice.reducer,
    messageBand: messageBandSlice.reducer,
    auth : authSlice.reducer
})

const persistedReducer = persistReducer(persistConfig, rootStore)

export default configureStore<Reducer<AppStore>>({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) => getDefaultMiddleware({
        serializableCheck: {
            ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER]
        }
    })
})
