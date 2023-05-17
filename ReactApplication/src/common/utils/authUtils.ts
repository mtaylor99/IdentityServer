import { AuthProviderProps } from 'oidc-react';

export const getOidcConfig = (): AuthProviderProps => {
  return {
    //UserInfo not used - managed by API
    loadUserInfo: false,
    authority: import.meta.env.VITE_APP_IDP_URL,
    clientId: '9f35adbd-8db7-4a0f-aeec-ee22594e1a96',
    responseType: 'code',
    scope: 'https://localhost:5003/api offline_access profile openid',
    redirectUri: `${import.meta.env.VITE_APP_SPA_URL}/callback`,
    automaticSilentRenew: true,
  };
};
