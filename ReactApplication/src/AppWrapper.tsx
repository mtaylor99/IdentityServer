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
  const isMock = import.meta.env.VITE_APP_IS_STRICT_MOCKS === "yes";

  const prepare = async () => {
    if (isMock) {
      setIsPreparing(false);
      console.info(
        "************************ SETTING UP MOCKS ************************"
      );
      await setupMSW();
      console.info(
        "************************ FINISHED MOCKS SETUP ************************"
      );
    } else {
      setIsPreparing(false);
    }
  };

  const setupMSW = async () => {
    await (worker as SetupWorkerApi).start();
    console.info("MSW Started");
  };

  useEffect(() => {
    const prepareApp = async () => {
      await prepare();
    };
    prepareApp();
    // eslint-disable-next-line react-hooks/exhaustive-deps
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
