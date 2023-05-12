import { useAuth } from 'oidc-react';
import { getDecodedToken } from '../utils/tokenUtils';

export const useDecodedAccessToken = () => {
  const auth = useAuth();

  const decodedAccessToken = getDecodedToken(
    auth.userData?.access_token ?? null
  );

  return { decodedAccessToken };
};
