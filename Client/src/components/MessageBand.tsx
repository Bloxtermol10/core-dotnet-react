import { useEffect, useState } from 'react';
import styles from './MessageBand.module.css';
import { MessageBandProps, MessageBandType } from '../models/message-band.model';
import { useDispatch } from 'react-redux';
import { clearMessageBand } from '../redux/states/message-band.state';

// Ejemplo de uso en un componente React
export function MessageBand({ title, message, type, className = '' } : MessageBandProps) : JSX.Element {
    const [messageType, setMessageType] = useState(type);
    const dispatcher = useDispatch();
    useEffect(() => {
        setMessageType(type);
    }, [type]);

    const containerClass = `
        ${styles.messageContainer} 
        ${type === 'Success' ? styles.messageContainerSuccess : ''} 
        ${type === 'Error' ? styles.messageContainerError : ''} 
        ${type === 'Warning' ? styles.messageContainerWarning : ''} 
        
    `;
    const getIcon = () => {
        switch (messageType) {
            case MessageBandType.Success:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M9 12.75L11.25 15 15 9.75M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z" />
                    </svg>
                );
            case MessageBandType.Error:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75M3.697 16.126c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126ZM12 15.75h.007v.008H12v-.008Z" />
                    </svg>
                );
            case MessageBandType.Warning:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75M9 12.75h6m-6-9 9 16.5H3L12 3.75Z" />
                    </svg>
                );
            default:
                return null;
        }
    };


    const handleClose = () => {
        dispatcher(clearMessageBand())
    };

    return (
        <div className={`${className} ${containerClass}`}>
        <div className={styles.messageClose} onClick={handleClose}>
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                <path strokeLinecap="round" strokeLinejoin="round" d="M6 18L18 6M6 6l12 12" />
            </svg>
        </div>
        <div className={styles.messageContent}>
            <div className={styles.messageContentIcon}>{getIcon()}</div>
            <div className={styles.messageContentText}>
                <h4 className={`${styles.messageContentTextTitle} ${!title ? styles.hidden : ''}`}>{title}</h4>
                <p className={styles.messageContentTextMessage}>{message}</p>
            </div>
        </div>
    </div>
    );
}




