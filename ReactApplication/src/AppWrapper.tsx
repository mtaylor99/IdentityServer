import { ThemeProvider } from "@emotion/react";
import { CssBaseline, createTheme } from "@mui/material";
import { deepmerge } from "@mui/utils";
import React from "react";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { defaultTheme } from "./themes/defaultTheme";

export const ColorModeContext = React.createContext({
  toggleColorMode: () => {},
});

export function AppWrapper() {
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
    <React.StrictMode>
      <ColorModeContext.Provider value={colorMode}>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <BrowserRouter>
            <App />
          </BrowserRouter>
        </ThemeProvider>
      </ColorModeContext.Provider>
    </React.StrictMode>
  );
}
