import { configureStore } from "@reduxjs/toolkit";
import { userSlice } from "./states/user";
import { UserInfo } from "../models/user.model";
import { MessageBandProps } from "../models/message-band.model";
import { messageBandSlice } from "./states/message-band.state";

export interface AppStore {
    user: UserInfo,
    messageBand: MessageBandProps
}

export default configureStore<AppStore>({
    reducer: {
        user: userSlice.reducer,
        messageBand: messageBandSlice.reducer        
    },  
})
