import { useTheme } from "@emotion/react";
import Brightness4Icon from "@mui/icons-material/Brightness4";
import Brightness7Icon from "@mui/icons-material/Brightness7";
import { Button, IconButton } from "@mui/material";
import { AuthProvider } from "oidc-react";
import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import "./App.css";
import { ColorModeContext } from "./AppWrapper";
import { AppContext } from "./AuthContext";
import reactLogo from "./assets/react.svg";
import { IndexRoutes } from "./routing/IndexRoutes";
import { getOidcConfig } from "./util/authUtils";
import viteLogo from "/vite.svg";

export function App() {
  const navigate = useNavigate();
  const theme = useTheme();
  const colorMode = useContext(ColorModeContext);

  return (
    <AuthProvider
      {...getOidcConfig()}
      onSignIn={() => {
        navigate("/");
      }}
    >
      <IconButton
        sx={{ ml: 1 }}
        onClick={colorMode.toggleColorMode}
        color="inherit"
      >
        {theme.palette.mode === "dark" ? (
          <Brightness7Icon />
        ) : (
          <Brightness4Icon />
        )}
      </IconButton>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
      <IndexRoutes />
      <AppContext />
      <Button variant="text">Text</Button>
      <Button variant="contained">Contained</Button>
      <Button variant="outlined">Outlined</Button>
    </AuthProvider>
  );
}
