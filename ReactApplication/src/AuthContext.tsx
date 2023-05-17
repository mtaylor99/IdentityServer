import { useAuth } from 'oidc-react';
import { getDecodedToken } from './common/utils/tokenUtils';

export function AppContext() {
  const authContext = useAuth();

  const decodedAccessToken = getDecodedToken(
    authContext.userData?.access_token ?? null
  );

  console.log('Decoded Access Token', decodedAccessToken);

  return <div>{authContext.userData?.access_token}</div>;
}
