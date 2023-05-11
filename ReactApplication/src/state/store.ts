import {
  Action,
  AnyAction,
  Reducer,
  ThunkAction,
  configureStore,
} from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/dist/query';
import { weatherForecastApi } from '../api/weatherForecaseApi';
import {
  ApplicationState,
  applicationReducer,
} from './slices/applicationSlice';

export interface IReducer {
  application: Reducer<ApplicationState, AnyAction>;
}

export const reducer = {
  application: applicationReducer,
} as IReducer;

export const configureReduxStore = () => {
  return configureStore({
    reducer: {
      ...reducer,
      [weatherForecastApi.reducerPath]: weatherForecastApi.reducer,
    },
    middleware: getDefaultMiddleware =>
      getDefaultMiddleware({}).concat([weatherForecastApi.middleware]),
  });
};

export const store = configureReduxStore();

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
