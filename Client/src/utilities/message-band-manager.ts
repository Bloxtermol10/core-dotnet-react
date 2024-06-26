import { useDispatch } from "react-redux";
import { MessageBandProps, MessageBandType } from "../models/message-band.model";
import { setMessageBand } from "../redux/states/message-band.state";



function MessageBandManager({ title, message, type }: MessageBandProps) {
    const distpatcher = useDispatch()
    switch (type) {
        case MessageBandType.Success:
            distpatcher(setMessageBand({ title, message, type: MessageBandType.Success }))
            break;

        case MessageBandType.Error:
            setMessageBand({ title, message, type: MessageBandType.Error })
            break;

        case MessageBandType.Warning:
            distpatcher(setMessageBand({ title, message, type: MessageBandType.Warning }))
            break;

        case MessageBandType.Info:
            distpatcher(setMessageBand({ title, message, type: MessageBandType.Info }))
            break;

        default:
            break;
    }
}

export const MessageBandUtilities = {
    success: (title: string, message: string) => MessageBandManager({ title, message, type: MessageBandType.Success }),
    error: (title: string, message: string) => MessageBandManager({ title, message, type: MessageBandType.Error }),
    warning: (title: string, message: string) => MessageBandManager({ title, message, type: MessageBandType.Warning }),
    info: (title: string, message: string) => MessageBandManager({ title, message, type: MessageBandType.Info }),
}

