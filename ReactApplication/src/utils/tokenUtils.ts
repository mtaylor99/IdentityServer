import jwtDecode from 'jwt-decode';
import { User, Profile } from "oidc-client";

export const getDecodedToken = <T>(token: Nullable<string>) => {
  const decodedToken = token !== null ? jwtDecode<T>(token) : null;

  if (!decodedToken) {
    return null;
  }

  return decodedToken;
};

export const getMockDecodedToken = (): User => {
  return new User({
      id_token: "test-123",
      session_state: "test",
      access_token: "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJNb2NrIiwiaWF0IjoxNjc1Njk5MjEwLCJleHAiOjMyNTA2ODQ5OTMwLCJhdWQiOiJsb2NhbGhvc3Q6MzAwMCIsInN1YiI6InRlc3RAdGVzdC5jb20iLCJnaXZlbl9uYW1lIjoiTW9jayBHaXZlbiBOYW1lIiwiZmFtaWx5X25hbWUiOiJNb2NrIEZhbWlseSBOYW1lIiwicm9sZSI6IjYiLCJwZXJtaXNzaW9ucyI6WyJSZWFkIiwiV3JpdGUiXX0._mSD1RYKEGydc9QfwXSA6-S0JdK9J8OAW79RZrCSSXI",
      refresh_token: "tst-123",
      token_type: "Bearer",
      scope: "HE.Remediation.API",
      profile: {} as Profile,
      expires_at: 32503680000, // 3000-01-01
      state: null
  });
}

export const mockTokenData = {
  id_token: 'test-123',
  session_state: 'test',
  access_token:
    'eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJNb2NrIiwiaWF0IjoxNjc1Njk5MjEwLCJleHAiOjMyNTA2ODQ5OTMwLCJhdWQiOiJsb2NhbGhvc3Q6MzAwMCIsInN1YiI6InRlc3RAdGVzdC5jb20iLCJnaXZlbl9uYW1lIjoiTW9jayBHaXZlbiBOYW1lIiwiZmFtaWx5X25hbWUiOiJNb2NrIEZhbWlseSBOYW1lIiwicm9sZSI6IjYiLCJwZXJtaXNzaW9ucyI6WyJSZWFkIiwiV3JpdGUiXX0._mSD1RYKEGydc9QfwXSA6-S0JdK9J8OAW79RZrCSSXI',
  refresh_token: 'tst-123',
  token_type: 'Bearer',
  scope: 'HE.Remediation.API',
  profile: {},
  expires_at: 32503680000,
};
