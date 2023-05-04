import { Route, Routes } from "react-router-dom";
import { routePaths } from "./routePaths";

export function IndexRoutes() {
  return (
    <Routes>
      <Route path={routePaths.home} element={<div>Home</div>} />
      <Route path={routePaths.dashboard} element={<div>Dashboard</div>} />

      <Route
        path={routePaths.notPermitted}
        element={<div>Not Permitted</div>}
      />
      <Route path={routePaths.errorPage} element={<div>Error</div>} />
      <Route path="*" element={<div>Page Not Found</div>} />
    </Routes>
  );
}
