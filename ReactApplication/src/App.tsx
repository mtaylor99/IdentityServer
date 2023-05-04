import "./App.css";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import { AuthProvider } from "oidc-react";
import { useNavigate } from "react-router-dom";
import AppContext from "./AuthContext";
import { IndexRoutes } from "./routing/IndexRoutes";
import { getOidcConfig } from "./util/AuthUtils";

function App() {
  const navigate = useNavigate();

  return (
    <AuthProvider
      {...getOidcConfig()}
      onSignIn={() => {
        navigate("/");
      }}
    >
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
    </AuthProvider>
  );
}

export default App;
