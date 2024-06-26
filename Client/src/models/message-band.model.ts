export enum MessageBandType {
    Success = 'Success',
    Error = 'Error',
    Warning = 'Warning',
    Info = 'Info',
}

export enum MessageBandPositionType {
    Static = 'staticPosition',
    Relative = 'relative',
    Absolute = 'absolute',
}
export interface MessageBandProps {
    title: string;
    message: string;
    type: MessageBandType;
    className?: string;
}