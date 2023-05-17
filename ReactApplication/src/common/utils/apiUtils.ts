/* eslint-disable @typescript-eslint/no-explicit-any */
import { TransactionError } from '../types/transactionResult';

const isTransactionError = (error: any) => {
  return (
    error &&
    'data' in error &&
    ('generalError' in error.data || 'propertyErrors' in error.data)
  );
};

export const extractErrorMessages = (error: any) => {
  // We don't know exactly what the error shape will be at this point
  // This method attempts to make some deductions and tries to return something useful

  // Check if the error was part of a TransactionResult
  // If so, try to extract the error info from the various possible locations
  if (isTransactionError(error)) {
    const transactionError = error.data as TransactionError;
    if (transactionError.generalError?.errorMessage) {
      return transactionError.generalError.errorMessage;
    }

    if (transactionError.propertyErrors?.length > 0) {
      return transactionError.propertyErrors
        .map(propertyError => propertyError.errorMessage)
        .join('; ');
    }
  }

  if (error.status) {
    return `Received status: ${error.status}`;
  }

  return 'Could not extract error details';
};
