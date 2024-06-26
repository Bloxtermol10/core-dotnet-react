import { createSlice } from "@reduxjs/toolkit";
import { MessageBandProps, MessageBandType } from "../../models/message-band.model";


export const MessageBandEmptyState : MessageBandProps = {
    title: '',
    message: '',
    type: MessageBandType.Info,
} 

export const messageBandSlice = createSlice({
    name: 'message-band',
    initialState: MessageBandEmptyState,
    reducers: {
        setMessageBand: (_state, action) => action.payload,
        clearMessageBand: () => MessageBandEmptyState
    }
})

export const { setMessageBand, clearMessageBand } = messageBandSlice.actions