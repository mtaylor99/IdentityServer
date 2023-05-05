import CancelIcon from '@mui/icons-material/Cancel';
import { Button } from '@mui/material';
import { useSnackbar, OptionsObject, SnackbarKey } from 'notistack';

const defaultSnackbarOptions: OptionsObject = {
  autoHideDuration: 5000,
  anchorOrigin: { vertical: 'top', horizontal: 'right' },
};

export function useLocalSnackbar() {
  const { enqueueSnackbar, closeSnackbar } = useSnackbar();

  const action = (key: SnackbarKey) => (
    <Button onClick={() => closeSnackbar(key)}>
      <CancelIcon htmlColor="white" />
    </Button>
  );

  const createSuccessSnackbar = (
    msg: string,
    options?: Partial<OptionsObject>
  ) => {
    enqueueSnackbar(msg, {
      ...defaultSnackbarOptions,
      ...options,
      variant: 'success',
      action,
    });
  };

  const createWarningSnackbar = (
    msg: string,
    options?: Partial<OptionsObject>
  ) => {
    enqueueSnackbar(msg, {
      ...defaultSnackbarOptions,
      ...options,
      variant: 'warning',
      action,
    });
  };

  const createErrorSnackbar = (
    msg: string,
    options?: Partial<OptionsObject>
  ) => {
    enqueueSnackbar(msg, {
      ...defaultSnackbarOptions,
      ...options,
      variant: 'error',
      action,
    });
  };

  const createInfoSnackbar = (
    msg: string,
    options?: Partial<OptionsObject>
  ) => {
    enqueueSnackbar(msg, {
      ...defaultSnackbarOptions,
      ...options,
      variant: 'info',
      action,
    });
  };

  return {
    createSuccessSnackbar,
    createWarningSnackbar,
    createErrorSnackbar,
    createInfoSnackbar,
  };
}
