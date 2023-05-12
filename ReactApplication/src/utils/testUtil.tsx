/* eslint-disable @typescript-eslint/no-explicit-any */
import { ThemeProvider } from '@mui/material';
import { configureStore, EnhancedStore } from '@reduxjs/toolkit';
import { RenderOptions, render as rtlRender } from '@testing-library/react';
import React, { ReactElement } from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter, MemoryRouter, Route, Routes } from 'react-router-dom';
import { ApplicationState } from '../state/slices/applicationSlice';
import { AppState, reducer } from '../state/store';
import { defaultTheme } from '../themes/defaultTheme';

export type IMockState = AppState;

export const initialMockState: IMockState = {
  application: {} as ApplicationState,
  weatherForecastApi: {} as any,
};

type RouteInfo = {
  urlTarget: `/${string}`; // e.g -> /applications/1/detail
  urlMask: `/${string}`; // e.g -> /applications/:applicationId/detail
};

type RenderProps = {
  preloadedState?: IMockState;
  store?: EnhancedStore & unknown;
  renderOptions?: RenderOptions;
};

interface RenderWithRouterProps extends RenderProps {
  routeInfo: RouteInfo;
}

function render(
  ui: ReactElement<any, string | React.JSXElementConstructor<any>>,
  {
    preloadedState = {} as IMockState,
    store = configureStore({ reducer, preloadedState }),
    ...renderOptions
  } = {} as RenderProps
) {
  
  function Wrapper({ children }: { children: ReactElement }) {
    return (
      <Provider store={store}>
        <ThemeProvider theme={defaultTheme}>
          <BrowserRouter />
          {children}
        </ThemeProvider>
      </Provider>
    );
  }
  return rtlRender(ui, { wrapper: Wrapper, ...renderOptions });
}

function renderWithRouter(
  ui: ReactElement<any, string | React.JSXElementConstructor<any>>,
  {
    preloadedState = {} as IMockState,
    store = configureStore({ reducer, preloadedState }),
    routeInfo,
    ...renderOptions
  }: RenderWithRouterProps
) {
  function Wrapper({ children }: { children: ReactElement }) {
    return (
      <Provider store={store}>
        <ThemeProvider theme={defaultTheme}>
          <MemoryRouter initialEntries={[routeInfo.urlTarget]}>
            <Routes>
              <Route path={routeInfo.urlMask} element={children} />
            </Routes>
          </MemoryRouter>
        </ThemeProvider>
      </Provider>
    );
  }
  return rtlRender(ui, { wrapper: Wrapper, ...renderOptions });
}

// re-export everything
// eslint-disable-next-line react-refresh/only-export-components
export * from '@testing-library/react';
// override render method
export { render, renderWithRouter };
