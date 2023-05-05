import { Action, ThunkAction, configureStore } from "@reduxjs/toolkit";
import { applicationReducer } from "./slices/applicationSlice";

export const store = configureStore({
  reducer: {
    application: applicationReducer,
  },
});

export type AppState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
