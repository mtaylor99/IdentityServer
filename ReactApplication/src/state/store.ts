import { Action, ThunkAction, configureStore } from "@reduxjs/toolkit";
import { applicationReducer } from "./slices/applicationSlice";
import { weatherForecastApi } from "../api/weatherForecaseApi";
import { setupListeners } from "@reduxjs/toolkit/dist/query";

export const store = configureStore({
  reducer: {
    application: applicationReducer,
    [weatherForecastApi.reducerPath]: weatherForecastApi.reducer,
  },
    middleware: getDefaultMiddleware =>
    getDefaultMiddleware({}).concat([
      weatherForecastApi.middleware,
    ]),
});

setupListeners(store.dispatch);

export type AppState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
