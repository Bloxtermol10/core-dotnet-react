import { SnackbarContextProps, SnackbarType, useSnackbar } from '../providers/Snackbar.provider';


let snackbarRef: SnackbarContextProps;

export function SnackbarUtilitiesConfig() {
    snackbarRef = useSnackbar();
    return snackbarRef;
}

export const SnackbarUtilities = {
    toast(message: string, type: SnackbarType) {
        snackbarRef.showSnackbar(message, type);
    },
    success(message: string) {
        this.toast(message, 'success');
    },
    error(message: string) {
        this.toast(message, 'error');
    }
};
