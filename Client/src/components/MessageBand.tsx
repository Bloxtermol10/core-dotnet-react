import styles from './MessageBand.module.css';

type MessageBandType = 'Success' | 'Error' | 'Warning';

type MessageBandProps = {
    type: MessageBandType;
    show: boolean;
    content: string;
}
// Ejemplo de uso en un componente React
export function MessageBand({ type, show, content } : MessageBandProps) {
    const containerClass = `
        ${styles.messageContainer} 
        ${type === 'Success' ? styles.messageContainerSuccess : ''} 
        ${type === 'Error' ? styles.messageContainerError : ''} 
        ${type === 'Warning' ? styles.messageContainerWarning : ''} 
        ${show ? styles.messageContainerShow : ''}
    `;

    const handleClose = () => {
        
    };

    return (
        <div className={containerClass}>
            <div className={styles.messageContent}>
                <i className={`${styles.messageContentIcon} ${styles[`messageContentIcon${type}`]}`}></i>
                <div className={styles.messageContentText}>
                    <p className={styles.messageContentTextMessage}>{content}</p>
                </div>
                <div className={styles.messageClose} onClick={handleClose}>
                    <svg>...</svg>
                </div>
            </div>
        </div>
    );
}


