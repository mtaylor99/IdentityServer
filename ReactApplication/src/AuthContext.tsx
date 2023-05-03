import { useAuth } from "oidc-react";

function AppContext() {
  const authContext = useAuth();

  return <div>{authContext.userData?.access_token}</div>;
}

export default AppContext;
