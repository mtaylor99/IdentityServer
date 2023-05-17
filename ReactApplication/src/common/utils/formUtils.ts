import { FieldValues, Path, UseFormReturn } from 'react-hook-form';
import { TransactionError } from '../types/transactionResult';

export const setServerSideFormErrors = <TForm extends FieldValues>(
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  form: UseFormReturn<TForm, any>,
  error: TransactionError
) => {
  const { setError } = form;
  const { propertyErrors } = error ?? {};

  if (propertyErrors && Array.isArray(propertyErrors)) {
    propertyErrors.forEach(propertyError => {
      setError(propertyError.propertyName as Path<TForm>, {
        message: propertyError.errorMessage,
      });
    });
  }
};

// Deprecated
export const nameof = <TForm>(field: keyof TForm) => field;

// uses react hook form path type to return all keys including nested
export const pathOf = <T>(path: Path<T>) => path;
