import React, { createContext, useContext, useState, ReactNode } from 'react';

export type SnackbarType = 'success' | 'error';

interface SnackbarMessage {
    message: string;
    type: SnackbarType;
}

export interface SnackbarContextProps {
    showSnackbar: (message: string, type: SnackbarType) => void;
    hideSnackbar: () => void;
}

const SnackbarContext = createContext<SnackbarContextProps | undefined>(undefined);

export const SnackbarProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [snackbar, setSnackbar] = useState<SnackbarMessage | null>(null);

    const showSnackbar = (message: string, type: SnackbarType) => {
        setSnackbar({ message, type });
    };

    const hideSnackbar = () => {
        setSnackbar(null);
    };

    return (
        <SnackbarContext.Provider value={{ showSnackbar, hideSnackbar }}>
            {children}
            {snackbar && (
                <div className={`snackbar ${snackbar.type}`}>
                    <span>{snackbar.message}</span>
                    <button onClick={hideSnackbar}>Close</button>
                </div>
            )}
        </SnackbarContext.Provider>
    );
};

export const useSnackbar = (): SnackbarContextProps => {
    const context = useContext(SnackbarContext);
    if (!context) {
        throw new Error('useSnackbar must be used within a SnackbarProvider');
    }
    return context;
};
