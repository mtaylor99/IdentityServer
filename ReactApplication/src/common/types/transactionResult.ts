export interface PropertyError {
  propertyName: string;
  errorMessage: string;
}

export interface GeneralError {
  errorMessage: string;
}

export interface TransactionError {
  propertyErrors: PropertyError[];
  generalError: GeneralError | null;
}

export interface TransactionResult<TData> {
  ok: boolean;
  status: number;
  data: TData | null;
  error: TransactionError | null;
}
