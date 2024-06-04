import React, { useState, useEffect } from 'react';
import styles from './Snackbar.module.css';

enum MessageType {
    Success = 'Success',
    Error = 'Error',
    Warning = 'Warning',
    Info = 'Info',
}

enum PositionType {
    Static = 'staticPosition',
    Relative = 'relative',
    Absolute = 'absolute',
}

enum HiddenType {
    Show = 'show',
    Hidden = 'hidden',
}

interface SnackbarProps {
    title: string;
    message: string;
    type: MessageType;
    position: PositionType;
    cssClass?: string;
    hidden: HiddenType;
    onClose: () => void;
}

const Snackbar: React.FC<SnackbarProps> = ({ title, message, type, position, cssClass = '', hidden, onClose }) => {
    const [isVisible, setIsVisible] = useState(hidden === HiddenType.Show);
    const [messageType, setMessageType] = useState(type);

    useEffect(() => {
        setIsVisible(hidden === HiddenType.Show);
    }, [hidden]);

    useEffect(() => {
        setMessageType(type);
    }, [type]);

    const getIcon = () => {
        switch (messageType) {
            case MessageType.Success:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M9 12.75L11.25 15 15 9.75M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z" />
                    </svg>
                );
            case MessageType.Error:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75M3.697 16.126c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126ZM12 15.75h.007v.008H12v-.008Z" />
                    </svg>
                );
            case MessageType.Warning:
                return (
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                        <path strokeLinecap="round" strokeLinejoin="round" d="M12 9v3.75M9 12.75h6m-6-9 9 16.5H3L12 3.75Z" />
                    </svg>
                );
            default:
                return null;
        }
    };

    return (
        <div className={`${styles.messageContainer} ${styles[position]} ${styles[cssClass]} ${isVisible ? styles.show : ''}`}>
            <div className={styles.messageClose} onClick={onClose}>
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
};

export default Snackbar;
export { MessageType, PositionType, HiddenType };
