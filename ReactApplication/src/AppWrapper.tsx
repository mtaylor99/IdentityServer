import React from "react";
import { BrowserRouter } from "react-router-dom";
import App from "./App";

export function AppWrapper() {
  
  return (
    <React.StrictMode>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </React.StrictMode>
  );
}