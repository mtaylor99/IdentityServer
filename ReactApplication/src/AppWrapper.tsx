/* eslint-disable @typescript-eslint/no-empty-function */
import { ThemeProvider } from "@emotion/react";
import { CssBaseline, createTheme } from "@mui/material";
import { deepmerge } from "@mui/utils";
import { SetupWorkerApi } from "msw";
import React, { useEffect, useState } from "react";
import { BrowserRouter } from "react-router-dom";
import { App } from "./App";
import { worker } from "./mocks/browser";
import { defaultTheme } from "./themes/defaultTheme";
import { store } from "./state/store";
import { Provider } from 'react-redux';

export const ColorModeContext = React.createContext({
  toggleColorMode: () => {},
});

export function AppWrapper() {
  const [isPreparing, setIsPreparing] = useState<boolean>(true);
  
  const prepare = () => {
    if (import.meta.env.VITE_APP_IS_STRICT_MOCKS === 'yes') {
      console.log(import.meta.env.VITE_APP_IS_STRICT_MOCKS);
      console.info(
        '************************ USING MOCKS ************************'
      );
      (worker as SetupWorkerApi).start().then(() => {
        setIsPreparing(false);
      });
    } else {
      setIsPreparing(false);
    }
  };


  useEffect(() => {
    prepare();
  }, []);

  const [mode, setMode] = React.useState<"light" | "dark">("light");
  const colorMode = React.useMemo(
    () => ({
      toggleColorMode: () => {
        setMode((prevMode) => (prevMode === "light" ? "dark" : "light"));
      },
    }),
    []
  );

  const theme = React.useMemo(
    () =>
      createTheme(
        deepmerge(
          {
            palette: {
              mode,
            },
          },
          defaultTheme
        )
      ),
    [mode]
  );

  return (
    <>
      {!isPreparing && (
        <React.StrictMode>
          <Provider store={store}>
            <ColorModeContext.Provider value={colorMode}>
              <ThemeProvider theme={theme}>
                <CssBaseline />
                <BrowserRouter>
                  <App />
                </BrowserRouter>
              </ThemeProvider>
            </ColorModeContext.Provider>
          </Provider>
        </React.StrictMode>
      )}
    </>
  );
}
